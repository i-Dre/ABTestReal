using ABTestReal.Services;
using ABTestRealDB.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTestReal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserActivityController : Controller
    {
        private IUserActivity _userActivity;

        public UserActivityController(IUserActivity userActivity)
        {
            _userActivity = userActivity;
        }

        [HttpGet]
        public IActionResult GetUserActivities()
        {
            try
            {
                return Ok(_userActivity.GetUserActivities());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddUserActivity(UserActivity userActivity)
        {
            try
            {
                _userActivity.AddUserActivity(userActivity);
                return Ok(_userActivity.GetUserActivities());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("calc")]
        public IActionResult CalculateRollingRetention()
        {
            try
            {
                return Ok(_userActivity.CalculateRollingRetention(_userActivity.GetUserActivities()));
            }
            catch
            {
                return NotFound();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
