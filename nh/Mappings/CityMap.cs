using FluentNHibernate.Mapping;

namespace nh.Mappings
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Population);
        }
    }
}
