using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Docs.Model;

namespace Docs.ViewModel
{
    public static class Titler
    {
        public static string NormalTitle<E>(this E e)
        {
            if (e is Account)
                return "Учетная запись пользователя";
            return "";
        }
        public static string DeleteTitle<E>(this E e)
        {
            if (e is Account)
                return "Удалени учетной записи пользователя";
            return "";
        }
        public static string SearchTitle<E>(this E e)
        {
            if (e is Account)
                return "Поиск учетных записей пользователей";
            return "";
        }
        public static string ListTitle<E>(this E e)
        {
            if (e is Account)
                return "Учетные записи пользователей";
            return "";
        }
    }
}
