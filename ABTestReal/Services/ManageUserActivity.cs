using ABTestRealDB;
using ABTestRealDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTestReal.Services
{
    public class ManageUserActivity : IUserActivity
    {
        private PGEFContext context = new PGEFContext();
        public UserActivity AddUserActivity(UserActivity userActivity)
        {
            try
            {
                context.UserActivity.Add(userActivity);
                context.SaveChanges();
                return userActivity;
            }
            catch
            {
                return null;
            }
        }

        public decimal[] CalculateRollingRetention(List<UserActivity> userActivities)
        {
            try
            {
                DateTime dateNow = DateTime.Now.Date;
                DateTime firstDayWeek = dateNow.AddDays(-6);

                decimal[] decCalc = new decimal[7];

                int countUsersReg = 0;
                int countUsersBack = 0;
                int inc = 0;

                for (DateTime day = firstDayWeek; day <= dateNow; day = day.AddDays(1))
                {
                    countUsersReg = 0;
                    countUsersBack = 0;
                    foreach (var userActivity in userActivities)
                    {
                        if (userActivity.RegistrationDate <= day.AddDays(-inc - 1))
                        {
                            countUsersReg++;
                        }
                        if (userActivity.LastActivityDate >= day && userActivity.LastActivityDate <= dateNow && userActivity.RegistrationDate <= firstDayWeek)
                        {
                            countUsersBack++;
                        }
                    }
                    if (countUsersReg != 0)
                    {
                        decCalc[inc] = Math.Round((decimal)countUsersBack / countUsersReg * 100, 2);
                    }
                    else decCalc[inc] = 0;
                    inc++;
                }
                return decCalc;
            }
            catch
            {
                return null;
            }
        }
            
            
        

        public List<UserActivity> GetUserActivities()
        {
            try
            {
                return context.UserActivity.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
