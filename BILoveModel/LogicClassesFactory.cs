using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILoveModel
{
    public class LogicClassesFactory
    {
        private LogicClassesFactory() { }

        static LogicClassesFactory _default;

        public static LogicClassesFactory Default
        {
            get
            {
                if (_default == null)
                    _default = new LogicClassesFactory();
                return _default;
            }
        }

        public InternetManager GetInternetManager()
        {
            return new InternetManager();
        }

        public CoupleFinder GetCoupleFinder()
        {
            return new CoupleFinder();
        }

        public Requests GetRequests()
        {
            return new Requests();
        }
    }
}
