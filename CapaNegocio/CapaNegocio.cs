using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio
    {
        //Creacion de instancia 
        private Procedures procedur = new Procedures();

        //Creamos una tabla nueva 

        public DataTable ShowPeople()
        {
            DataTable table = new DataTable();
            table = procedur.Show();
            return table;
        }

        //Creacion de los metodos para el crud

        public void InsertData(string Nombre, string Apellidos, string Cargo)
        {
            procedur.Insert(Nombre, Apellidos, Cargo);
        }

        public void UpdateData(int Id_empleados, string Nombre, string Apellidos, string Cargo)
        {
            procedur.Update(Convert.ToInt32(Id_empleados), Nombre, Apellidos, Cargo);
        }

        public void DeleteData(int Id_empleados)
        {
            procedur.Delete(Convert.ToInt32(Id_empleados));
        }

    }
}
