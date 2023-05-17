using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApp.DTOs;
using OnlineStoreApp.Interfaces.IServices;

namespace OnlineStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdministrationService _administrationService;

        public AdminController(IAdministrationService administrationService)
        {
            _administrationService = administrationService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("verified-users")]
        public async Task<IActionResult> GetVerifiedUsers()
        {
            var users = await _administrationService.GetVerifiedUsers();
            return Ok(new { users = users });
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("waiting-users")]
        public async Task<IActionResult> GetWaitingUsers()
        {
            var users = await _administrationService.GetWaitingUsers();
            return Ok(new { users = users });
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("verify-user")]
        public async Task<IActionResult> GetWaitngUsers(VerifyDTO verifyDTO)
        {
            await _administrationService.SetUserStatus(verifyDTO);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _administrationService.GetAllOrders();
            return Ok(new { orders = orders });
        }
    }
}
