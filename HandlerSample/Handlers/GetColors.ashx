<%@ WebHandler Language="C#" Class="GetColors" %>

using System;
using Strehan.GenericHandlers;

public class GetColors :  ListHandler<Color> {

    public GetColors()
    {
        //Connection string Required
        ConnectionString = HandlerSampleUtility.GetConnectionString();

        //Required - tell base handler what stored procedure to use
        StoredProcedureName = "Stock.GetColors";

    }

}