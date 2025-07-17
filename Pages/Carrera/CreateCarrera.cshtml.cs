using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.AccesoDatos;
using sistema_academico.Helpers;
using sistema_academico.Repositorio;
using sistema_academico.Repositorios;
using sistema_academico.Servicio;


namespace sistema_academico.Pages.Carrera
{
    public class CreateCarreraModel : PageModel
    {
        private readonly ServicioCarrera _servicioCarrera;

        public CreateCarreraModel(ServicioCarrera servicioCarrera)
        {
        
        }

        public List<string> Modalidades { get; set; } = new List<string>();

        [BindProperty]
        public Models.Carrera Carreras { get; set; }

        public void OnGet()
        {
            Modalidades = OpcionesModalidad.lista;
        }

        public IActionResult OnPost()
        {
            Modalidades = OpcionesModalidad.lista;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _servicioCarrera.Agregar(Carreras);

            return RedirectToPage("/Carrera/tablacarrera");
        }
    }
}