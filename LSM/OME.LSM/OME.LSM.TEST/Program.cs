
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using OEM.LSM.Write.Contract.Facade;
using OME.Unity;
using Orleans;

namespace OME.LSM.TEST
{
    class Program
    {
        //  userServce;
        static void Main(string[] args)
        {
          
            //var _A = new A()
            //{
            //    Id = 1,
            //    Name = "网站",
            //    CreateTime = DateTime.Now
            //};

            //var B = _A.MapTo<B>();
            //GetTaskL().Wait();
           GetTask().Wait();

           

            //var dao = UnitySingleton.Getinstance<ITest>();
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //var strc= dao.Hello("三球");

            // UnityIoc.containerName = "MyContainer";
            // UnityIoc.filepath= AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "") + "Unity.config";

            //var dotcx=   UnityIoc.DBInstance.GetService<ITest>();
            // Console.ForegroundColor = ConsoleColor.Red;

            // dotcx.Hello("测试二");

            //var dot = UnityIoc.DBInstance.GetService<ICollectUserFacade>();
            //Console.ForegroundColor = ConsoleColor.Gray;
            //dot.AddCollectUser(new OEM.LSM.Write.Contract.InputDao.CollectUserRequest()
            //{
            //    Id = 10,
            //    CollectCode = "12222",
            //    CollectUserName = "nihaio",
            //    HeaderImage = "jajaja",
            //    IDCard = "jhajja",
            //    Phone = "123368555"

            //}).Wait();
            Console.ReadLine();
        }

      
        public async static Task GetTask()
        {

            var prot = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(1234);

            GrainClient.Initialize(prot);

            IDemoFacade userServce = GrainClient.GrainFactory.GetGrain<IDemoFacade>("key");

            var res = await userServce.Hello();
            var smx=  await userServce.GetV("HHHHHHSHSHSHSHS");
            Console.WriteLine(res+":"+ smx);
        }

        public async static Task GetTaskL()
        {

            var prot = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(1234);

            GrainClient.Initialize(prot);
            ICollectUserFacade userServce = GrainClient.GrainFactory.GetGrain<ICollectUserFacade>("key");
            Console.ForegroundColor = ConsoleColor.Gray;
            userServce.AddCollectUser(new OEM.LSM.Write.Contract.InputDao.CollectUserRequest()
            {
                Id = 10,
                CollectCode = "12222",
                CollectUserName = "nihaio",
                HeaderImage = "jajaja",
                IDCard = "jhajja",
                Phone = "123368555"

            }).Wait();
          
        }
    }




    public class A
    {
        public long Id { set; get; }

        public string Name { set; get; }

        public DateTime CreateTime { set; get; }
    }


    public class B
    {
        public long Id { set; get; }

        public string Name { set; get; }

        public  string Reamake { set; get; }
    }




    public interface ITest
    {
        Task Hello(string str);
    }


    public class Test : ITest
    {
        public async Task Hello(string str)
        {
           await  Task.Delay(100);
            Console.Write($"小可爱：{str}");
        }
    }



    public class UnitySingleton
    {

        private static UnitySingleton instance;

        /// <summary>
        /// IOC 容器
        /// </summary>
        public IUnityContainer container;
        public static UnitySingleton GetSingleton()
        {
            if (instance == null || instance.container == null)
            {
                string configFile = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\","")+"Unity.config";
                var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
                //从config文件中读取配置信息
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                //获取指定名称的配置节
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection("unity");
                instance = new UnitySingleton()
                {
                    //container = new UnityContainer().LoadConfiguration((UnityConfigurationSection)ConfigurationManager.GetSection("unity"), "MyContainer")
                    container = new UnityContainer().LoadConfiguration(section, "MyContainer")
                    //container = new UnityContainer()
                };
                //instance.container.RegisterType<IExampleClass, ExampleClass>();
            }
            return instance;
        }

        /// <summary>
        /// IOC 实体注入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Getinstance<T>()
        {
            return GetSingleton().container.Resolve<T>();
        }
    }


    public class DIExampleClass
    {
        [Microsoft.Practices.Unity.Dependency]
        public ITest test { set; get; }

        private ITest _test;
        public  void DoWork()
        {
           // test.Hello("三秋");
            _test.Hello("二夏");
        }
        [InjectionMethod]
        public void Initialize(ITest instance)
        {
            _test = instance;
        }
    }
}
