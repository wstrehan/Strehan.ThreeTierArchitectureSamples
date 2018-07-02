using System;
using System.Collections.Generic;
using System.Text;

namespace Strehan.DataAccess
{
    /// <summary>
    /// StoreageMappingSQL is injected into the DataAccess constructor and provides the stored procedure names that that DataAccess object needs
    /// </summary>
    public class SProcNameResolution : IContext
    {

        /// <summary>
        /// Obtains a stored procedure name used to call a stored procedure in SQL Server
        /// </summary>
        /// <typeparam name="T">The type of the model used for CRUD operations</typeparam>
        /// <param name="context">List, Insert, Update, Delete, or other operation</param>
        /// <returns></returns>
        public object GetMappingItem<T>(object context)
        {
            string storedProcedureName = string.Empty;
            StoredProcedureTypes storageFunction = (StoredProcedureTypes)context;

            switch (storageFunction)
            {
                case StoredProcedureTypes.List:
                    if (typeof(T) == typeof(Color)) storedProcedureName = "Stock.GetColors";
                    else if (typeof(T) == typeof(Size)) storedProcedureName = "Stock.GetSizes";
                    else if (typeof(T) == typeof(Gadget)) storedProcedureName = "Stock.GetAllGadgets";
                    else throw new ArgumentException(String.Format("{0} is not a supported model for the {1} function", typeof(T).Name, storageFunction), "model");
                    break;
                case StoredProcedureTypes.Insert:
                    if (typeof(T) == typeof(GadgetInsertData)) storedProcedureName = "Stock.InsertGadget";
                    else throw new ArgumentException(String.Format("{0} is not a supported model for the {1} function", typeof(T).Name, storageFunction), "model");
                    break;
                case StoredProcedureTypes.Update:
                    if (typeof(T) == typeof(GadgetInsertData)) storedProcedureName = "Stock.UpdateGadget";
                    else throw new ArgumentException(String.Format("{0} is not a supported model for the {1} function", typeof(T).Name, storageFunction), "model");
                    break;
                case StoredProcedureTypes.Delete:
                    if (typeof(T) == typeof(Gadget)) storedProcedureName = "Stock.DeleteGadget";
                    else throw new ArgumentException(String.Format("{0} is not a supported model for the {1} function", typeof(T).Name, storageFunction), "model");
                    break;
                case StoredProcedureTypes.ById:
                    if (typeof(T) == typeof(Gadget)) storedProcedureName = "Stock.GetGadgetById";
                    else throw new ArgumentException(String.Format("{0} is not a supported model for the {1} function", typeof(T).Name, storageFunction), "model");
                    break;
                default:
                    throw new ArgumentException(String.Format("{0} is not a supported function", storageFunction), "function");
            }

            return storedProcedureName;
        }

        public object GetMappingItem(object context)
        {
            throw new NotImplementedException();
        }






    }
}
