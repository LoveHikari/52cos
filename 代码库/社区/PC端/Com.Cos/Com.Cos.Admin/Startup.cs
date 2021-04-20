using Com.Cos.Application;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Cos.Admin
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

            services.AddEntityFrameworkSqlServer().AddDbContextPool<CosDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CosSSMSConnString"), b => b.UseRowNumberForPaging()));

            AddScopedService(services);

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);


            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                // 因为是后台系统，必须登陆以后才能操作
                options.Filters.Add(new AuthorizeFilter(policy));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            // 使用Authentication中间件
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
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
            services.AddScoped<ILoginIPService, LoginIPService>();
            services.AddScoped<IBackMemberService, BackMemberService>();
        }
    }
}