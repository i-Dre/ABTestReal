using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABTestRealDB.Entities;

namespace ABTestReal.Services
{
    public interface IUserActivity
    {
        List<UserActivity> GetUserActivities();
        UserActivity AddUserActivity(UserActivity userActivity);

        decimal[] CalculateRollingRetention(List<UserActivity> userActivities);
    }
}
