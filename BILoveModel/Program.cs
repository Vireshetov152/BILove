using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILoveModel
{
    class Program
    {

        static void Main(string[] args)
        {
            var req = new Requests();
            var f = new CoupleFinder();
            try
            {
                Task.Run(async () =>
                {
                    List<User> list = await req.GetUsers();
                    //var x = await f.FindMyself();
                }).Wait();
            } catch(AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
