using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.UI.DTOs.AboutDTOs;
using OnlineEduApp.UI.Helpers;
using OnlineEduApp.UI.Models;

namespace OnlineEduApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutsController : Controller
    {
        private readonly HttpClient _httpClient;

        public AboutsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
       
        }

        public async Task<IActionResult> Index()
        {
            _httpClient.BaseAddress = new Uri(BaseUrl.BaseAddress);

            //AboutDtoWithMetaData? aboutDtosWithMetaData = await _httpClient.GetFromJsonAsync<AboutDtoWithMetaData?>($"abouts/getallabouts?pageNumber={currentPage}&pageSize={pageSize}");
            List<AboutDto>? aboutDtos = await _httpClient.GetFromJsonAsync<List<AboutDto>>($"abouts/getallaboutsnopagging");

            return View(aboutDtos); 
        }
    }
}
