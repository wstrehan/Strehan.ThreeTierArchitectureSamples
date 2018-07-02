﻿//Sample Javascript to test CRUD operations using Generic Handlers

var _id; //0 when adding a new Gadget, != 0 when updating a gadget
var _gadgetLookup = []; //Gadgets are added to this data structure when the list is initially downloaded or a new gadget is added


$(document).ready(function () {
    $("#AddUpdate").hide();

    //Populate table of gadgets shown on main div
    PopulateGadgets();

    //Populate drop down lists shown on add/update div
    PopulateColors();
    PopulateSizes();

    //When the Add Gadget button is pressed, show the div that is used to add a new Gadget and hide the gadget list
    $('#btnShowAddGadget').click(function (e) {
        e.preventDefault();

        _id = 0;
        $("#AddUpdate h2").text("Add Gadget");
        $("#GadgetName").val('');

        $("#GadgetList").hide();
        $("#AddUpdate").show();
    });

    //When the cancel button is pressed on the add/update gadget div, hide the add/update gadget div and show the gadget list
    $('#btnCancel').click(function (e) {
        e.preventDefault();
        $("#AddUpdate").hide();
        $("#GadgetList").show();
    });

    //Make webservice call that stores the new gadget or updated gadget
    $('#btnSave').click(function (e) {
        e.preventDefault();

        //Read in user selections
        var gadgetName = $("#GadgetName").val();
        var colorId = $("#Colors").val();
        var sizeId = $("#Sizes").val();

        //Update or Insert gadget 
        if (_id === 0)
        {
            //Ajax Call
            InsertGadget(gadgetName, colorId, sizeId);
        }
        else
        {
            //Ajax Call
            UpdateGadget(_id, gadgetName, colorId, sizeId);
        }

    });

});


//Update Button Handler for button next to each item in the lsit
function SetupUpdateButtonHandler() {
    $('.Update').unbind().click(function (e) {
        e.preventDefault();

        //Get Id of gadget that is being updated
        _id = $(this).data("id");

        //Prepare screen
        $("#GadgetList").hide();
        $("#AddUpdate").show();
        $("#AddUpdate h2").text("Update Gadget");

        //Lookup what gadget is being updated
        var value = _gadgetLookup[_id];

        //Initialize Selections to match what is currently in the database
        $("#GadgetName").val(value.GadgetName);
        $("#Colors").val(value.ColorId);
        $("#Sizes").val(value.SizeId);
    });
}

//Delete Button Handler for button next to each item in the lsit
function SetupDeleteButtonHandler() {
    $('.Delete').unbind().click(function (e) {
        e.preventDefault();

        //Determine what Id was selected to delete
        _id = $(this).data("id");

        //Ajax Call
        DeleteGadget(_id);
    })
}

//Model Object
function GadgetId(id)
{
    this.Id = id;
}

//Model Object
function GadgetInsertData(gadgetName, colorId, sizeId)
{
    this.GadgetName = gadgetName;
    this.ColorId = colorId;
    this.SizeId = sizeId;
}

//Model Object
function GadgetUpdateData(id, gadgetName, colorId, sizeId) {
    this.Id = id;
    this.GadgetName = gadgetName;
    this.ColorId = colorId;
    this.SizeId = sizeId;
}

//Value is object created on server
//Prepend is a bool that indicates whether a row should be added to the front or back of the list
function AddGadgetRow(value, prepend)
{
    //Gadgets are added to this data structure when the list is initially downloaded or a new gadget is added
    _gadgetLookup[value.GadgetId] = value;

    //Gadget Row with two buttons on the right
    var row = '<tr id=row_' + value.GadgetId + '>' + "<td>" + value.GadgetName + "</td>" + "<td>" + value.ColorName + "</td>" + "<td>" + value.SizeName + "</td>" + "<td>" + value.UpdateDateTimeString + "</td>" + "<td>" + '<button class="Update" data-id="' + value.GadgetId + '">Update</button><button class="Delete" data-id="' + value.GadgetId + '">Delete</button>' + "</td>" + '</tr>';

    if (prepend === true)
    {
        //Beginning of table
        $("#tblGadgets tbody").prepend(row);
    }
    else
    {
        //End of table
        $("#tblGadgets tbody").append(row);
    }
    
}

