using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using RainHyacinth.BLL;
using RainHyacinth.Kernel.Imp;

namespace RainHyacinth.UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            KernelManager.Instance.InitLoad();
            var wrokContext1 = new RainWorkContext(new object());
            KernelManager.Instance.Begin_Request(wrokContext1);
            ServicesHelper.Instance.TestService.Add(new OrmModel());
            KernelManager.Instance.End_Request(wrokContext1);
            Console.WriteLine("开始计时,请输入插入条数：");
            var countInput = Console.ReadLine();
            int count = 100;
            try
            {
                count = Convert.ToInt32(countInput);
            }
            catch
            {
            }
            while (true)
            {
                Console.WriteLine("当前线程Id:" + Thread.CurrentThread.ManagedThreadId);
                var wrokContext = new RainWorkContext(new object());
                KernelManager.Instance.Begin_Request(wrokContext);
                //var repository = KernelManager.Instance.DependencyInjectHub.Resolve<IRepository<OrmModel>>();

                Stopwatch sw = new Stopwatch();
                sw.Start();
                var list = new List<OrmModel>();
                for (int i = 0; i < count; i++)
                {
                    var model = new OrmModel { Name = "rain" + i };
                    list.Add(model);
                }
                ServicesHelper.Instance.TestService.Add(list);
                sw.Stop();
                Console.WriteLine($"{count}:" + sw.Elapsed.TotalMilliseconds);
                KernelManager.Instance.End_Request(wrokContext);

                //Console.WriteLine("是否继续：输入Exit退出,否则继续");
                //if (Console.ReadLine() == "Exit") break;
            }
            Console.WriteLine("Exit");
            Console.Read();
        }




    }
}
