using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductosRazor.AccesoDatos;
using ProductosRazor.Models;
using ProductosRazor.Repositories;
using ProductosRazor.Services;

namespace ProductosRazor.Pages.Categorias
{
    public class DeleteCategoriaModel : PageModel
    {
        [BindProperty]
        public Categoria Categoria { get; set; }
        private readonly CategoryService _categoryService;
		public DeleteCategoriaModel()
		{
			IAccesoDatos<Categoria> accesoDatos = new AccesoDatos<Categoria>("Categorias");
            IAccesoDatos<Producto> accesoDatosProductos = new AccesoDatos<Producto>("Productos");
            IRepository<Producto> productoRepository = new JsonRepository<Producto>(accesoDatosProductos);
			IRepository<Categoria> categoriaRepository = new JsonRepository<Categoria>(accesoDatos);
            _categoryService = new CategoryService(categoriaRepository, productoRepository);
		}
		public IActionResult OnGet(int id)
        {
            var categoria = _categoryService.GetCategoryById(id);
            if (categoria is null)
            {
                return RedirectToPage("IndexCategorias");
			}

            Categoria = categoria;
            return Page();
		}

        public IActionResult OnPost()
        {
			Categoria = _categoryService.GetCategoryById(Categoria.Id);

			bool result = _categoryService.DeleteCategory(Categoria.Id);

            if (!result) 
            {
                ModelState.AddModelError(string.Empty, "No se puede eliminar la categoria porque tiene productos asociados.");
                return Page();
			}
            return RedirectToPage("IndexCategorias");
		}
	}
}
