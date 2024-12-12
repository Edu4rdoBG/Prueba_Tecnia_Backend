using System.Data;
using System.Text.Json;
using Amazon.Lambda.Core;
using MySql.Data.MySqlClient;
using EB_Persona_Consultar.Models;

namespace EB_Persona_Consultar.Functions.Data
{
    public static class DataProvider
    {
        public static string sqlConnString = string.Empty;
        static MySqlConnection connection = new MySqlConnection();
        public static bool Execute_sp_select_eb_persona(string filtro, out string mensaje, out List<PersonaModel> lstPersona)
        {

            lstPersona = new List<PersonaModel>();
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
                string jsonFilter = "";
                var objFilter = new
                {
                    Filtrar = filtro == string.Empty ? 0 : 1,
                    Valor = filtro
                };
                jsonFilter = JsonSerializer.Serialize(objFilter);
                LambdaLogger.Log(string.Concat("call sp_select_eb_persona()", DateTime.Now));

                MySqlCommand cmd = new("sp_select_eb_persona", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CkjFiltro", jsonFilter);

                MySqlDataAdapter ada = new(cmd);
                DataTable dt = new();
                ada.Fill(dt);

                foreach (DataRow tPers in dt.Rows)
                {
                    var clb = new PersonaModel()
                    {
                        Id = int.Parse(tPers["nId"].ToString()!),
                        Nombre = tPers["sNombre"].ToString()!,
                        Apellido = tPers["sApellido"].ToString()!,
                        Identificacion = tPers["sIdentificacion"].ToString()!,
                        Correo = tPers["sCorreo"].ToString()!,
                        Profesion = tPers["sProfesion"].ToString()!,
                        EstadoCivil = tPers["sEstadoCivil"].ToString()!
                    };
                    lstPersona.Add(clb);
                }

                mensaje = string.Concat("Se obtuvieron esta cantidad de datos: ", dt.Rows.Count.ToString(), DateTime.Now);
                LambdaLogger.Log(mensaje);
                return true;

            }
            catch (Exception e)
            {
                mensaje = string.Concat("Error: ", e.Message, DateTime.Now);
                LambdaLogger.Log(mensaje);
                return false;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public static bool CreateConn(string HostProxy, string Schema, string SchemaPayCash, string Usr, string Pss, string port)
        {
            LambdaLogger.Log(String.Format("CreateConn: {0}|{1}|{2}|{3}|{4}|{5}|{6}", HostProxy, Schema, SchemaPayCash, Usr, Pss, port, DateTime.Now.ToString()));
            try
            {
                sqlConnString = String.Format("server={0};user={1};database={2};port={3};password={4};SslMode=Required;SslCa=../rds-ca-2019-root.pem", HostProxy, Usr, Schema, port, Pss);
                connection = new MySqlConnection(sqlConnString);
                LambdaLogger.Log(string.Concat("Cadena: ", connection.ConnectionString));
                LambdaLogger.Log(string.Concat("conn.Open()", DateTime.Now));
                connection.Open();
                LambdaLogger.Log(string.Concat("conn.Close()", DateTime.Now));
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                LambdaLogger.Log(string.Concat("Error: ", e.Message, DateTime.Now));
                connection = null;
                sqlConnString = string.Empty;
                return false;
            }

        }
    }
}
