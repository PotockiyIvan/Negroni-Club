using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Service
{
    //Класс обертка, свойства класса соответствуют свойствам из класса appsetings.json
    //Класс создан для более удобной работы с конфигурацией нашего приложения в коде программы
    //Не прийдется полностью писать строку подключения и прочее,можно просто манипулировать полями
    //Далее этот файл добавляется как файл конфигурации приложения в файле sturtup.cs
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static string CompanyName { get; set; }
        public static string CompanyPhone { get; set; }
        public static string CompanyPhoneShort { get; set; }
        public static string CompanyEmail { get; set; }
    }
}
