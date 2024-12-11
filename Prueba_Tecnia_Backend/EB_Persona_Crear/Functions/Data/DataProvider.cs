using Amazon.Lambda.Core;
using EB_Persona_Crear.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EB_Persona_Crear.Functions.Data
{
    public static class DataProvider
    {
        public static string sqlConnString = string.Empty;
        static MySqlConnection connection = new MySqlConnection();
        public static bool Execute_sp_insert_eb_persona(RequestPersona input, out string mensaje, out PersonaModel persona)
        {

            persona = new PersonaModel();
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();

                LambdaLogger.Log(string.Concat("call sp_insert_eb_persona()", DateTime.Now));

                MySqlCommand cmd = new("sp_insert_eb_persona", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CksNombre", input.Nombre);
                cmd.Parameters.AddWithValue("CksApellido", input.Apellido);
                cmd.Parameters.AddWithValue("CksIdentificacion", input.Identificacion);
                cmd.Parameters.AddWithValue("CksCorreo", input.Correo);
                cmd.Parameters.AddWithValue("CksProfesion", input.Profesion);
                cmd.Parameters.AddWithValue("CksEstadoCivil", input.EstadoCivil);

                MySqlDataAdapter ada = new(cmd);
                DataTable dt = new();
                ada.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = int.Parse(dt.Rows[0]["nId"].ToString()!);

                    if (id > 0)
                    {
                        mensaje = $"Se realizo el insert con exito, Id: {id} {DateTime.Now}";
                        LambdaLogger.Log(mensaje);
                        persona =  new PersonaModel() { 
                            Id = id,
                            Nombre = input.Nombre,
                            Apellido = input.Apellido,
                            Identificacion = input.Identificacion,
                            Correo = input.Correo,  
                            Profesion = input.Profesion,
                            EstadoCivil = input.EstadoCivil
                        };
                        return true;
                    }
                    else
                    {
                        mensaje = $"No se logro realizar el insert, Id: {id} {DateTime.Now}";
                        LambdaLogger.Log(mensaje);
                        return false;
                    }                    
                }
                else
                {
                    mensaje = string.Concat("No se obtuvo respuesta ", DateTime.Now);
                    LambdaLogger.Log(mensaje);
                    return false;
                }

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
