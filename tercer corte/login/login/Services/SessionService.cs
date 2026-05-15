using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Services
{
    public static class SessionService
    {
        public static string Usuario { get; private set; }
        public static string Rol { get; private set; }
        public static bool IsAuthenticated => Usuario != null;

        public static void Session(string usuario, string rol)
        {
            Usuario = usuario;
            Rol = rol;
        }
    }
}
