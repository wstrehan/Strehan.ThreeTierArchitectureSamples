<%@ WebHandler Language="C#" Class="InsertGadget" %>

using System;
using Strehan.GenericHandlers;

public class InsertGadget : InsertHandler<int, GadgetInsertData, Gadget>{

    public InsertGadget()
    {
        //Connection string Required
        ConnectionString = HandlerSampleUtility.GetConnectionString();

        //Setting these stored procedures is required
        InsertStoredProcedureName = "Stock.InsertGadget";
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