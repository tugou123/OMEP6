using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OME.Unity
{
    public class UnityIoc
    {
        private readonly IUnityContainer _unityContainer;
        private static UnityIoc dbinstance;
        // private static readonly UnityIoc dbinstance = new UnityIoc("DBcontainer");
        public static string containerName = "MyContainer";

        public static string filepath = string.Empty;
        public UnityIoc()
        {

        }

        public UnityIoc(string containerName)
        {
            ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap() { ExeConfigFilename = filepath };
            UnityConfigurationSection section = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None).GetSection("unity") as UnityConfigurationSection;
            _unityContainer = new UnityContainer();
            section.Configure(_unityContainer, containerName);
        }
        public static string GetmapToByName(string containerName, string itype, string name = "")
        {
            try
            {
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                var _Containers = section.Containers;
                foreach (var _Container in _Containers)
                {
                    if (_Container.Name == containerName)
                    {
                        var _Registrations = _Container.Registrations;
                        foreach (var _Registration in _Registrations)
                        {
                            if (name == "" && string.IsNullOrEmpty(_Registration.Name) && _Registration.TypeName == itype)
                            {
                                return _Registration.MapToName;
                            }
                        }
                        break;
                    }
                }
                return "";
            }
            catch
            {
                throw;
            }

        }

        //单利模式

        public static UnityIoc DBInstance
        {
            get
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(filepath))
                    {
                        throw new Exception("The configuration file path does not exist");
                    }
                    //if (dbinstance == null || dbinstance._unityContainer == null)
                    //{
                        dbinstance = new UnityIoc(containerName);
                   // }
                    return dbinstance;
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
        }



        public object GetService(Type serviceType)
        {
            return _unityContainer.Resolve(serviceType);
        }
        public T GetService<T>()
        {
            return _unityContainer.Resolve<T>();
        }
        public T GetService<T>(params ParameterOverride[] obj)
        {
            return _unityContainer.Resolve<T>(obj);
        }
        public T GetService<T>(string name, params ParameterOverride[] obj)
        {
            return _unityContainer.Resolve<T>(name, obj);
        }

    }
}
