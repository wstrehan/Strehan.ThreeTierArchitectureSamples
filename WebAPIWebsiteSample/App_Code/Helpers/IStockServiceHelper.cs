public interface IStockServiceHelper
{
    IdReturnData DeleteGadget(string id);
    ListReturnData<Gadget2> GetGadgets();
    ListReturnData<T> GetList<T>();
    ObjectReturnData<Gadget2> InsertGadget(GadgetInsertData data);
    ObjectReturnData<Gadget2> UpdateGadget(GadgetInsertData data, string id);
}