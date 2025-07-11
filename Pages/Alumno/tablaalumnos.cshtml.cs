using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.AccesoDatos;
using sistema_academico.Data;
using sistema_academico.Models;
using sistema_academico.Repositorio;
using sistema_academico.Repositorios;
using sistema_academico.Services;

//modificar la pija para que tome la interfaz

namespace sistema_academico.Pages.Alumno
{
    public class tablaalumnosmodel : PageModel
    {
        public List<sistema_academico.Models.Alumno> Alumnos { get; set; }

        private readonly ServicioAlumno servicio;
        public tablaalumnosmodel()
        {
            IAccesoDatos<sistema_academico.Models.Alumno> acceso = new AccesoDatos<sistema_academico.Models.Alumno>("Alumno");
            IRepositorio<sistema_academico.Models.Alumno> repo = new RepositorioCrudJson<sistema_academico.Models.Alumno>(acceso);
            servicio = new ServicioAlumno(repo); 
        }
        public void OnGet()
        {
            Alumnos = servicio.ObtenerTodos();
        }


    }
}


