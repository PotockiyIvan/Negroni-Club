using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Negroni_Club.Domain;
using Negroni_Club.Domain.Repositories;
using Negroni_Club.Domain.Repositories.Abstract;
using Negroni_Club.Domain.Repositories.EntityFramework;
using Negroni_Club.Service;
using SixLabors.ImageSharp.Web.DependencyInjection;

namespace Negroni_Club
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
            //���������� ������ �� appsettings.json
            Configuration.Bind("Project", new Config());


            //���������� ������ ���������� ���������� � �������� ��������
            //� ������� ������� ����������,� ���� ����������� ������� ��� �������
            //��� ����� ����� ������� ����� ������� ���������� ����������
            //���� ����� ����������� �������� ��� ����,����� ����� ��������� ������������ 
            //����� ���� ���������� ��� ��� ���� ������,����� ���������� asp net core ���� 
            //�������� ��� � ���� � ���� ��������.
            services.AddTransient<IDishRepository, EFDishRepository>();
            services.AddTransient<IDishesCategoryRepository, EFDishesCategoryRepository>();
            services.AddTransient<IDishesCategoryRepository, EFDishesCategoryRepository>();
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<ITitleImageRepository, EFTitleImageRepository>();
            services.AddTransient<ITeammateRepository, EFTeammateRepository>();
            services.AddTransient<DataManager>();


            //���������� �������� �� � ��������� ��������� ��� ���������� sql server � � �������� ���������
            //�������� ������ ����������� ,������� ������� ��������� � appsettings.json(����� �� ���������� �� � �� ���������)
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));


            //����������� identity �������
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            //����������� authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "NegroniClubAuth";//�������� Cookie
                options.Cookie.HttpOnly = true;//�������� ������� cookie ����������� �� ���������� �������
                options.LoginPath = "/account/login";//���� � ����������� � �������� login ��� ����������� ��� ������ cookie
                options.AccessDeniedPath = "/account/accessdenied";//���� � ������ ������� �������
                options.SlidingExpiration = true;
            });



            /*����������� �������� ����������� ��� AdminArea ,���� � ���
              ��� �� ������� �� ������������ ���� �����,� ������ ���� ��� ����
              �� ������������ � ������� ������ � AdminArea*/
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //!!!!!!!!!���������� ��������� ������������ � ������������� MVC!!!!!!!!!!
            services.AddControllersWithViews(x =>
            {
                //��������� ���������� ��� AdminArea
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })

            //���������� ������������� � asp.net core 3.0
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddImageSharp();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //!!!!!!! ������� ����������� middleware ����� �����,������ ��������� � ������ �������!!!!!!!!
            //�������� ����������� � �������������� ������ ���� ���������� ����� ����������� routing 
            //�� �� ����������� ����������� ��������� UseEndpoints

            //���� �� � �������� ����������,������� ������ ��� �� ������ 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseImageSharp();
            //���������� ������������� ����������� ������ (css,js � ��)
            app.UseStaticFiles();

            app.UseRouting();

            //���������� ����
            app.UseCookiePolicy();

            //���������� ��������������
            app.UseAuthentication();

            //���������� �����������
            app.UseAuthorization();

            //������������� ������ ��� �������� (���������)
            app.UseEndpoints(endpoints =>
            {
                //������� ��� ��������������
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                //��������� �������
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
