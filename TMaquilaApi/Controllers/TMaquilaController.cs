using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supabase;
using TMaquilaApi.Contracts;
using TMaquilaApi.Models;
using TMaquilaApi.Services;
using static Supabase.Postgrest.Constants;

namespace TMaquilaApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TMaquilaController : ControllerBase
    {
        private readonly Client _supabaseClient;
        readonly UserServiceImpl _userService;

        public TMaquilaController(Client supabaseClient, UserServiceImpl userService)
        {
            _supabaseClient = supabaseClient;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello world");
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var results = await _supabaseClient.From<TUser>().Get();
            return Ok(results.Models);
        }

        [HttpGet("registerAccess")]
        public async Task<IActionResult> RegisterAccess()
        {
            var user = await _userService.GetAuthenticatedUser();
            var hostname = HttpContext?.Connection?.RemoteIpAddress?.ToString();
            if (user != null)
            {
                var row = new TblLog
                {
                    UserId = user.Id,
                    Hostname = hostname,
                    CreatedAt = DateTime.Now
                };

                var response = await _supabaseClient.From<TblLog>().Insert(row);
                var Id = response.Models.First().Id;

            }

            return Ok();
        }

        [HttpGet("getLoadsPagination")]
        public async Task<IActionResult> GetLoadsPagination(int pageIndex, int pageSize)
        {
            var totalRows = await _supabaseClient.From<TblLoad>()
            .Count(CountType.Exact);

            var results = await _supabaseClient.From<TblLoad>()
            .Select("*")
            .Order("leg_date", Ordering.Ascending)
            .Range((pageIndex - 1) * pageSize, pageIndex * pageSize - 1)
            .Get();

            var loads = results.Models;
            var numPages = (decimal)(totalRows / pageSize);
            var totalPages = totalRows > 0 ? (int)Math.Ceiling(numPages) : 0;

            var loadsResponse = new LoadsResponse
            {
                totalPages = totalPages,
                Loads = loads
            };

            return Ok(loadsResponse);
        }
    }


}