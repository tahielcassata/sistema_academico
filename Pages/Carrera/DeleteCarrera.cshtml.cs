using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_academico.Models;
using sistema_academico.Data;

namespace sistema_academico.Pages.Carrera
{
    public class DeleateCarreraModel : PageModel
    {
        [BindProperty]
        public sistema_academico.Models.Carrera CarreraCur { get; set; }
        public void OnGet(int id)
        {
            foreach (var carrera in DatosCompartidos.ListCarreras)
            {
                if (carrera.Id == id)
                {
                    CarreraCur = carrera;
                    break;
                }

            }
        }

        public IActionResult OnPost()
        {
            sistema_academico.Models.Carrera eliminarCarrera = null;

            foreach (var carrera in DatosCompartidos.ListCarreras)
            {
                if (carrera.Id == CarreraCur.Id)
                {
                    eliminarCarrera = carrera;
                    break;
                }
            }

            if (eliminarCarrera != null)
            {
                DatosCompartidos.ListCarreras.Remove(eliminarCarrera);
            }

            return RedirectToPage("/Carrera/tablacarrera");
        }
    }
}


