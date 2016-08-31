using System;
using System.Collections.Generic;
using RainHyacinth.BLL;
using RainHyacinth.Kernel.Imp;
using RainHyacinth.Lite;

namespace RainHyacinth.UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            KernelManager.Instance.InitLoad();
            while (true)
            {
                if (Console.ReadLine() == "Y") break;
                var wrokContext = new RainWorkContext(new object());
                KernelManager.Instance.Begin_Request(wrokContext);
                //var repository = KernelManager.Instance.DependencyInjectHub.Resolve<IRepository<OrmModel>>();
                var list=new List<OrmModel>();
                for (int i = 0; i < 1000; i++)
                {
                    var model = new OrmModel();
                    list.Add(model);
                    Console.WriteLine(model.Id);
                }
                ServicesHelper.Instance.TestService.BeachAdd(list);
                Console.WriteLine("End");
                KernelManager.Instance.End_Request(wrokContext);
            }
            Console.WriteLine("Exit");
            Console.Read();
        }




    }
}
