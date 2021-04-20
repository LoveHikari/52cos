using Com.Cos.Application;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.Filter;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using NLog.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Com.Cos.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加跨域请求
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost", "https://www.microsoft.com");
                });
            });


            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ModelStateValidationAttribute));
                options.Filters.Add(typeof(ExceptionAttribute));
                options.Filters.Add(typeof(AccessAttribute));
            });
            //数据库连接注入
            services.AddEntityFrameworkSqlServer().AddDbContext<CosDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CosSSMSConnString"), b => b.UseRowNumberForPaging()));

            AddScopedService(services);


            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });  //添加版本控制、激活媒体类型版本控制

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "TwBusManagement接口文档",
                    Description = "RESTful API for TwBusManagement",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Alvin_Su", Email = "asdasdasd@outlook.com", Url = "" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Com.Cos.WebApi.xml");
                c.IncludeXmlComments(xmlPath);

                // c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:4537/";
                    options.ApiName = "api1";
                    options.SaveToken = true;
                    //options.AllowedScopes = new string[] {"offline_access"};  //添加额外的scope，offline_access为Refresh Token的获取Scope
                    options.RequireHttpsMetadata = false;
                });
            //添加options
            //services.AddOptions();
            //services.Configure<AppConfig>(Configuration.GetSection(nameof(AppConfig)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TwBusManagement API V1");
                c.ShowRequestHeaders();
            });

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);//这是为了防止中文乱码
            loggerFactory.AddNLog();//添加NLog
            env.ConfigureNLog("nlog.config");//读取Nlog配置文件

            app.UseMvc();

            app.UseExceptionHandler("/Values/Error");



            ////使用IdentityServer4的资源服务并配置
            //app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            //{
            //    Authority = "http://localhost:4537/",
            //    ApiName = "api1",
            //    SaveToken = true,
            //    AllowedScopes = new string[] { "offline_access" },  //添加额外的scope，offline_access为Refresh Token的获取Scope
            //    RequireHttpsMetadata = false
            //});
        }

        private void AddScopedService(IServiceCollection services)
        {
            services.AddScoped<IAdminMemberService, AdminMemberService>();
            services.AddScoped<ICooperationService, CooperationService>();
            services.AddScoped<ICooperationReplyService, CooperationReplyService>();
            services.AddScoped<IDepositControlService, DepositControlService>();
            services.AddScoped<IExchangeService, ExchangeService>();
            services.AddScoped<IExchangeClassService, ExchangeClassService>();
            services.AddScoped<IExchangeEventService, ExchangeEventService>();
            services.AddScoped<IExchangeExamineService, ExchangeExamineService>();
            services.AddScoped<IExchangePersonService, ExchangePersonService>();
            services.AddScoped<IExchangeReplyService, ExchangeReplyService>();
            services.AddScoped<IHotSearchService, HotSearchService>();
            services.AddScoped<IImgService, ImgService>();
            services.AddScoped<ILoginCodeService, LoginCodeService>();
            services.AddScoped<ILogisticService, LogisticService>();
            services.AddScoped<IMailingAddressService, MailingAddressService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IQuickNavigationService, QuickNavigationService>();
            services.AddScoped<IRechargeRecordService, RechargeRecordService>();
            services.AddScoped<IRefundService, RefundService>();
            services.AddScoped<IShipperCompanyService, ShipperCompanyService>();
            services.AddScoped<ISlideService, SlideService>();
            services.AddScoped<ISysParaService, SysParaService>();
            services.AddScoped<ICooperationClassService, CooperationClassService>();
            services.AddScoped<IPostageService, PostageService>();
            services.AddScoped<ICosFileStatService, CosFileStatService>();
            services.AddScoped<IVoucherService, VoucherService>();
            services.AddScoped<ILoginIPService, LoginIPService>();
            services.AddScoped<IIntegralChangeService, IntegralChangeService>();
            services.AddScoped<ILoggingService, LoggingService>();
            services.AddScoped<IMemberRegisterService, MemberRegisterService>();
            services.AddScoped<IVersionNotesService, VersionNotesService>();
        }

    }
}
