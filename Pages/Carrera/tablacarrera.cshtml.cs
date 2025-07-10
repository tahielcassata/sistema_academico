using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.Data;
using sistema_academico.Services;
using sistema_academico.Models;

namespace sistema_academico.Pages.Carrera
{
    public class tablacarreramodel : PageModel
    {
        public List<sistema_academico.Models.Carrera> ListaMostrarCarrera;
        public void OnGet()
        {
            ListaMostrarCarrera = ServicioCarrera.ObtenerCarreras();
        }
    }
}  