using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILove
{
    class WindowsFactory
    {
        private WindowsFactory() { }

        static WindowsFactory _default;

        public static WindowsFactory Default
        {
            get
            {
                if (_default == null)
                    _default = new WindowsFactory();
                return _default;
            }
        }

        public MainWindow GetMainWindow()
        {
            return new MainWindow();
        }

        public AuthorizationWindow GetAuthorizationWindow()
        {
            return new AuthorizationWindow();
        }

        public ResultsWindow GetResultsWindow()
        {
            return new ResultsWindow();
        }
    }
}
