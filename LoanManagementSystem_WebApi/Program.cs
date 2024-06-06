using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem_WebApi
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


            //--- Here we need to add Middle wares 

            //For The connection string and the Db Context 
            builder.Services.AddDbContext<LmsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LMS_ConnectionString")));


            //Then we need to add the Scoped For The Repository 
            builder.Services.AddScoped<ILoginRepository,LoginRepository>();


            var app = builder.Build();

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
