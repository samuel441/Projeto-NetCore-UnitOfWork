using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UOWRepository.Data;
using UOWRepository.Data.Context;
using UOWRepository.Data.Repositories;

namespace UOWRepository
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //config quando a contreller não consegue serializer o objeto
            //Error: System.Text.Json.JsonException: A possible object cycle was detected which is not supported. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.

            //Isso acontece por causa da relação bidirecional entre o modelo de dados quando se trata de serialização JSON. | Em uma aplicacao Real não retorna as entidades do banco, sempre criar uma modelView,DTO
            //ReferenceLoopHandling atualmente não tem suporte no serializador System.Text.Json
            services.AddControllers()
              .AddNewtonsoftJson(options =>
              {
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
              });

            //services.AddControllers();

            services.AddDbContext<AplicacaoContext>(p =>
             p.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=UoW; Integrated Security=true"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
