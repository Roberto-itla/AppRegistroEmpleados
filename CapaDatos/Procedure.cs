using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Procedures
    {
        //Creacion de Instancia Privada para utilizar nuestra conexion
        private CapaDatos conexion = new CapaDatos();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();

        //Tabla para leer nuestros datos de la base de datos
        public DataTable Show()
        {
            cmd.Connection = conexion.OpenDb();
            cmd.CommandText = "sp_ShowData";
            cmd.CommandType = CommandType.StoredProcedure;
            read = cmd.ExecuteReader();
            table.Load(read);
            conexion.CloseDb();
            return table;
        }
        //Metodo para insertar datos en la tabla de nuestra base de datos
        public void Insert(string Nombre, string Apellidos, string Cargo)
        {
            cmd.Connection = conexion.OpenDb();
            cmd.CommandText = "sp_AddData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
            cmd.Parameters.AddWithValue("@Cargo", Cargo);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Metodo para modificar los datos de nuestra tabla de la base de datos de (Employees)

        public void Update(int Id_empleados, string Nombre, string Apellidos, string Cargo)
        {
            cmd.Connection = conexion.OpenDb();
            cmd.CommandText = "sp_ModidyData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_empleados", Id_empleados);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
            cmd.Parameters.AddWithValue("@Cargo", Cargo);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Metodo para eliminar un registro de la tabla de la base de datos Employees

        public void Delete(int Id_empleados)
        {
            cmd.Connection = conexion.OpenDb();
            cmd.CommandText = "sp_DeleteData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_empleados", Id_empleados);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

    }

}
