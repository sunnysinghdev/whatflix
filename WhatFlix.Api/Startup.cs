using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
//using FileContextCore;

using Microsoft.OpenApi.Models;

namespace WhatFlix.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //foreach(var keyval in configuration.AsEnumerable()){
                //Console.WriteLine("{0} > {1}",keyval.Key, keyval.Value );
            //}
            //foreach(var keyval in Configuration){
                //Console.WriteLine("{0} > {1}",Configuration["AzureCosmosDB:EndPointUrl"], Configuration["AzureCosmosDB:PrimaryKey"] );
            //}
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddControllers();
            services.AddDbContextPool<DataAccessLayer.WhatFlix.MovieContext>(options => {
            //options.UseModel(Cache.Movies_cache);
            options.UseInMemoryDatabase("sunny");
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo  { Title = "Awesome API", Version = "v1" });
            });
            //services.AddScoped<ICovid19DbContext, Covid19DbContext>();
            services.AddScoped<Persistance.IMovieRepositry, DataAccessLayer.WhatFlix.MovieRepository>();
            services.AddScoped<Persistance.ICreditRepository, DataAccessLayer.WhatFlix.CreditRepository>();
            services.AddScoped<Persistance.IUnitOfWork, DataAccessLayer.WhatFlix.UnitOfWork>();
            services.AddScoped<Service.IMovieService, Service.MovieService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseStatusCodePagesWithReExecute("/Error/StatusHandler");

            }
            else{
                //app.UseStatusCodePagesWithReExecute("/Error/StatusHandler");
            }
            //app
            //app.UseHttpsRedirection();
            //----------index.html-----------------
            app.UseDefaultFiles();
            app.UseStaticFiles();

           

            //-------------------------------------

            app.UseMvc();
            //app.UseRouting();

            //app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
