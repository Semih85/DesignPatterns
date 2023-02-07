using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateSingleton();

            customerManager.Save();
        }

        class CustomerManager
        {
            static CustomerManager _customerManager;
            static object _locker = new object();
            private CustomerManager()
            {

            }

            public static CustomerManager CreateSingleton()
            {
                lock (_locker)
                {
                    if (_customerManager == null)
                    {
                        _customerManager = new CustomerManager();
                    }
                }

                return _customerManager;
                //return _customerManager ?? (_customerManager = new CustomerManager());
            }

            public void Save()
            {
                Console.WriteLine("Saved");
            }
        }
    }
}
