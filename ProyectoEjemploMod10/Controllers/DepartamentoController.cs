using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEjemploMod10.Models;
using X.PagedList;

namespace ProyectoEjemploMod10.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly ContextoDeDatos contexto;

        //Inyeccion del conecto de datos
        public DepartamentoController(ContextoDeDatos contexto)
        {
            this.contexto = contexto;
        }

        //Accion que muestra la pagina principal para adminstrar Departamentos
        public async Task <IActionResult> Index(int? page)
        {
            int pageSize = 1; // número de registros por pagina 
            int pageNumber = (page ?? 3); // número de pagina actual,  predeterminado 1 si entra vacio

            var departamentos = await contexto.Departamentos.OrderBy(d=> d.Nombre).ToPagedListAsync(pageNumber, pageSize); 

            return View(departamentos);
        }

        //Accion que muestra los detalles de los registros
        public async Task<IActionResult> Details(int id){
            var departamento= await contexto.Departamentos.
                 SingleOrDefaultAsync(d => d.Id == id);
                 return View(departamento);
        }


        //accion que muestra el formulario para crear un nuevo departamento
        public IActionResult Create()
        {
            return  View();
        }

        //accion que recibe los datos del formulario para guardarlos ene la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departamento departamento){
            if (ModelState.IsValid)
            {
                contexto.Departamentos.Add(departamento);
                await contexto.SaveChangesAsync();
                return  RedirectToAction("Index");
            } else {
                return View(departamento);
            }
        }
    }
}
