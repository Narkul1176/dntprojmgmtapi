using DAL.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using Repository.Implementation;

namespace DNTPrac_447.Common
{
    public  static class Config
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddScoped<IProductRepository, ProductRepository>();
            Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Services.AddSingleton<ICustom, Custom>();
            Services.AddScoped<AppDbContext>();

            Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
                options.LogTo(x => Console.Write(x));
            });
            return Services;
        }
    }
}
