using EmployeeDirectory.Web.Common;
using EmployeeDirectory.Web.Interfaces;
using EmployeeDirectoryProcessor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeDirectory.Web.Services
{
   
    public class EmployeeDirectoyWebAppService : IEmployeeDirectoyWebAppService
    {
        private ServiceRepository _serviceRepository;
        public EmployeeDirectoyWebAppService(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public bool CreateUser(UserModel user)
        {
            try
            {
                var response = _serviceRepository.PostResponse("api/user", user);
                if (!response.IsSuccessStatusCode)
                    return false;
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool DeleteUser(string userName)
        {
            try
            {
                var response = _serviceRepository.DeleteResponse("api/user/" + userName);
                if (!response.IsSuccessStatusCode)
                    return false;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            List<UserModel> userModels;
            try
            {
                var response = _serviceRepository.GetResponse("api/user");
                if (!response.IsSuccessStatusCode)
                    return new List<UserModel>();
                
                var responseData = await response.Content.ReadAsStringAsync();
                userModels = JsonConvert.DeserializeObject<List<UserModel>>(responseData);

                return userModels;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> GetUser(string userName)
        {
            UserModel userModel;
            try
            {
                var response = _serviceRepository.GetResponse("api/user/username/" + userName);
                if (!response.IsSuccessStatusCode)
                    return new UserModel();

                var responseData = await response.Content.ReadAsStringAsync();
                userModel = JsonConvert.DeserializeObject<UserModel>(responseData);

                return userModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserModel>> GetUserByUserType(UserType userType)
        {
            List<UserModel> userModels;
            try
            {
                var response = _serviceRepository.GetResponse("api/user/usertype" + userType);
                if (!response.IsSuccessStatusCode)
                    return new List<UserModel>();

                var responseData = await response.Content.ReadAsStringAsync();
                userModels = JsonConvert.DeserializeObject<List<UserModel>>(responseData);

                return userModels;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool UpdateUser(UserModel user)
        {
            try
            {
                var response = _serviceRepository.PutResponse("api/user", user);
                if (!response.IsSuccessStatusCode)
                    return false;
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool ValidateLogin(string userName, string password)
        {
            try
            {
                //TO DO
                //bool isValid = _serviceRepository.GetResponse();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
