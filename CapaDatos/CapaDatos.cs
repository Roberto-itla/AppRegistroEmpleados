using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CapaDatos
    {
        //Creacion de cadena de conexion hacia la base de datos de (Employees)
        private SqlConnection conexionDb = new SqlConnection("Data Source=DESKTOP-3IJ3FP4\\SQLEXPRESS01; Initial Catalog=Db_Company; integrated security=true;");

        //Creacion de los metodos que nos sirvan para Conectar o cerrar la conexion hacia la base de datos (Employees)

        //Metodo para abrir la base de datos
        public SqlConnection OpenDb()
        {
            if (conexionDb.State == ConnectionState.Closed)
            {
                conexionDb.Open();
            }
            return conexionDb;
        }
        //metodo para cerrar la base de datos
        public SqlConnection CloseDb()
        {
            if (conexionDb.State == ConnectionState.Open)
            {
                conexionDb.Close();
            }
            return conexionDb;
        }
    }
}
