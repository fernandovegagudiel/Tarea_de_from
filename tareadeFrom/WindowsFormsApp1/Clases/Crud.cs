using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Clases
{
    using System;
    using System.Data.SqlClient;

    public class Crud
    {

        public string Nombre { get; set; }
        public string Seccion { get; set; }
        public string Correo { get; set; }

        string connectionString = "Server=LAPTOP-O90PA1AO\\SQLEXPRESS;Database=UMGDB;Integrated Security=True; TrustServerCertificate=True;";
        public Crud MostrarInformacion(string carnet)
        {

            Crud crud = new Crud
            {
                Nombre = "No existe",
                Seccion = "No existe",
                Correo = "No existe"
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tb_alumnos WHERE carnet = @carnet";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        crud.Nombre = reader["estudiante"].ToString();
                        crud.Seccion = reader["seccion"].ToString();
                        crud.Correo = reader["email"].ToString();
                    }
                }
                catch (Exception ex)
                {

                    crud.Nombre = "Error";
                    crud.Seccion = "Error";
                    crud.Correo = "Error";
                    Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                }


                connection.Close();

            }

            return crud;
        }



        //INSERTAR DATOS DE LOS ALUMNIOS
        public string InsertarInformacion(string carnet, string nombre, string seccion, string correo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tb_alumnos (carnet, estudiante, seccion, email) VALUES (@carnet, @nombre, @seccion, @correo)";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@seccion", seccion);
                    command.Parameters.AddWithValue("@correo", correo);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return "Registro insertado Correctamente";

                }

                catch (Exception ex)

                {

                    return "Error al insertar el registro : " + ex.Message;
                }
                
                
                
            }

        }


        //ACTUALIZAR DATOS DE LOS ALUMNOS 
        public string ActualizarInformacion(string carnet, string nombre, string seccion, string correo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Tb_alumnos SET estudiante = @nombre, seccion = @seccion, email = @correo WHERE carnet = @carnet";

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@seccion", seccion);
                    command.Parameters.AddWithValue("@correo", correo);

                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

          
                }
                catch (Exception ex)
                {
                    return "Error al actualizar el registro: " + ex.Message;
                }
               
                    connection.Close();
                }
            return "Registro actualizado correctamente ";
            }
        

        public string EliminarInformacion(string carnet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tb_alumnos WHERE carnet = @carnet";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);

                    connection.Open();
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return "Estudiante eliminado correctamente.";
                    }
                    else
                    {
                        return "No se encontró un estudiante con ese carnet.";
                    }
                }
                catch (Exception ex)
                {
                    return "Error al eliminar: " + ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

    }
}





    