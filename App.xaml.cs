using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoApp2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.DemoDBEntities Context = new Entities.DemoDBEntities();
        public static Entities.Users authUser = null; //0 - guest; 1 - admin; 2 - client; 3 - manager
        public static bool CheckRights(int role)
        {
            if (authUser.UserRoles.UserRole_id == role)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
