using FE.Constants;
using FE.Helpers;
using FE.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.HETHONG;
using MODELS.HETHONG.MENU.Requests;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Security.Claims;

namespace FE.Controllers.HETHONG
{
    public class AccountController : Controller
    {
        ICacheService _cacheService;

        public AccountController()
        {
            _cacheService = new InMemoryCache();
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new LoginRequest();
            ResponseData response = this.LoginAPI(URL_API.GETCODEREGISTER, new { });

            var code = "";
            if (response.Status)
            {
                code = response.Data.ToString();
            }
            ViewBag.Code = code;
            return View("~/Views/Account/Login.cshtml", model);
        }

        [AllowAnonymous]
        public IActionResult LoginPortal()
        {
            return View("~/Views/Account/LoginPortal.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Login(string UserName, string Password)
        {
            try
            {
                var request = new LoginRequest { Password = Password, UserName = UserName };
                if (request != null && ModelState.IsValid)
                {
                    ResponseData response = this.LoginAPI(URL_API.TAIKHOAN_LOGIN, request);
                    if (response.Status)
                    {
                        var userData = JsonConvert.DeserializeObject<MODELTaiKhoan>(response.Data.ToString());
                        _cacheService.Set(userData.UserName + "_info", JsonConvert.SerializeObject(userData), 60 * 12);

                        ResponseData responseConfig = this.LoginAPI(URL_API.CAIDATBAOMAT_GETSESSIONTIME, new { }, userData.Token);
                        if (responseConfig.Status)
                        {
                            FE.Helpers.Common.SessionTime = JsonConvert.DeserializeObject<int>(responseConfig.Data.ToString());
                        }

                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, userData.UserName));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);

                        return Json(new { IsSuccess = true, Message = "", Data = userData.IsChangePass });
                    }
                    else
                    {
                        throw new Exception(response.Message);
                    }
                }
                else
                {
                    throw new Exception(CommonFunc.GetModelStateAPI(this.ModelState));
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message, Data = "" });
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                if (cacheKey.Contains(User.Identity.Name))
                    MemoryCache.Default.Remove(cacheKey);
            }
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }

        #region FUNCTION
        private ResponseData LoginAPI(string action, object model, string token = "")
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    if (!string.IsNullOrWhiteSpace(token))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseTask = client.PostAsJsonAsync(action, model);
                    responseTask.Wait();
                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = MODELS.COMMON.CommonFunc.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }
            return response;
        }

        private ResponseData ExecuteAPIResponse(Task<HttpResponseMessage> responseTask)
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
                    if (!resultData.Success || resultData.StatusCode != 200)
                    {
                        response.Status = false;
                    }
                    else
                    {
                        response.Data = resultData.Result;
                    }
                }
            }
            else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                response.Status = false;
                response.Message = "Phần mềm chưa đăng ký bản quyền hoặc hết hạn bản quyền";
            }
            else
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống";
            }

            return response;

        }

        private string GetBEUrl()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEUrl").Value.ToString();
        }
        #endregion

    }
}
