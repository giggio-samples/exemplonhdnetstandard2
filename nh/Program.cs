using NHibernate.Cfg;
using System;
using System.Linq;

namespace nh
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();
            configuration.Configure();
            var SessionFactory = configuration.BuildSessionFactory();
            var session = SessionFactory.OpenSession();

            Console.Write("Digite o nome da Cidade =");
            var name = Console.ReadLine();

            Console.Write("Digite a populaçao=");
            var population = Console.ReadLine();


            var city = new City { Name = name, Population = Convert.ToInt16(population) };
            session.SaveOrUpdate(city);
            session.Flush();

            var cities = session.Query<City>()
                .Where(p => p.Population > 1000)
                .ToList();

            Console.WriteLine($"Cidades com mais de 1000 pessoas:");
            cities.ForEach(x =>
            {
                Console.WriteLine($"{x.Name} -> {x.Population}");
            });
            Console.ReadLine();
            session.Close();
        }
    }
}
