using KuberMICManager.Core.Application;
using KuberMICManager.Core.Application.HelperSerivces;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Infrastructure.DataAccess;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace KuberMICManager.Client.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            System.Console.WriteLine("[1] Startup::Constructor()");
            Configuration = configuration;
        }

        // [1] This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            System.Console.WriteLine("[2] Startup::ConfigureServices()");

            // user consent for non - essential cookies pop - up message
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Get configuration
            var appIdentitySettings = Configuration.GetSection("AppIdentitySettings");
            var identitySettings = appIdentitySettings.Get<AppIdentitySettings>();
            var appSettings = Configuration.GetSection("AppSettings");
            var settings = appSettings.Get<AppSettings>();

            //// Add our Config object so it can be injected
            services.Configure<AppIdentitySettings>(appIdentitySettings);
            services.Configure<AppSettings>(appSettings);
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            // Application Settings
            //AppSettings appSettings = new AppSettings();
            //Configuration.Bind("FileUpload", appSettings.FileUpload);
            //services.AddSingleton(appSettings);

            // Set up the in-memory session - Will not work when we have multiple server instances
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(identitySettings.Lockout.DefaultLockoutTimeSpanInMins);
                options.Cookie.HttpOnly = true;
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KuberMICManagerAuthContext"),options => options.CommandTimeout(120)));
            services.AddDbContext<MICDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KuberMICManagerDataContext")));

            // user security database context
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = identitySettings.User.RequireUniqueEmail;

                // Password settings
                options.Password.RequireDigit = identitySettings.Password.RequireDigit;
                options.Password.RequiredLength = identitySettings.Password.RequiredLength;
                options.Password.RequireLowercase = identitySettings.Password.RequireLowercase;
                options.Password.RequireNonAlphanumeric = identitySettings.Password.RequireNonAlphanumeric;
                options.Password.RequireUppercase = identitySettings.Password.RequireUppercase;

                // Lockout settings
                options.Lockout.AllowedForNewUsers = identitySettings.Lockout.AllowedForNewUsers;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identitySettings.Lockout.DefaultLockoutTimeSpanInMins);
                options.Lockout.MaxFailedAccessAttempts = identitySettings.Lockout.MaxFailedAccessAttempts;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // include logging
            services.AddLogging();

            // custom routes
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
                    options.Conventions.AuthorizeAreaFolder("Identity", "/account/manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/account/logout");
                });

            // Map policies to claims for authorization
            services.AddAuthorization(options =>
            {
                // NOTE: If you add/update Claims, you have to update enum: Common.UserClaimType
                options.AddPolicy("CanAdmin", policy => policy.RequireClaim("CanAdmin", "true"));
                options.AddPolicy("CanViewLoans", policy => policy.RequireClaim("CanViewLoans", "true"));
                options.AddPolicy("CanViewInvestments", policy => policy.RequireClaim("CanViewInvestments", "true"));
                options.AddPolicy("CanViewUserProfile", policy => policy.RequireClaim("CanViewUserProfile", "true"));
            });

            // Cookies
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = "KuberMICManagerCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(identitySettings.Lockout.DefaultLockoutTimeSpanInMins);
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            // inject UserLog repo
            services.AddTransient<IUserLogRepository, UserLogRepository>();
            services.AddTransient<IRenewalRepository, RenewalRepository>();
            services.AddTransient<ISiteSettingRepository, SiteSettingRepository>();
            services.AddTransient<IPostalCodeRepository, PostalCodeRepository>();
            services.AddTransient<IMICPortfolioHistoryRepository, MICPortfolioHistoryRepository>();

            services.AddTransient<ISharedUnitOfWork, SharedUnitOfWork>();
            services.AddTransient<IPartnerUnitOfWork, PartnerUnitOfWork>();
            services.AddTransient<ILoanUnitOfWork, LoanUnitOfWork>();
            services.AddTransient<ITrustAccountUnitOfWork, TrustAccountUnitOfWork>();

            services.AddTransient<ILoanService, LoanService>();
            services.AddTransient<IPartnerService, PartnerService>();
            services.AddTransient<ITrustAccountService, TrustAccountService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IPortfolioHistoryService, PortfolioHistoryService>();

            services.AddTransient<IGoogleAPISerivce, GoogleAPISerivce>();
            services.AddTransient<IExportService, ExportService>(); 
            services.AddTransient<IMSWordService, MSWordService>();

            // Stored Procedure to get certificate with share details
            services.AddTransient<ISPRepository, SPRepository>();

            services.AddMemoryCache();
            services.AddRazorPages();
        }

        // [2] This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMemoryCache cache, ISiteSettingRepository siteSettingRepository)
        {
            System.Console.WriteLine("[3] Startup::Configure()");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Read site settings from db and store it in cache for later use
            IEnumerable<SiteSetting> siteSettings = siteSettingRepository.FindAllAsync().Result;
            cache.Set("siteSettings", siteSettings);
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}