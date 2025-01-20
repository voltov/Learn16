using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetProducts();
        return View(products);
    }

    public IActionResult Create()
    {
        var viewModel = new ProductViewModel
        {
            Categories = _productService.GetCategories(),
            Suppliers = _productService.GetSuppliers()
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProductViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var product = new Product
            {
                ProductName = viewModel.ProductName,
                SupplierID = viewModel.SupplierID,
                CategoryID = viewModel.CategoryID,
                QuantityPerUnit = viewModel.QuantityPerUnit,
                UnitPrice = viewModel.UnitPrice,
                UnitsInStock = viewModel.UnitsInStock,
                UnitsOnOrder = viewModel.UnitsOnOrder,
                ReorderLevel = viewModel.ReorderLevel,
                Discontinued = viewModel.Discontinued
            };
            _productService.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
        viewModel.Categories = _productService.GetCategories();
        viewModel.Suppliers = _productService.GetSuppliers();
        return View(viewModel);
    }

    public IActionResult Edit(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        var viewModel = new ProductViewModel
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            SupplierID = product.SupplierID,
            CategoryID = product.CategoryID,
            QuantityPerUnit = product.QuantityPerUnit,
            UnitPrice = product.UnitPrice,
            UnitsInStock = product.UnitsInStock,
            UnitsOnOrder = product.UnitsOnOrder,
            ReorderLevel = product.ReorderLevel,
            Discontinued = product.Discontinued,
            Categories = _productService.GetCategories(),
            Suppliers = _productService.GetSuppliers()
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ProductViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var product = new Product
            {
                ProductID = viewModel.ProductID,
                ProductName = viewModel.ProductName,
                SupplierID = viewModel.SupplierID,
                CategoryID = viewModel.CategoryID,
                QuantityPerUnit = viewModel.QuantityPerUnit,
                UnitPrice = viewModel.UnitPrice,
                UnitsInStock = viewModel.UnitsInStock,
                UnitsOnOrder = viewModel.UnitsOnOrder,
                ReorderLevel = viewModel.ReorderLevel,
                Discontinued = viewModel.Discontinued
            };
            _productService.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        viewModel.Categories = _productService.GetCategories();
        viewModel.Suppliers = _productService.GetSuppliers();
        return View(viewModel);
    }
}

