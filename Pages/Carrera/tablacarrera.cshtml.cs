using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.Data;
using sistema_academico.Servicio;
using sistema_academico.Models;

namespace sistema_academico.Pages.Carrera
{
    public class tablacarreramodel : PageModel
    {
        private readonly ServicioCarrera _servicioCarrera;

        public List<sistema_academico.Models.Carrera> ListaMostrarCarrera;

        public tablacarreramodel(ServicioCarrera servicioCarrera)
        {
            _servicioCarrera = servicioCarrera;
        }

        public void OnGet()
        {
            ListaMostrarCarrera = _servicioCarrera.ObtenerTodos();
        }
    }
}  
