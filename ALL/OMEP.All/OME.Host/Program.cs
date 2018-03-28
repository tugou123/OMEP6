using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime.Host;

namespace OME.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            // Orleans.Runtime.Configuration.ClientConfiguration.LoadFromFile()

            Console.Title = "All Host" + AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                var configFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", ""), $"{Path.GetFileNameWithoutExtension("OrleanConfiguration4")}.xml"));
                if (!configFile.Exists)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    
                    Console.WriteLine($"{configFile.FullName} 不存在!");
                }
                else
                {
                    using (var host = new SiloHost("Default", configFile))
                    {
                        //初始化服务
                        host.InitializeOrleansSilo();
                        //启动服务
                        host.StartOrleansSilo();

                        if (host.IsStarted)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\nHost is running\nPress 'Enter' to terminate ...\n'");
                        }
                    }
                }
                Console.ReadLine();
                 
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ex Message:{ex.Message}" );
                Console.WriteLine($"Ex Source:{ex.Source}");

            }
          
        }
    }
}
