using Microsoft.AspNetCore.Http.Extensions;
using Orleans;
using Orleans.Hosting;


namespace ForkAI.ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services
                 .AddReverseProxy()
                 .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

            // Adicionar serviços necessários
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Host.UseOrleans(siloBuilder =>
            {
                siloBuilder.UseLocalhostClustering();
                siloBuilder.UseDashboard(x => x.HostSelf = true);
            });

           

           
            var app = builder.Build();
            app.Map("/dashboard", x => x.UseOrleansDashboard());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Configurar pipeline HTTP
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapReverseProxy();
            });

            app.Run();

        
        }
    }
}
