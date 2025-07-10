using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.Models;
using sistema_academico.Data;


namespace sistema_academico.Pages.Alumno
{
    public class CreateAlumnoModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public sistema_academico.Models.Alumno Alumnos { get; set; }
        //OnPost() este método se ejecuta cuando se realiza una solicitud HTTP POST
        public IActionResult OnPost()
        {
            if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Email == Alumnos.Email))
            {
                ModelState.AddModelError("Alumnos.Email", "El correo electrónico ya está registrado.");
            }

            if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Dni == Alumnos.Dni))
            {
                ModelState.AddModelError("Alumnos.Dni", "El DNI ya está registrado.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
          
            Alumnos.Id = DatosCompartidos.ObtenerNuevoAlumnoId();
            DatosCompartidos.ListaAlumnos.Add(Alumnos);
            return RedirectToPage("/Alumno/tablaalumnos");
        }
    }
}

