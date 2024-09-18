using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Npgsql;
using Personal_Project.DAO;

namespace Personal_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connection = builder.Configuration.GetConnectionString("PostgreDB");
            builder.Services.AddScoped(provider => new NpgsqlConnection(connection));


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
                options.AddPolicy("FrontEndClient", builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
            });


            builder.Services.AddScoped<IPersonalDao, PersonalImpl>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "Images")),
                RequestPath = "/static/images"
            });

            app.UseAuthorization();
            app.UseCors("FrontEndClient");


            app.MapControllers();

            app.Run();
        }
    }
}
