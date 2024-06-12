using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using platform.empty.Container;

namespace platform.empty.API
{
    /// <summary>
    /// Project Start Operations
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration Interface
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Startup Ctor
        /// </summary>
        public Startup()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var environmentNamePath = string.IsNullOrEmpty(environmentName) ? "" : environmentName + ".";
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentNamePath}json", optional: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            //RepositoryModule.AddDbContext(services, Configuration);
            services.AddHttpContextAccessor();

            //LoggingModule.AddLogging(Configuration);
            //CacheModule.AddCache(Configuration);
            //services.AddSingleton<IRedisAdapter, RedisOperator>();

            services.AddControllers(/*options => options.Filters.Add<ValidateModelAttribute>()*/);

            //services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>  
            //{
            //    options.Authority = Configuration["Token:Endpoint"];
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = false
            //    };
            //});

            services.AddMvc().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    return new BadRequestObjectResult("");
                };
            });

            //services.AddApiVersioning(setupAction =>
            //{
            //    setupAction.AssumeDefaultVersionWhenUnspecified = true;
            //    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
            //    setupAction.ReportApiVersions = true;
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HR API",
                    Version = "v1",
                    Description = "F2D HR Api Integration",
                    Contact = new OpenApiContact()
                    {
                        Email = "ifkizilkaya@gmail.com",
                        Name = "F2D 🌟"
                    }
                });
                //c.OperationFilter<AuthorizeCheckOperationFilter>();
                //c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
                { 
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });

            //services.AddDefaultHealthCheckers<MPIDbContext>(Configuration);
        }

        /// <summary>
        /// Configure service dependencies
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var container = app.ApplicationServices.GetAutofacRoot();

            Bootstrapper.SetContainer(container);
            //CacheModule.SetContainer(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/error");
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR API");

                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

                c.EnableDeepLinking();
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            //app.UseDefaultHealthCheckers();
        }

        /// <summary>
        /// Configure Modules
        /// </summary>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            Bootstrapper.RegisterModules(builder);
        }
    }
}
