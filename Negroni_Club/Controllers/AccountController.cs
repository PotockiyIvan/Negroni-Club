using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain;
using Negroni_Club.Models;

namespace Negroni_Club.Controllers
{
    [Authorize]//Атрибут указывает что этот класс работает только для авторизованных пользователей
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signinMgr)
        {
            //Передаем в конструктор userManager и signInManager чтобы оперировать пользователями
            //в базе данных через контекст
            userManager = userMgr;
            signInManager = signinMgr;
        }
        //Этот атрибут позволяет видеть этот метод незарегестрированным пользователяи
        //Чтобы они могли зарегестрироваться
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());//Передаем в качестве модели в представление LoginViewModel
        }

        /*!!!!!!!!TODO////  ПОНЯТЬ КАК РАБОТАЕТ ЭТОТ СРАНЫЙ МЕТОД!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
        [HttpPost]//Пост версия метода обрабатывает полученные от пользователя данные
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)//Если валидно
            {
                IdentityUser user = await userManager.FindByNameAsync(model.UserName);//ищем по имени
                if (user != null)
                {
                    await signInManager.SignOutAsync();//в принудительном порядке делаем SignOut - выход
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        //Если удачно возвращаем пользователя на страницу с которой он зашел либо если она не была задана ,на главную
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");//Если пользователь не найден - добавляем к модели ошибку
                //информирующую о неверном логине или пароле и отправляем ее обратно
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
