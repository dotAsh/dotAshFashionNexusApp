using dotAshFashionNexus.Service;
namespace dotAshFashionNexus.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var useInMemoryDatabase = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");
            var connectionString = builder.Configuration.GetConnectionString("DefaultSQLConnection");


            builder.Services.AddMemoryCache();
            builder.Services.AddAutoMapper(typeof(MappingConfig));
            builder.Services.RegisterServiceDependencies(connectionString, useInMemoryDatabase);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || !app.Environment.IsDevelopment())
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