//Ajax Call
//Calls web service method to add a gadget to the database
function InsertGadget(gadgetName, colorId, sizeId)
{
    var obj = new GadgetInsertData(gadgetName, colorId, sizeId);
    var url = 'handlers/InsertGadget.ashx';

    $.ajax({
        'type': 'POST',
        'cache': false,
        'url': url,
        'contentType': 'application/json',
        'data': JSON.stringify(obj),
        'datatype': 'json',
        'success': function (obj) {
            if (!obj.IsSuccessful) {
                //Web server reached but an error occurred executing code on the server
                alert(obj.ErrorMessage);
            }
            else {
                AddGadgetRow(obj.Value, true);
                $("#AddUpdate").hide();
                $("#GadgetList").show();
            }
            SetupUpdateButtonHandler();
            SetupDeleteButtonHandler();

        },
        'error': function (data) {
            alert('Error connecting to InsertGadget.ashx');
        }
    });
}

//Ajax Call
//Calls web service method to update a gadget in the database
function UpdateGadget(id, gadgetName, colorId, sizeId) {
    var obj = new GadgetUpdateData(id, gadgetName, colorId, sizeId);
    var url = 'handlers/UpdateGadget.ashx';

    $.ajax({
        'type': 'POST',
        'cache': false,
        'url': url,
        'contentType': 'application/json',
        'data': JSON.stringify(obj),
        'datatype': 'json',
        'success': function (obj) {
            if (!obj.IsSuccessful) {
                //Web server reached but an error occurred executing code on the server
                alert(obj.ErrorMessage);
            }
            else {
                $('#row_' + id).remove();
                AddGadgetRow(obj.Value, true);
                $("#AddUpdate").hide();
                $("#GadgetList").show();
            }
            SetupUpdateButtonHandler();
            SetupDeleteButtonHandler();

        },
        'error': function (data) {
            alert('Error connecting to ' + url);
        }
    });
}

//Ajax Call
//Calls web service method to delete a gadget from the database
function DeleteGadget(id) {
    var obj = new GadgetId(id);
    var url = 'handlers/DeleteGadget.ashx';

    $.ajax({
        'type': 'POST',
        'cache': false,
        'url': url,
        'contentType': 'application/json',
        'data': JSON.stringify(obj),
        'datatype': 'json',
        'success': function (obj) {
            if (!obj.IsSuccessful) {
                //Web server reached but an error occurred executing code on the server
                alert(obj.ErrorMessage);
            }
            else {
                $('#row_' + id).remove();
            }

        },
        'error': function (data) {
            alert('Error connecting to ' + url);
        }
    });
}


//Ajax Call
//Gets all non deleted gadgets from the datbase and displays in the gadget list div
function PopulateGadgets() {
    var url = 'handlers/GetAllGadgets.ashx';

    $.ajax({
        'type': 'POST',
        'cache': false,
        'url': url,
        'contentType': 'application/json',
        'datatype': 'json',
        'success': function (obj) {
            if (!obj.IsSuccessful) {
                //Web server reached but an error occurred executing code on the server
                alert(obj.ErrorMessage);
            }
            else {
                $.each(obj.GadgetList, function (index, value) {
                    AddGadgetRow(value)
                });

                SetupUpdateButtonHandler();
                SetupDeleteButtonHandler();         
            }
        },
        'error': function (data) {
            //Can't reach URL at all
            alert('Error connecting to ' + url);
        }
    });
}


//Ajax Call
//Gets list of all available colors from the datbase and put in drop down list in div used to add/update a gadge
function PopulateColors()
{
    var url = 'handlers/GetColors.ashx';

    $.ajax({
        'type': 'POST',
        'cache': false,
        'url': url,
        'contentType': 'application/json',
        'datatype': 'json',
        'success': function (obj) {
            if (!obj.IsSuccessful)
            {
                //Web server reached but an error occurred executing code on the server
                alert(obj.ErrorMessage);
            }
            else
            {
                $.each(obj.List, function (index, value) {
                    $("#Colors").append('<option value=' + value.ColorId + '>' + value.ColorName + '</option>');
                });
            }

            
        },
        'error': function (data) {
            //Can't reach URL at all
            alert('Error connecting to ' + url);
        }
    });
}

//Ajax Call
//Gets list of all available sizes from the datbase and put in drop down list in div used to add/update a gadget
function PopulateSizes() {
    var url = 'handlers/GetSizes.ashx';

    $.ajax({
        'type': 'POST',
        'cache': false,
        'url': url,
        'contentType': 'application/json',
        'datatype': 'json',
        'success': function (obj) {
            if (!obj.IsSuccessful) {
                //Web server reached but an error occurred executing code on the server
                alert(obj.ErrorMessage);
            }
            else {
                $.each(obj.List, function (index, value) {
                    $("#Sizes").append('<option value=' + value.SizeId + '>' + value.SizeName + '</option>');
                });
            }


        },
        'error': function (data) {
            //Can't reach URL at all
            alert('Error connecting to ' + url);
        }
    });
}