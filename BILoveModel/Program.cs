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
            //VKApiManager m = new VKApiManager();
            //m.VKAuthorization("", "");

            InternetManager im = new InternetManager();
            Task.Run(async () =>
            {
                string x = await im.AddUser();
                Console.WriteLine(x);
            }).Wait();
            
        }
    }
}
