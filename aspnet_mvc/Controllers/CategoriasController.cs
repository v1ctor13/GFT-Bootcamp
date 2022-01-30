using Microsoft.AspNetCore.Mvc;
using aspnet_mvc.Models;
using System.Data.Entity;

namespace aspnet_mvc.Controllers {

    public class CategoriasController : Controller {

        private readonly Context _context;

        public CategoriasController(Context context) {
            _context = context;
        }

        // GET: USUARIOS
        public async Task<IActionResult> Index() {
            return View(await _context.Categorias.ToListAsync());
        }

    }

}