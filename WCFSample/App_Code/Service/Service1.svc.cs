

namespace restfulws
{

    public class Service1 : IService1
    {
        /// <summary>
        /// Returns all available colors
        /// </summary>
        /// <returns></returns>
        public ListReturnData<Color> GetColors()
        {
            return ServiceHelper.GetList<Color>(StoredProcedureTypes.List);
        }

        /// <summary>
        /// Returns all available sizes
        /// </summary>
        /// <returns></returns>
        public ListReturnData<Size> GetSizes()
        {
            return ServiceHelper.GetList<Size>(StoredProcedureTypes.List);
        }

        /// <summary>
        /// Returns all non deleted gadgets
        /// </summary>
        /// <returns></returns>
        public ListReturnData<Gadget2> GetGadgets()
        {
            return ServiceHelper.GetGadgets();
        }

        /// <summary>
        /// Inserts a new gadget into the database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ObjectReturnData<Gadget2> InsertGadget(GadgetInsertData data)
        {
            return ServiceHelper.InsertGadget(data);
        }

        /// <summary>
        /// Updates an existing gadget in the database
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ObjectReturnData<Gadget2> UpdateGadget(GadgetInsertData data, string id)
        {
            return ServiceHelper.UpdateGadget(data, id);
        }

        /// <summary>
        /// Deletes a gadget in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IdReturnData DeleteGadget(string id)
        {
            return ServiceHelper.DeleteGadget(id);
        }
    }
}
