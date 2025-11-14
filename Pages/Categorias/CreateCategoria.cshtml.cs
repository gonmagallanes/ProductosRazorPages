using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductosRazor.AccesoDatos;
using ProductosRazor.Models;
using ProductosRazor.Repositories;
using ProductosRazor.Services;

namespace ProductosRazor.Pages.Categorias
{
    public class CreateCategoriaModel : PageModel
    {
        [BindProperty]
        public Categoria Categoria { get; set; }
        private readonly CategoryService _categoryService;
		public CreateCategoriaModel()
		{
			IAccesoDatos<Categoria> accesoDatos = new AccesoDatos<Categoria>("Categorias");
			IAccesoDatos<Producto> accesoDatosProductos = new AccesoDatos<Producto>("Productos");
			IRepository<Producto> productoRepository = new JsonRepository<Producto>(accesoDatosProductos);
			IRepository<Categoria> categoriaRepository = new JsonRepository<Categoria>(accesoDatos);
			_categoryService = new CategoryService(categoriaRepository, productoRepository);
		}
		public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = _categoryService.CreateCategory(Categoria);

            if (!result)
            {
                ModelState.AddModelError("Categoria.NombreCategoria", "La categoría ya existe.");
                return Page();
			}
			return RedirectToPage("IndexCategorias");
		}
	}
}
