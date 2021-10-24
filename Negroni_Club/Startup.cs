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
            //подключаем конфиг из appsettings.json
            Configuration.Bind("Project", new Config());


            //Подключаем нужный функционал приложения в качестве сервисов
            //В методах указаны интерфейсы,и если понадобится сменить орм систему
            //Это можно будет сделать здесь щаменив реализацию интерфейса
            //Само такое подключение делается для того,чтобы через внедрение зависимостей 
            //Можно было подключать тот или иной сервис,чтобы преложение asp net core само 
            //находило что к чему и куда внедрить.
            services.AddTransient<IDishRepository, EFDishRepository>();
            services.AddTransient<IDishesCategoryRepository, EFDishesCategoryRepository>();
            services.AddTransient<IDishesCategoryRepository, EFDishesCategoryRepository>();
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<ITitleImageRepository, EFTitleImageRepository>();
            services.AddTransient<ITeammateRepository, EFTeammateRepository>();
            services.AddTransient<IGalleryAlbumRepository, EFGalleryAlbumRepository>();
            services.AddTransient<IAlbumPhotoRepository, EFAlbumPhotoRepository>();
            services.AddTransient<DataManager>();


            //Подключаем контекст БД в свойствах указываем что используем sql server и в качестве аргумента
            //передаем строку подключения ,которая заранее прописана в appsettings.json(чтобы не копировать ее и не ошибиться)
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));


            //настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "NegroniClubAuth";//Название Cookie
                options.Cookie.HttpOnly = true;//Свойства делющее cookie недоступным на клиентской стороне
                options.LoginPath = "/account/login";//Путь к контроллеру и действию login для авторизации при помощи cookie
                options.AccessDeniedPath = "/account/accessdenied";//Путь в случае запрета доступа
                options.SlidingExpiration = true;
            });



            /*настраиваем политику авторизации для AdminArea ,суть в том
              что мы требуем от пользователя роль админ,и только имея эту роль
              он авторизуется и получит доступ в AdminArea*/
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //!!!!!!!!!Добавленна поддержка контроллеров и представлений MVC!!!!!!!!!!
            services.AddControllersWithViews(x =>
            {
                //Добавляем соглашение для AdminArea
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })

            //Выставляем совместимость с asp.net core 3.0
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddImageSharp();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //!!!!!!! порядок регистрации middleware очень важен,ВСЕГДА ПОДКЛЮЧАЙ В НУДНОМ ПОРЯДКЕ!!!!!!!!
            //Например авторизация и аутентификация должны быть подключены после подключения routing 
            //но до конкретного определения маршрутов UseEndpoints

            //Если мы в процессе разработки,покажет полную инф об ошибке 
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
            //Подключаем использование статических файлов (css,js и тд)
            app.UseStaticFiles();

            app.UseRouting();

            //Подключаем куки
            app.UseCookiePolicy();

            //Подключаем аутентификацию
            app.UseAuthentication();

            //Подключаем авторизацию
            app.UseAuthorization();

            //регистриуруем нужные нам маршруты (ендпоинты)
            app.UseEndpoints(endpoints =>
            {
                //Маршрут для администратора
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                //Дефолтеый маршрут
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
