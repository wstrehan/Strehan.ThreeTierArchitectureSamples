<%@ WebHandler Language="C#" Class="DeleteGadget" %>

using System;
using Strehan.GenericHandlers;

public class DeleteGadget : ByIdHandler<int>{

    public DeleteGadget()
    {
        //Connection string Required
        ConnectionString = HandlerSampleUtility.GetConnectionString();

        //Required - tell base handler what stored procedure to use
        StoredProcedureName = "stock.DeleteGadget";

        //Uncomment this to authenticate user or anything else that needs to be done before the handler is executed
        /*
        this.PreExecution = (HttpContext) =>
        {
            return PreExecutionResult.NoErrors;
        };
        */

        //Uncomment this to add business logic or to modify the data sent back to the javascript when no errors
        /*
        this.BusinessLogic = (returnData) => {
            return returnData;
        };
        */

        //Uncomment this to add in error handling or to modify the data sent back to the javascript when there are errors
        /*
        this.ErrorHandling = (returnData, exception) => {
            return returnData;
        };
        */
    }

}