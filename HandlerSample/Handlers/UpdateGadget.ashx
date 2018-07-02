<%@ WebHandler Language="C#" Class="UpdateGadget" %>

using System;
using Strehan.GenericHandlers;

public class UpdateGadget : UpdateHandler<int, GadgetInsertData, Gadget>{

    public UpdateGadget()
    {
        //Connection string Required
        ConnectionString = HandlerSampleUtility.GetConnectionString();

        //Setting these stored procedure names is required
        UpdateStoredProcedureName = "Stock.UpdateGadget";
        GetByIdStoredProcedureName = "Stock.GetGadgetById";
        
        //Uncomment this to authenticate user or anything else that needs to be done before the handler is executed
        /*
        this.PreExecution = (HttpContext) =>
        {
            return PreExecutionResult.NoErrors;
        };
        */

        //This is optional.  
        //If this delegate is not set then the object will be returned to the javascript exactly as it was read back from the database
        this.BusinessLogic = (returnData) => {

            //Return object that will be serialized into javascript and sent down to the browser
            return new { IsSuccessful = true, Value = new Gadget2(returnData.Value as Gadget)};
        };

        //Uncomment this to add in error handling or to modify the data sent back to the javascript when there are errors
        /*
        this.ErrorHandling = (returnData, exception) => {
            return returnData;
        };
        */
    }




}