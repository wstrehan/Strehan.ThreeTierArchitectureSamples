using System;
using System.Collections.Generic;
using Strehan.DataAccess;

/// <summary>
/// Returns an instance of an object that implements the IDataAccess interface.   May return the same object over and over or may return a new object
/// </summary>
public static class DataAccessCreator
{
    private const string cConnectionStringKey = "ConnectionString";
    private static IDataAccess _dataAccess;

    /// <summary>
    /// Reads connection string from a configuration file
    /// </summary>
    /// <returns></returns>
    private static string GetConnectionString()
    {
        try
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[cConnectionStringKey].ConnectionString;
            return connStr;
        }
        catch (Exception ex)
        {
            throw new KeyNotFoundException(string.Format("The connection string (key = {0}) could not be obtained from the configuration file", cConnectionStringKey), ex);
        }
    }

    /// <summary>
    /// Create object to connect to Database
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static IDataAccess CreateDataAccess()
    {
        //Sometimes _data access could go out of scope so this object may be created multiple times
        if (_dataAccess == null)
        {
            _dataAccess = new SqlDataAccess(new SProcNameResolution(), GetConnectionString());
        }
        return _dataAccess;
    }
}