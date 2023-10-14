
using Microsoft.EntityFrameworkCore;
using ReviewerApp.Data;
using ReviewerApp.Interfaces;
using ReviewerApp.Repository;

namespace ReviewerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<SeedData>();




            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IPokemanRepository, PokemanRepository>();
            
            
            
            
            
            
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );




            var app = builder.Build();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                SeedData(app);

            }
            void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
                using(var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<SeedData>();
                    service.SeedDataContext();
                }
            }
            


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}