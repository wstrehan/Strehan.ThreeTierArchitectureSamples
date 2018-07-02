<%@ Application Language="C#" %>
<%@ Import namespace="System.Web.Http" %>
<%@ Import namespace="System.Web.Http.Dispatcher" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        //Setup the web service
        GlobalConfiguration.Configure(WebApiConfig.Register);

        //Custom HttpControllerActivator needed for dependency injection into StockController
        GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WebAPISample.Controllers.HttpControllerActivator());
    }

    void Application_End(object sender, EventArgs e)
    {

    }

    void Application_Error(object sender, EventArgs e)
    {

    }

    void Session_Start(object sender, EventArgs e)
    {

    }

    void Session_End(object sender, EventArgs e)
    {

    }

</script>
