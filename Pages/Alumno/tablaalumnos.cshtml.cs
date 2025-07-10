using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.Data;
using sistema_academico.Models;


namespace sistema_academico.Pages.Alumno
{
    public class tablaalumnosmodel : PageModel
    {
        public List<sistema_academico.Models.Alumno> listaAlumnosMotrar = new List<sistema_academico.Models.Alumno>();
        public void OnGet()
        {
            listaAlumnosMotrar = DatosCompartidos.ListaAlumnos;
        }
    }
}


