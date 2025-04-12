using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases
{
    public class CrudTareas
    {

       public  string id_tarea { get; set; } 
       public  string nota1 { get; set; }
       public  string nota2 { get; set; }
       public  string nota3 { get; set; }
       public  string nota4 { get; set; }

        string connectionString = "Server=LAPTOP-O90PA1AO\\SQLEXPRESS;Database=UMGDB;Integrated Security=True; TrustServerCertificate=True;";
        public CrudTareas MostrarInformacion(string carnet)
        {
            CrudTareas crud = new CrudTareas
            {
                id_tarea = "No existe",
                nota1 = "No existe",
                nota2 = "No existe",
                nota3 = "No existe",
                nota4 = "No existe"
            };



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tareas WHERE carnet = @carnet";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        crud.id_tarea = reader["id_tarea"].ToString();
                        crud.nota1 = reader["nota1"].ToString();
                        crud.nota2 = reader["nota2"].ToString();
                        crud.nota3 = reader["nota3"].ToString();
                        crud.nota4 = reader["nota4"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    crud.id_tarea = "Error ";
                    crud.nota1 = "Error";
                    crud.nota2 = "Error";
                    crud.nota3 = "Error";
                    crud.nota4 = "Error";

                    Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                }


                connection.Close();

            }

            return crud;
        }

        //insertar 
        public string InsertarInformacion(string carnet, string nota1, string nota2 , string nota3, string nota4)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tareas (carnet,nota1,nota2,nota3,nota4) VALUES (@carnet, @nota1, @nota2,@nota3,@nota4)";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    command.Parameters.AddWithValue("@nota1",nota1);
                    command.Parameters.AddWithValue("@nota2",nota2);
                    command.Parameters.AddWithValue("@nota3", nota3);
                    command.Parameters.AddWithValue("@nota4", nota4);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return "Registro insertado Correctamente";

                }

                catch (Exception ex)

                {

                    return "Error al insertar el registro : " + ex.Message;
                }
                connection.Close();
            }
        }
    }
}
