using ProyectoNotas.Repositorios;

namespace ProyectoNotas.UoW
{
    public class UnidadDeTrabajo
    {
        public EstudianteRepositorio Estudiantes { get; private set; }

        public UnidadDeTrabajo()
        {
            Estudiantes = new EstudianteRepositorio();
        }
    }
}
