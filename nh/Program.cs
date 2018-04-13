using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace nh
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sessionFactory = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NHTeste;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .BuildSessionFactory();
            var session = sessionFactory.OpenSession();

            Console.Write("Digite o nome da Cidade =");
            var name = Console.ReadLine();

            Console.Write("Digite a populaçao =");
            var population = Console.ReadLine();


            var city = new City { Name = name, Population = Convert.ToInt32(population) };
            await session.SaveOrUpdateAsync(city);
            await session.FlushAsync();

            var cities = session.Query<City>()
                .Where(p => p.Population > 1000)
                .ToList();

            Console.WriteLine($"Cidades com mais de 1000 pessoas:");
            cities.ForEach(x => Console.WriteLine($"{x.Name} -> {x.Population}"));
            Console.WriteLine($"Aperte qualquer tecla para continuar.");
            Console.Read();
            session.Close();
        }
    }
}
