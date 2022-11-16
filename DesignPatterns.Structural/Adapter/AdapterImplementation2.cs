using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter
{
    public class CityFromExternalSystem
    {
        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }

        public string Name { get; }
        public string NickName { get; }
        public int Inhabitants { get; }
    }

    public interface IExternalSystem
    {
        CityFromExternalSystem GetCity();
    }

    // Adaptee
    public class ExternalSystem : IExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("The city", "Wonderfull City", 5000);
        }
    }

    public class City
    {
        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }

        public string FullName { get; }
        public long Inhabitants { get; }

        public override string ToString()
        {
            return $"{this.FullName} has {this.Inhabitants} Inhabitants";
        }
    }

    // Target
    public interface ICityAdapter
    {
        City GetNewCity();
    }

    // Object Adapter (using composition)
    public class CityAdapter : ICityAdapter
    {
        private readonly IExternalSystem _externalSystem;

        public CityAdapter(IExternalSystem externalSystem)
        {
            _externalSystem = externalSystem;
        }

        public City GetNewCity()
        {
            var externalSystemCity = _externalSystem.GetCity();
            var city = new City($"{externalSystemCity.Name} [{externalSystemCity.NickName}]", externalSystemCity.Inhabitants);

            return city;
        }
    }

    // Class adapter (using inheritance)
    public class CityAdapterClass : ExternalSystem, ICityAdapter
    {
        public City GetNewCity()
        {
            var externalSystemCity = base.GetCity();
            var city = new City($"{externalSystemCity.Name} [{externalSystemCity.NickName}]", externalSystemCity.Inhabitants);

            return city;
        }
    }  
    
}
