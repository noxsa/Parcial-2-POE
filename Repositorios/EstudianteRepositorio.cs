using ProyectoNotas.Clases;
using RepoDb;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace ProyectoNotas.Repositorios
{
    public class EstudianteRepositorio
    {
        private readonly string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        public void Insertar(Estudiante e)
        {
            using (var connection = new SqlConnection(conexion))
            {
                connection.Insert(e);
            }
        }

        public void Actualizar(Estudiante e)
        {
            using (var connection = new SqlConnection(conexion))
            {
                connection.Update(e);
            }
        }

        public IEnumerable<Estudiante> ObtenerTodos()
        {
            using (var connection = new SqlConnection(conexion))
            {
                return connection.QueryAll<Estudiante>();
            }
        }

        public Estudiante ObtenerPorId(int id)
        {
            using (var connection = new SqlConnection(conexion))
            {
                return connection.Query<Estudiante>(id).FirstOrDefault();
            }
        }

        public void Eliminar(int id)
        {
            using (var connection = new SqlConnection(conexion))
            {
                connection.Delete<Estudiante>(id);
            }
        }
    }
}
