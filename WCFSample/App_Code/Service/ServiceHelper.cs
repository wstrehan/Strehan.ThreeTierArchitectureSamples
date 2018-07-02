using System;
using System.Collections.Generic;
using Strehan.DataAccess;


public class ServiceHelper
{
    /// <summary>
    /// Used for reading a list from the database when no business logic is needed
    /// </summary>
    /// <typeparam name="T">Type that matches all fields returned in the stored procedure call</typeparam>
    /// <param name="sProcName"></param>
    /// <returns></returns>
    public static ListReturnData<T> GetList<T>(object context)
    {
        try
        {
            IDataAccess dataAccess = DataAccessCreator.CreateDataAccess();

            ListReturnData<T> returnObject = new ListReturnData<T>
            {
                List = dataAccess.GetList<T>(context),
                IsSuccessful = true
            };

            return returnObject;
        }
        catch (Exception ex)
        {
            ListReturnData<T> returnObject = new ListReturnData<T>()
            {
                //In produciton code ex.ToString() should be logged and a more user friend error message should be returned
                ErrorMessage = ex.ToString(),
                CallingMethod = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name, //method that called this method
                IsSuccessful = false
            };

            return returnObject;
        }
    }


    /// <summary>
    /// Returns all non deleted gadgets
    /// </summary>
    /// <returns></returns>
    public static ListReturnData<Gadget2> GetGadgets()
    {
        try
        {
            //Get list of gadgets from the database
            IDataAccess dataAccess = DataAccessCreator.CreateDataAccess();
            List<Gadget> gadgetList = dataAccess.GetList<Gadget>(StoredProcedureTypes.List);

            //Make new list of objects with additional UpdateDateTimeString field and populate
            List<Gadget2> gadgetList2 = new List<Gadget2>();
            gadgetList.ForEach(gadget => {
                Gadget2 g2 = new Gadget2();
                g2.Populate(gadget);
                gadgetList2.Add(g2);
            });

            ListReturnData<Gadget2> returnObject = new ListReturnData<Gadget2>
            {
                List = gadgetList2,
                IsSuccessful = true
            };

            return returnObject;
        }
        catch (Exception ex)
        {
            ListReturnData<Gadget2> returnObject = new ListReturnData<Gadget2>()
            {
                //In produciton code ex.ToString() should be logged and a more user friend error message should be returned
                ErrorMessage = ex.ToString(),
                CallingMethod = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name, //method that called this method
                IsSuccessful = false
            };

            return returnObject;
        }
    }



    /// <summary>
    /// Inserts a new gadget into the database
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ObjectReturnData<Gadget2> InsertGadget(GadgetInsertData data)
    {
        try
        {
            //Insert row into database and read back object
            IDataAccess dataAccess = DataAccessCreator.CreateDataAccess();
            int id = dataAccess.Insert<int, GadgetInsertData>(data, StoredProcedureTypes.Insert);
            Gadget gadget = dataAccess.GetObjectById<int, Gadget>(id, StoredProcedureTypes.ById);

            Gadget2 g2 = new Gadget2();
            g2.Populate(gadget);

            ObjectReturnData<Gadget2> returnObject = new ObjectReturnData<Gadget2>
            {
                Id = id.ToString(), //Easier to deal with Id as a string in javascript
                Value = g2, // Adds UpdateDateTimeString so javascript doesn't have to convert the time to a string
                IsSuccessful = true
            };

            return returnObject;
        }
        catch (Exception ex)
        {
            ObjectReturnData<Gadget2> returnObject = new ObjectReturnData<Gadget2>()
            {
                //In produciton code ex.ToString() should be logged and a more user friend error message should be returned
                ErrorMessage = ex.ToString(),
                CallingMethod = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name, //method that called this method
                IsSuccessful = false
            };

            return returnObject;
        }
    }

    /// <summary>
    /// Updates an existing gadget in the database
    /// </summary>
    /// <param name="data"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static ObjectReturnData<Gadget2> UpdateGadget(GadgetInsertData data, string id)
    {
        try
        {
            //Update row in database and read back from the database
            IDataAccess dataAccess = DataAccessCreator.CreateDataAccess();
            dataAccess.UpdateById<int, GadgetInsertData>(int.Parse(id), data, StoredProcedureTypes.Update);
            Gadget gadget = dataAccess.GetObjectById<int, Gadget>(int.Parse(id), StoredProcedureTypes.ById);

            Gadget2 g2 = new Gadget2();
            g2.Populate(gadget);

            ObjectReturnData<Gadget2> returnObject = new ObjectReturnData<Gadget2>
            {
                Id = id.ToString(), //Easier to deal with Id as a string in javascript
                Value = g2, // Adds UpdateDateTimeString so javascript doesn't have to convert the time to a string
                IsSuccessful = true
            };

            return returnObject;
        }
        catch (Exception ex)
        {
            ObjectReturnData<Gadget2> returnObject = new ObjectReturnData<Gadget2>()
            {
                //In produciton code ex.ToString() should be logged and a more user friend error message should be returned
                ErrorMessage = ex.ToString(),
                CallingMethod = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name, //method that called this method
                IsSuccessful = false
            };

            return returnObject;
        }
    }

    /// <summary>
    /// Deletes a gadget in the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static IdReturnData DeleteGadget(string id)
    {
        try
        {
            //Delete Row in Database row in database 
            IDataAccess dataAccess = DataAccessCreator.CreateDataAccess();

            //Send in the id to indicate what row to update
            //Send in the Gadget type which is used for SProcNameResolution
            dataAccess.IdCall<int,Gadget>(int.Parse(id), StoredProcedureTypes.Delete);

            IdReturnData returnObject = new IdReturnData()
            {
                Id = id.ToString(), //Easier to deal with Id as a string in javascript
                IsSuccessful = true
            };

            return returnObject;
        }
        catch (Exception ex)
        {
            IdReturnData returnObject = new IdReturnData()
            {
                //In produciton code ex.ToString() should be logged and a more user friend error message should be returned
                ErrorMessage = ex.ToString(),
                CallingMethod = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name, //method that called this method
                IsSuccessful = false
            };

            return returnObject;
        }
    }



}

