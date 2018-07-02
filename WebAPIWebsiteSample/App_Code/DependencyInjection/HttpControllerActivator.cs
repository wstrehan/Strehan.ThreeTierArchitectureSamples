using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Strehan.DataAccess;


namespace WebAPISample.Controllers
{

    /// <summary>
    /// Custome controller activator to handle dependency injection for StockController
    /// </summary>
    public class HttpControllerActivator : IHttpControllerActivator
    {
        private const string cConnectionStringKey = "ConnectionString";

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {

            if (controllerType == typeof(StockController))
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[cConnectionStringKey].ConnectionString;
                IDataAccess dataAccess = new SqlDataAccess(new SProcNameResolution(), connStr);
                IStockServiceHelper helper = new StockServiceHelper(dataAccess);

                return new StockController(helper);
            }
            else
            {
                return null;
            }
        }
    }
}