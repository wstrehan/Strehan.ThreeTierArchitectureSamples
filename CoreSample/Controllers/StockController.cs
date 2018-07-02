using Microsoft.AspNetCore.Mvc;

namespace CoreSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
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
            //Returns an object of a class that is derived from the ReturnData class
            return _stockServiceHelper.GetList<Color>();
        }

        [HttpGet]
        [Route("sizes")]
        public ListReturnData<Size> GetSizes()
        {
            //Returns an object of a class that is derived from the ReturnData class
            return _stockServiceHelper.GetList<Size>();
        }

        [HttpGet]
        [Route("gadgets")]
        public ListReturnData<Gadget2> GetAllGadgets()
        {
            //Returns an object of a class that is derived from the ReturnData class
            return _stockServiceHelper.GetGadgets();
        }

        [HttpPost]
        [Route("gadgets")]
        public ObjectReturnData<Gadget2> InsertGadget([FromBody] GadgetInsertData data)
        {
            //Returns an object of a class that is derived from the ReturnData class
            return _stockServiceHelper.InsertGadget(data);
        }

        [HttpPost]
        [Route("gadgets/{id}")]
        public ObjectReturnData<Gadget2> InsertGadget([FromBody] GadgetInsertData data, string id)
        {
            //Returns an object of a class that is derived from the ReturnData class
            return _stockServiceHelper.UpdateGadget(data, id);
        }

        [HttpDelete]
        [Route("gadgets/{id}")]
        public IdReturnData InsertGadget(string id)
        {
            //Returns an object of a class that is derived from the ReturnData class
            return _stockServiceHelper.DeleteGadget(id);
        }
    }
}
