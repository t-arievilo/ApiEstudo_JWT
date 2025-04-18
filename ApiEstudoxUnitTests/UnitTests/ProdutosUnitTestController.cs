using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiEstudo.Context;
using ApiEstudo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiEstudoxUnitTests.UnitTests
{
    public class ProdutosUnitTestController
    {
        public IUnitOfWork repository;
        public static DbContextOptions<AppDbContext> DbContextOptions { get; }

        public static string connectionString = "Server=localhost;Database=apicatalogoDb;Uid=root;pwd=thiago0508";

        static ProdutosUnitTestController()
        {
            DbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;
        }

        public ProdutosUnitTestController()
        {
            var context = new AppDbContext(DbContextOptions);
            repository = new UnityOfWork(context);
        }
    }
}
