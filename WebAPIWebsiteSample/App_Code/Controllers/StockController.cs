using System.Web.Http;
using Strehan.DataAccess;

namespace WebAPISample.Controllers
{
    [RoutePrefix("stock")]
    public class StockController : ApiController
    {
        //This object handles all data access and creates the object sent back to the javascript
        IStockServiceHelper _stockServiceHelper;

        public StockController(IStockServiceHelper stockServiceHelper)
        {
            //This object handles all data access and creates the object sent back to the javascript
            _stockServiceHelper = stockServiceHelper;
        }

        [HttpGet]
        [Route("colors")]
        public ListReturnData<Color> GetColors()
        {
            return _stockServiceHelper.GetList<Color>();
        }

        [HttpGet]
        [Route("sizes")]
        public ListReturnData<Size> GetSizes()
        {
            return _stockServiceHelper.GetList<Size>();
        }

        [HttpGet]
        [Route("gadgets")]
        public ListReturnData<Gadget2> GetAllGadgets()
        {
            return _stockServiceHelper.GetGadgets();
        }

        [HttpPost]
        [Route("gadgets")]
        public ObjectReturnData<Gadget2> InsertGadget([FromBody] GadgetInsertData data )
        {
            return _stockServiceHelper.InsertGadget(data);
        }

        [HttpPost]
        [Route("gadgets/{id}")]
        public ObjectReturnData<Gadget2> InsertGadget([FromBody] GadgetInsertData data, string id)
        {
            return _stockServiceHelper.UpdateGadget(data, id);
        }

        [HttpDelete]
        [Route("gadgets/{id}")]
        public IdReturnData InsertGadget(string id)
        {
            return _stockServiceHelper.DeleteGadget(id);
        }






    }
}