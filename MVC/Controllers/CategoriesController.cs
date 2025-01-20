using Microsoft.AspNetCore.Mvc;

public class CategoriesController : Controller
{
    private readonly ProductService _productService;

    public CategoriesController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        var categories = _productService.GetCategories();
        return View(categories);
    }
}
