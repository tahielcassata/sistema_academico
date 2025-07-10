using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.Helpers;
using sistema_academico.Services;


namespace sistema_academico.Pages.Carrera
{
    public class CreateCarreraModel : PageModel
    {
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


            ServicioCarrera.AgregarCarrera(Carreras);

            return RedirectToPage("/Carrera/tablacarrera");
        }
    }
}