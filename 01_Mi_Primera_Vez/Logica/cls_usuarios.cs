using _01_Mi_Primera_Vez.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Mi_Primera_Vez.Logica
{
    internal class cls_usuarios
    {
        private readonly conexion con = new conexion();

        public bool insertar(dto_usuarios user)
        {
            using (SqlConnection connection = con.obtenerConexion())
            {
                string query = "INSERT INTO Usuarios (Cedula, Nombres, Direccion, Telefono, idPais) VALUES (@Cedula, @Nombres, @Direccion, @Telefono, @idPais)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Cedula", user.Cedula);
                command.Parameters.AddWithValue("@Nombres", user.Nombres);
                command.Parameters.AddWithValue("@Direccion", user.Direccion);
                command.Parameters.AddWithValue("@Telefono", user.Telefono);
                command.Parameters.AddWithValue("@idPais", user.idPais);


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores (más robusto en una aplicación real)
                    Console.WriteLine("Error al insertar: " + ex.Message);
                    return false;
                }
            }
        }

        public bool modificar(dto_usuarios user)
        {
            using (SqlConnection connection = con.obtenerConexion())
            {
                string query = "UPDATE Usuarios SET Cedula = @Cedula, Nombres = @Nombres, Direccion = @Direccion, Telefono = @Telefono, idPais = @idPais WHERE idUsuario = @idUsuario";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Cedula", user.Cedula);
                command.Parameters.AddWithValue("@Nombres", user.Nombres);
                command.Parameters.AddWithValue("@Direccion", user.Direccion);
                command.Parameters.AddWithValue("@Telefono", user.Telefono);
                command.Parameters.AddWithValue("@idPais", user.idPais);
                command.Parameters.AddWithValue("@idUsuario", user.idUsuario);


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores (más robusto en una app real)
                    Console.WriteLine("Error al modificar: " + ex.Message);
                    return false;
                }
            }
        }
        public List<dto_usuarios> Leer()
        {
            List<dto_usuarios> usuarios = new List<dto_usuarios>();
            using (SqlConnection connection = con.obtenerConexion())
            {
                string query = "SELECT * FROM Usuarios";
                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dto_usuarios user = new dto_usuarios();
                        user.idUsuario = (int)reader["idUsuario"];
                        user.Cedula = reader["Cedula"].ToString();
                        user.Nombres = reader["Nombres"].ToString();
                        user.Direccion = reader["Direccion"].ToString();
                        user.Telefono = reader["Telefono"].ToString();
                        user.idPais = (int)reader["idPais"];


                        usuarios.Add(user);
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error al leer: " + ex.Message);

                }
            }
            return usuarios;
        }


        public bool eliminar(int idUsuario)
        {
            using (SqlConnection connection = con.obtenerConexion())
            {
                string query = "DELETE FROM Usuarios WHERE idUsuario = @idUsuario";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error al eliminar: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
