using System;
using System.Collections.Generic;
using System.Configuration;

/// <summary>
/// Summary description for HandlerSampleUtility
/// </summary>
public static class HandlerSampleUtility
{
    private const string cConnectionStringKey = "ConnectionString";

    /// <summary>
    /// Reads connection string from a configuration file
    /// </summary>
    /// <returns></returns>
    public static string GetConnectionString()
    {
        try
        {
            string connStr = ConfigurationManager.ConnectionStrings[cConnectionStringKey].ConnectionString;
            return connStr;
        }
        catch (Exception ex)
        {
            throw new KeyNotFoundException(string.Format("The connection string (key = {0}) could not be obtained from the configuration file", cConnectionStringKey), ex);
        }
    }
}