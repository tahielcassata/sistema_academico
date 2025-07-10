using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.Models;
using sistema_academico.Data;


namespace sistema_academico.Pages.Alumno
{
    public class DeleateAlumnoModel : PageModel
    {
        [BindProperty]
        public sistema_academico.Models.Alumno Alumnos { get; set; }
        public void OnGet(int id)
        {
            foreach (var alumno in DatosCompartidos.ListaAlumnos)
            {
                if (alumno.Id == id)
                {
                    Alumnos = alumno;
                    break;
                }

            }
        }

        public IActionResult OnPost()
        {
            sistema_academico.Models.Alumno eliminarAlumno = null;

            foreach (var alumno in DatosCompartidos.ListaAlumnos)
            {
                if (alumno.Id == Alumnos.Id)
                {
                    eliminarAlumno = alumno;
                    break;
                }
            }

            if (eliminarAlumno != null)
            {
                DatosCompartidos.ListaAlumnos.Remove(eliminarAlumno);
            }

            return RedirectToPage("/Alumno/tablaalumnos");
        }
    }
}



