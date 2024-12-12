using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace EB_Persona_Test
{
    public static class TestData
    {
        public static int Id { get; set; } = 0;
        public static string Nombre { get; set; } = "Juan";
        public static string Apellido { get; set; } = "Bonilla";
        public static string Identificacion { get; set; } = "012345678";
        public static string Correo { get; set; } = "email@test.dot";
        public static string Profesion { get; set; } = "Ingeniero en sistemas";
        public static string EstadoCivil { get; set; } = "Soltero";
        public static Server Servidor { get; set; } = new Server();
        public static ITestOutputHelper OutPut { get; set; }

        public class Server
        {
            public string Host { get; set; }
            public string Schema { get; set; }
            public string User { get; set; }
            public string Pass { get; set; }
            public int Port { get; set; }

            public Server()
            {
                Host = "localhost";
                Schema = "test";
                User = "test";
                Pass = "test";
                Port = 1;
            }
        }
    }
}
