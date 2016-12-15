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
            try
            {
                Task.Run(async () =>
                {
                    List<User> list = await InternetManager.Instance.GetUsers();
                }).Wait();
            } catch(AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
