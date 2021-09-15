using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negroni_Club.Models;

namespace Negroni_Club.Domain
{
    //Класс представляющий контекст базы данных, здесь мы настраиваем связь с бд и определяем стартовые объекты бд
    public class AppDbContext : IdentityDbContext<IdentityUser>//IdentityUser - системный класс пользователя,используем ,чтобы не создавать новый
    {
        //Забыл эту строчку и пауэр шелл выдал ошибку No database provider has been configured for this DbContext. A provider can be configured by overriding the DbContext.OnConfiguring method or by using AddDbContext on the application service provider. If AddDbContext is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Создаем таблицы в бд соответствующие нашим классам
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<Teammate> Teammates { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishesСategory> DishesCategories { get; set; }
        public DbSet<TitleImage> TitleImages { get; set; }
        public DbSet<GalleryAlbum> GalleryAlbums { get; set; }
        public DbSet<AlbumPhoto> AlbumPhotos { get; set; }
        public DbSet<Negroni_Club.Models.LoginViewModel> LoginViewModel { get; set; }

        //Заполняем базы данных стартовыми значениями
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Проверяем нет ли такой сущности в базе и создаем
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password"),
                SecurityStamp = string.Empty
            });
            //Связываем администратора с его ролью
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });
            //Здесь создаются текстовые поля которые в последствии будут меняться администратором
            //В примере это контакты услуги и главная страница,!!!TODOO!!!Сделать эти поля для данного проекта1
            //Реализовать изменения в графах:О нас,Специальные предложения,Меню,Команда,Галерея,Блог,Футер
            //modelBuilder.Entity<TextField>().HasData(new TextField
            //{
            //    Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
            //    CodeWord = "PageIndex",
            //    Title = "Главная"
            //});
            //modelBuilder.Entity<TextField>().HasData(new TextField
            //{
            //    Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
            //    CodeWord = "PageServices",
            //    Title = "Наши услуги"
            //});
            //modelBuilder.Entity<TextField>().HasData(new TextField
            //{
            //    Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
            //    CodeWord = "PageContacts",
            //    Title = "Контакты"
            //});


            //Заполняем базы данных стартовыми значениями
            //Создаем элементы в бд,кодовые слова нужны для удобства в работе,по ним мы будем обрашаться к данным объектам через html формы
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("1813e8ab-e0b9-44c0-addd-babf0cf80abd"),
                CodeWord = "Banner",
                //Title = "Negroni Club",
                Subtitle = "Место для громкой фразы",
                //Text = "Значение задается в формате (первый:настоящий:бар:за:полярным:кругом)"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("36b3ced4-93eb-477b-81ce-c9ebe0e6b1fe"),
                CodeWord = "AboutUs",
                Title = "О нас"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("eadc6d86-d236-4dea-8b61-fdec8b2fcdc0"),
                CodeWord = "Events",
                Title = "События"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ec3fdb67-de7f-41f6-9504-90d2043a5dfc"),
                CodeWord = "Menu",
                Title = "Меню"
            });

            //modelBuilder.Entity<TextField>().HasData(new TextField
            //{
            //    Id = new Guid("1ba3410e-5ef4-452d-b59e-6172ade55dbb"),
            //    CodeWord = "OurTeam",
            //    Title = "Наша Команда"
            //});

            //modelBuilder.Entity<TextField>().HasData(new TextField
            //{
            //    Id = new Guid("ab6a1906-5024-4cb2-9111-82b36171d994"),
            //    CodeWord = "Gallery",
            //    Title = "Галерея"
            //});

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ff9730cb-964e-46e2-b070-fa0e33c4ac89"),
                CodeWord = "Blog",
                Title = "Блог"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8ad6e41f-e37e-428f-a713-3d77e3ddf862"),
                CodeWord = "Footer",
                Title = "Футер"
            });

            modelBuilder.Entity<TitleImage>().HasData(
              new TitleImage
              {
                  Id = new Guid("013bf5e9-0b38-4ec2-90ae-b7060c8cbbce"),
                  CodeWord = "BannerBackground",
                  TextFieldId = new Guid("1813e8ab-e0b9-44c0-addd-babf0cf80abd"),
                  TitleImagePath = "banner.jpg"
              },
              new TitleImage
              {
                  Id = new Guid("463385f4-3b78-43ec-9849-7363397df7a3"),
                  CodeWord = "AboutUsBigTitleImage",
                  TextFieldId = new Guid("36b3ced4-93eb-477b-81ce-c9ebe0e6b1fe"),
                  TitleImagePath = "about-main.jpg"
              },
              new TitleImage
              {
                  Id = new Guid("39b8284c-6b8e-4ab7-ade3-bd42ae778267"),
                  CodeWord = "AboutUsSmallTitleImage",
                  TextFieldId = new Guid("36b3ced4-93eb-477b-81ce-c9ebe0e6b1fe"),
                  TitleImagePath = "about-inset.jpg"
              },
              new TitleImage
              {
                  Id = new Guid("9b85efd3-9e21-4af7-9baf-60dcddb8e1ba"),
                  CodeWord = "EventsBigTitleImage",
                  TextFieldId = new Guid("eadc6d86-d236-4dea-8b61-fdec8b2fcdc0"),
                  TitleImagePath = "afisha.jpg"
              },
              new TitleImage
              {
                  Id = new Guid("8a291424-53cb-49a6-a09f-a93ca5d462ca"),
                  CodeWord = "EventsSmallTitleImage",
                  TextFieldId = new Guid("eadc6d86-d236-4dea-8b61-fdec8b2fcdc0"),
                  TitleImagePath = "afishasmall.jpg"
              });

            
           

            modelBuilder.Entity<DishesСategory>().HasData(
                new DishesСategory
                {
                    Id = new Guid("e045f9d3-fee2-42a5-8578-129603b15473"),
                    Title = "Пасты",
                    IndexNumber = 1
                },
                new DishesСategory
                {
                    Id = new Guid("7f17720a-132b-4921-8e95-db3f40ea3c2d"),
                    Title = "Салаты",
                    IndexNumber = 2
                },
                new DishesСategory
                {
                    Id = new Guid("bdde9343-5528-415e-9b41-11d333bcf5b2"),
                    Title = "Бургеры",
                    IndexNumber = 3
                },
                new DishesСategory
                {
                    Id = new Guid("4ea95bf7-cf8a-404d-91f0-939d61c861bd"),
                    Title = "Стейки",
                    IndexNumber = 4
                },
                new DishesСategory
                {
                    Id = new Guid("2f76c06a-a672-4ba3-a10d-96a04581f343"),
                    Title = "Горячее",
                    IndexNumber = 5
                },
                new DishesСategory
                {
                    Id = new Guid("4a4a8e00-4337-45fa-aa88-dca265975308"),
                    Title = "Шотландский Виски",
                    IndexNumber = 6
                },
                new DishesСategory
                {
                    Id = new Guid("1dd9aba7-d5be-448a-a555-6ebe6137327a"),
                    Title = "Ирландский Виски",
                    IndexNumber = 7
                },
                new DishesСategory
                {
                    Id = new Guid("7c4d8b49-cc12-4b60-a464-3edce0045d25"),
                    Title = "Японский Виски",
                    IndexNumber = 8
                },
                new DishesСategory
                {
                    Id = new Guid("212282f7-4302-4668-bc27-b43fb4fe792c"),
                    Title = "Американский Виски",
                    IndexNumber = 9
                },
                new DishesСategory
                {
                    Id = new Guid("5694c499-1687-48ce-a60a-1b04e44a8e53"),
                    Title = "Виски",
                    IndexNumber = 10
                },
                new DishesСategory
                {
                    Id = new Guid("e2edbc7e-8764-484a-baf3-89a46f9519a4"),
                    Title = "Джин",
                    IndexNumber = 11
                },
                new DishesСategory
                {
                    Id = new Guid("bc751392-ae59-4914-a4aa-7f24753cb0a6"),
                    Title = "Ром",
                    IndexNumber = 12
                },
                new DishesСategory
                {
                    Id = new Guid("60613bbe-9f22-4e84-83f3-931b461dff38"),
                    Title = "Коньяк",
                    IndexNumber = 13
                },
                new DishesСategory
                {
                    Id = new Guid("7787bc42-f3aa-4873-ad00-f36c71adb341"),
                    Title = "Бренди",
                    IndexNumber = 14
                },
                new DishesСategory
                {
                    Id = new Guid("7b420447-6902-4dc9-8ff9-2652c7bf20f4"),
                    Title = "Текила",
                    IndexNumber = 15
                },
                new DishesСategory
                {
                    Id = new Guid("62a1f1ba-2da7-4c38-b15b-de06701c0de3"),
                    Title = "Водка",
                    IndexNumber = 16
                },
                new DishesСategory
                {
                    Id = new Guid("766275ef-4952-46ec-b06b-63c3a7162641"),
                    Title = "Апперитивы и Биттеры",
                    IndexNumber = 17
                },
                new DishesСategory
                {
                    Id = new Guid("b29e55c8-ecfb-4399-9737-2eab0c2bdf27"),
                    Title = "Игристые Вина",
                    IndexNumber = 18
                },
                new DishesСategory
                {
                    Id = new Guid("70af1f54-e61e-47a8-bc96-80dc1c26b8d8"),
                    Title = "Вина",
                    IndexNumber = 19
                },
                new DishesСategory
                {
                    Id = new Guid("efa7dae2-f142-43c1-a8da-ee4a1e7e04bf"),
                    Title = "Коктейли",
                    IndexNumber = 20
                });
        }
    }
}
