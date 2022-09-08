using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public class Logger
    {
        private static readonly Logger Instance = new();
        private Logger()
        {

        }

        public static Logger GetInstance() 
            => Instance ?? new Logger();
        
    }
}
