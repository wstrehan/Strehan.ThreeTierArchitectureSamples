using System.ServiceModel;
using System.ServiceModel.Web;

namespace restfulws
{


    [ServiceContract()]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/stock/colors/", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        ListReturnData<Color> GetColors();

        [OperationContract]
        [WebGet(UriTemplate = "/stock/sizes/", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        ListReturnData<Size> GetSizes();

        [OperationContract]
        [WebGet(UriTemplate = "/stock/gadgets/", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        ListReturnData<Gadget2> GetGadgets();

        [OperationContract]
        [WebInvoke(UriTemplate = "/stock/gadgets/", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObjectReturnData<Gadget2> InsertGadget(GadgetInsertData data);

        [OperationContract]
        [WebInvoke(UriTemplate = "/stock/gadgets/{id}/", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObjectReturnData<Gadget2> UpdateGadget(GadgetInsertData data, string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/stock/gadgets/{id}/", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IdReturnData DeleteGadget(string id);

    }

}
