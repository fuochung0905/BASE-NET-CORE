using FE.Constants;
using FE.Helpers;
using FE.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.HETHONG;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;


namespace FE.Controllers
{
    [CustomAuthorizeAttribute]
    public class BaseController<T> : Controller
    {
        ICacheService _cacheService;

        public BaseController()
        {
            _cacheService = new InMemoryCache();
        }

        public MODELPhanQuyen GetPhanQuyen()
        {
            List<MODELPhanQuyen> fullRole = new List<MODELPhanQuyen>();

            //Lấy cache
            string cacheMenu = _cacheService.Get<string>(GetUserName() + "_menu");
            string cacheRole = _cacheService.Get<string>(GetUserName() + "_role");
            string cacheGroupRole = _cacheService.Get<string>(GetUserName() + "_grouprole");

            if (string.IsNullOrEmpty(cacheRole))
            {
                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETPHANQUYEN, new { UserId = GetUserId() });
                if (response.Status)
                {
                    _cacheService.Set(GetUserName() + "_role", response.Data.ToString(), 60);
                    fullRole = JsonConvert.DeserializeObject<List<MODELPhanQuyen>>(response.Data.ToString());
                }
            }
            else
            {
                fullRole = JsonConvert.DeserializeObject<List<MODELPhanQuyen>>(cacheRole);
            }
            if (string.IsNullOrEmpty(cacheMenu))
            {
                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETLISTMENU, new { UserId = GetUserId() });
                if (response.Status)
                {
                    _cacheService.Set(GetUserName() + "_menu", response.Data.ToString(), 60);
                }
            }
            if (string.IsNullOrEmpty(cacheGroupRole))
            {
                ResponseData response = this.PostAPI(URL_API.NHOMQUYEN_GETALL, new GetAllRequest());
                if (response.Status)
                {
                    _cacheService.Set(GetUserName() + "_grouprole", response.Data.ToString(), 60);
                }
            }

            MODELPhanQuyen result = fullRole.FirstOrDefault(x => x.ControllerName == typeof(T).Name.ToLower());
            if (result == null) result = new MODELPhanQuyen();

            return result;
        }

        public string GetUserName()
        {
            try
            {
                if (User != null && User.Identity != null && User.Identity.Name != null)
                {
                    return User.Identity.Name;
                }
                else
                {
                    throw new Exception("Vui lòng đăng nhập");
                }
            }
            catch
            {
                throw;
            }
        }

        public string GetUserId()
        {
            try
            {
                if (User != null && User.Identity != null && User.Identity.Name != null)
                {
                    string cacheInfo = _cacheService.Get<string>(GetUserName() + "_info");
                    if (!string.IsNullOrWhiteSpace(cacheInfo))
                    {
                        return JsonConvert.DeserializeObject<MODELTaiKhoan>(cacheInfo).Id.ToString();
                    }
                    else
                    {
                        throw new Exception("Vui lòng đăng nhập");
                    }
                }
                else
                {
                    throw new Exception("Vui lòng đăng nhập");
                }
            }
            catch
            {
                throw;
            }
        }

        private string GetToken()
        {
            string cacheInfo = _cacheService.Get<string>(GetUserName() + "_info");
            if (!string.IsNullOrWhiteSpace(cacheInfo))
            {
                return JsonConvert.DeserializeObject<MODELTaiKhoan>(cacheInfo).Token;
            }
            return "";
        }
        #region Execute API
        public ResponseData GetAPI(string action)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    var responseTask = client.GetAsync(action);
                    responseTask.Wait();
                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = Model.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData PostAPI<T>(string action, T model)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();

                    var responseTask = client.PostAsJsonAsync(action, model);
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        response = ExecuteAPIResponse(responseTask);
                    }
                    else
                    {
                        // Lấy mã lỗi và nội dung trả về nếu có
                        var errorContentTask = result.Content.ReadAsStringAsync();
                        errorContentTask.Wait();
                        string errorContent = errorContentTask.Result;

                        if (result.StatusCode == HttpStatusCode.InternalServerError)
                        {
                            response.Status = false;
                            response.Message = "Lỗi hệ thống (500): " + errorContent;
                        }
                        else
                        {
                            response.Status = false;
                            response.Message = $"Lỗi API: {result.StatusCode} - {errorContent}";
                        }
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                response.Status = false;
                response.Message = "Lỗi kết nối đến server: " + httpEx.Message;
            }
            catch (TaskCanceledException timeoutEx)
            {
                response.Status = false;
                response.Message = "Yêu cầu API bị timeout: " + timeoutEx.Message;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = Model.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData PostFormDataAPI(string action, System.Net.Http.MultipartFormDataContent content)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.PostAsync(action, content);
                    responseTask.Wait();
                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = Model.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData PutAPI<T>(string action, T model)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.PutAsJsonAsync(action, model);
                    responseTask.Wait();

                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = Model.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData DeleteAPI(string action)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.DeleteAsync(action);
                    responseTask.Wait();

                    //To store result of web api response.   
                    var result = responseTask.Result;

                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = Model.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData LoginAPI<T>(string action, T model)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.PostAsJsonAsync(action, model);
                    responseTask.Wait();
                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = Model.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData ExecuteAPIResponse(Task<HttpResponseMessage> responseTask)
        {
            ResponseData response = new ResponseData();

            //To store result of web api response.   
            var result = responseTask.Result;

            //CHECK 401
            //if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //{
            //    HttpContext.SignOutAsync().Wait();
            //    RedirectToAction("Index", "Login").ExecuteResultAsync(this.ControllerContext).Wait();
            //}

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                if (readTask == null)
                {
                    response.Status = false;
                    response.Message = "Lỗi hệ thống";
                }
                else
                {
                    string json = readTask.Result;
                    var resultData = JsonConvert.DeserializeObject<MODELAPIBasic>(json);

                    response.Message = resultData.Message;
                    if (!resultData.Success || resultData.StatusCode != Convert.ToInt32(Model.COMMON.StatusCode.Success))
                    {
                        response.Status = false;
                    }
                    else
                    {
                        response.Data = resultData.Result;
                    }
                }
            }
            else
            {
                    response.Status = false;
                response.Message = "Lỗi hệ thống";
            }

            return response;

        }
        protected string GetCurrentUrl()
        {
            return Request.Scheme + "://" + Request.Host.Value;
        }

        private string GetBEUrl()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEUrl").Value.ToString();
        }

        protected string GetBEFileUrl()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();
        }

        protected string GetDocviewerUrl()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DocviewerUrl").Value.ToString();
        }

        #endregion
    }

    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        ICacheService _cacheService;

        public CustomAuthorizeAttribute()
        {
            _cacheService = new InMemoryCache();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = "";
                string cacheInfo = _cacheService.Get<string>(context.HttpContext.User.Identity.Name + "_info");
                if (!string.IsNullOrWhiteSpace(cacheInfo))
                {
                    token = JsonConvert.DeserializeObject<MODELTaiKhoan>(cacheInfo).Token;
                }

                var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEUrl").Value.ToString();
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.PostAsJsonAsync(URL_API.PING, new { });
                    responseTask.Wait();
                    var result = responseTask.Result;

                    //CHECK 401
                    if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}