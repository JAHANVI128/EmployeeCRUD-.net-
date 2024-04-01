using CommonCMS.Common;
using CommonCMS.Model.System;
using Employee.Models;
using IService;
using System.Data;

namespace  Employee.Service.Service
 {
    public class EmployeeService : IEmployeeService
    {
        #region Constants
        public static DapperConnection? dapperConnection;
        #endregion

        #region Constructor
        public EmployeeService()
        {
            dapperConnection = new DapperConnection();
        }
        #endregion

        #region Public Method(s)

        public List<Emp> GetList()
        {
            try
            {
                return dapperConnection.GetListResult<Emp>("PROC_GetEmployees", CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_GetEmployees", ex.ToString(), "EmployeeService", "GetList");
                return null;
            }
        }

        public JsonResponseModel AddOrUpdate(Emp model, object PopupMessageType)
        {
            JsonResponseModel jsonResponseModel = new JsonResponseModel();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_Name", model.Name);
                dictionary.Add("p_Email", model.Email);
                dictionary.Add("p_Age", model.Age);
                dictionary.Add("p_Gender", model.Gender);
                dictionary.Add("p_IsActive", model.IsActive);

                var data = dapperConnection.GetListResult<long>("PROC_AddOrUpdateEmployee", CommandType.StoredProcedure, dictionary).FirstOrDefault();

                if (model.Id == 0)
                {
                    jsonResponseModel.strMessage = "Employee added successfully";
                    jsonResponseModel.isError = false;
                    jsonResponseModel.type = "success";
                }
                else
                {
                    jsonResponseModel.strMessage = "Employee updated successfully";
                    jsonResponseModel.isError = false;
                    jsonResponseModel.type = "success";
                }
                model.Id = (int)data;
                jsonResponseModel.result = model.Id;
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_AddOrUpdateEmployee", ex.ToString(), "EmployeeService", "AddOrUpdate");
                jsonResponseModel.strMessage = ex.Message;
                jsonResponseModel.isError = true;
                jsonResponseModel.type = "error";
            }
            return jsonResponseModel;
        }

        public void Delete(long id)
        {
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("p_Id", id);
                //dapperConnection.ExecuteWithoutResultStatic("PROC_DeleteEmployee", CommandType.StoredProcedure, dictionary);
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into PROC_DeleteEmployee", ex.ToString(), "EmployeeService", "Delete");
            }
        }

        public Emp Get(long Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Emp> IEmployeeService.List => throw new NotImplementedException();

        public void AddOrUpdate(Emp model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
