<%@ WebHandler Language="C#" Class="GetAllGadgets" %>

using System;
using System.Collections.Generic;
using Strehan.GenericHandlers;

public class GetAllGadgets : ListHandler<Gadget> {

    public GetAllGadgets()
    {
        //Connection string Required
        ConnectionString = HandlerSampleUtility.GetConnectionString();

        //Required - tell base handler what stored procedure to use
        StoredProcedureName = "Stock.GetAllGadgets";
        
        //Uncomment this to authenticate user or anything else that needs to be done before the handler is executed
        /*
        this.PreExecution = (HttpContext) =>
        {
            return PreExecutionResult.NoErrors;
        };
        */
        
        //This is optional.  
        //If this delegate is not set then the list of objects will be sent down exactly as returned from the data access layer
        this.BusinessLogic = (returnData) => {

            //Make new list of objects with additional UpdateDateTimeString field and populate
            List<Gadget2> gadgetList = new List<Gadget2>();
            returnData.List.ForEach(gadget => { gadgetList.Add(new Gadget2(gadget));  });

            //Return object that will be serialized into javascript and sent down to the browser
            return new { IsSuccessful = true, GadgetList = gadgetList   };
        };

        //Uncomment this to add in error handling or to modify the data sent back to the javascript when there are errors
        /*
        this.ErrorHandling = (returnData, exception) => {
            return returnData;
        };
        */
    }

}