using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductosRazor.AccesoDatos;
using ProductosRazor.Models;
using ProductosRazor.Repositories;
using ProductosRazor.Services;

namespace ProductosRazor.Pages.Categorias
{
    public class IndexCategoriasModel : PageModel
    {
        public List<Categoria> ListaCategorias;
        private readonly CategoryService _categoryService;
        public IndexCategoriasModel()
        {
			IAccesoDatos<Categoria> accesoDatos = new AccesoDatos<Categoria>("Categorias");
			IAccesoDatos<Producto> accesoDatosProductos = new AccesoDatos<Producto>("Productos");
			IRepository<Producto> productoRepository = new JsonRepository<Producto>(accesoDatosProductos);
			IRepository<Categoria> categoriaRepository = new JsonRepository<Categoria>(accesoDatos);
			_categoryService = new CategoryService(categoriaRepository, productoRepository);
		}
		public void OnGet()
        {
            ListaCategorias = _categoryService.GetAllCategories();
		}
    }
}
