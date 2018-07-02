<%@ WebHandler Language="C#" Class="GetSizes" %>

using System;
using Strehan.GenericHandlers;

public class GetSizes :  ListHandler<Size> {

    public GetSizes()
    {
        //Connection string Required
        ConnectionString = HandlerSampleUtility.GetConnectionString();

        //Required - tell base handler what stored procedure to use
        StoredProcedureName = "Stock.GetSizes";
    }

}
