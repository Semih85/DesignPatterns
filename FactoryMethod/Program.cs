using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager manager = new CustomerManager(new LoggerFactory2());

            manager.Save();

            Console.ReadLine();
        }
    }

    class LoggerFactory: ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            //duruma göre hangi logger'ın verileceğine kadar verilir.
            return new SemLogger();
        }
    }

    class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            //duruma göre hangi logger'ın verileceğine kadar verilir.
            return new Log4NetLogger();
        }
    }

    internal interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    internal interface ILogger
    {
        void Log();
    }

    class SemLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with SemLogger");
        }
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    class CustomerManager
    {
        ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            //ILogger logger = new LoggerFactory().CreateLogger();
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }

}
