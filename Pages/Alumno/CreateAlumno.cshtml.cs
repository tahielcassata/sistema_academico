using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.AccesoDatos;
using sistema_academico.Data;
using sistema_academico.Models;
using sistema_academico.Repositorio;
using sistema_academico.Repositorios;
using sistema_academico.Services;


namespace sistema_academico.Pages.Alumno
{
    public class CreateAlumnoModel : PageModel


    {
        [BindProperty]
        public sistema_academico.Models.Alumno Alumnos { get; set; }

        private readonly ServicioAlumno servicio;
        public CreateAlumnoModel()
        {
            IAccesoDatos<sistema_academico.Models.Alumno> acceso = new AccesoDatos<sistema_academico.Models.Alumno>("Alumno");
            IRepositorio<sistema_academico.Models.Alumno> repo = new RepositorioCrudJson<sistema_academico.Models.Alumno>(acceso);
            servicio = new ServicioAlumno(repo);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            servicio.Agregar(Alumnos);

            return RedirectToPage("tablaalumnos");
        }

        //OnPost() este método se ejecuta cuando se realiza una solicitud HTTP POST


        //public IActionResult OnPost()
        //{
        //    if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Email == Alumnos.Email))
        //    {
        //        ModelState.AddModelError("Alumnos.Email", "El correo electrónico ya está registrado.");
        //    }

        //    if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Dni == Alumnos.Dni))
        //    {
        //        ModelState.AddModelError("Alumnos.Dni", "El DNI ya está registrado.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    Alumnos.Id = DatosCompartidos.ObtenerNuevoAlumnoId();
        //    DatosCompartidos.ListaAlumnos.Add(Alumnos);
        //    return RedirectToPage("/Alumno/tablaalumnos");
        //}


    }
}

