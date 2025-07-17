


using sistema_academico.Models;
using sistema_academico.Repositorios;

namespace sistema_academico.Servicio
{
    public class ServicioCarrera
    {
        private static string path = "Data/Carreras.json";
        private readonly IRepositorio<Carrera> _repo;
        public ServicioCarrera(IRepositorio<Carrera> repo)
        {
            _repo = repo;
        }
        public List<Carrera> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }
        public Carrera? BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }
        public void Editar(Carrera carrera)
        {
            _repo.Editar(carrera);
        }
        public void EliminarPorId(int id)
        {
            _repo.EliminarPorId(id);
        }
        public void Agregar(Carrera Carrera)
        {
            _repo.Agregar(Carrera);
        }
    }
}