using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILoveModel
{
    public class CoupleFinder
    {
        Requests req = LogicClassesFactory.Default.GetRequests();
        public async Task<User> FindCouple()
        {
            var users = await req.GetUsers();
            var me = await FindMyself();
            var couple = users
                .Where(pair => (pair.Interests.Intersect(me.Interests)).Count() >= 3 && pair.IsBusy == 0 && pair.UserName != me.UserName && pair.IsMale != me.IsMale)
                .ToList()[0];

            req.UpdateUserData(me, couple);
            req.UpdateUserData(couple, me);
            VKApiManager.Instance.VKWallPost(couple.UserName);

            return couple;
        }

        public async Task<User> ShowMyCouple(string name)
        {
            var users = await req.GetUsers();
            var me = await FindMyself();
            var myCouple = users
                .Where(pair => pair.UserName == name)
                .ToList()[0];

            return myCouple;
        }

        public async Task<User> FindMyself()
        {
            var users = await req.GetUsers();
            var res = users
                .Where(user => user.UserName == InternetManager.Instance.InfoDict["userName"]).ToList()[0];
            return res;
        }
    }
}
