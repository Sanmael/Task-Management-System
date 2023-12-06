using FrontEnd.Models;
using FrontEnd.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace FrontEnd.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateANewUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateANewUserMethod(UserModel userModel)
        {
            if (!ModelState.IsValid)
                return View(userModel);

            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:7049") };

                HttpResponseMessage postResponse = await client.PostAsJsonAsync($"/api/User", userModel);

                var response = await postResponse.Content.ReadAsStringAsync();

                if (postResponse.StatusCode is HttpStatusCode.Created)
                {
                    BaseResult<UserResponse> userResponse = JsonConvert.DeserializeObject<BaseResult<UserResponse>>(response)!;
                    return Json(new { success = true, message = $"{userResponse.Message} seu ID e {userResponse.Data!.Id} " });
                }

                else
                    return Json(new { message = response });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
