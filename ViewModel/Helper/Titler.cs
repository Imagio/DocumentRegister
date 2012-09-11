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
            if (e is Department)
                return "Подразделение";
            if (e is SendingGroup)
                return "Группа рассылки";
            if (e is Employee)
                return "Сотрудник";
            if (e is Monitoring)
                return "Контроль";
            return "Элемент";
        }
        public static string DeleteTitle<E>(this E e)
        {
            return "Удаление элемента";
        }
        public static string SearchTitle<E>(this E e)
        {
            return "Поиск элементов";
        }
        public static string ListTitle<E>(this E e)
        {
            if (e is Account)
                return "Учетные записи пользователей";
            if (e is Department)
                return "Подразделения";
            if (e is SendingGroup)
                return "Группы рассылки";
            if (e is Employee)
                return "Сотрудники";
            if (e is Monitoring)
                return "Виды контроля";
            return "Список элементов";
        }
    }
}
