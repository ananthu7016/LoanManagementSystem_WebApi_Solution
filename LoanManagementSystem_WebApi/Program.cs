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
            builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
            builder.Services.AddScoped<IAdminRepository,AdminRepository>(); 



            //Then we need to Add middleware to AllowAllOrgins so that we will not Encouneter with Cors Error when integrating Angular 
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("AllowAllOrgin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });


            var app = builder.Build();
            app.UseCors("AllowAllOrgin");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
