using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

public class ProductService
{
    private readonly ApplicationDbContext _context;
    private readonly ProductSettings _productSettings;

    public ProductService(ApplicationDbContext context, IOptions<ProductSettings> productSettings)
    {
        _context = context;
        _productSettings = productSettings.Value;
    }

    public List<Category> GetCategories() => _context.Categories.ToList();
    public List<Supplier> GetSuppliers() => _context.Suppliers.ToList();

    public List<Product> GetProducts()
    {
        var query = _context.Products.Include(p => p.Category).Include(p => p.Supplier).AsQueryable();

        if (_productSettings.MaxProducts > 0)
        {
            query = query.Take(_productSettings.MaxProducts);
        }

        return query.ToList();
    }

    public Product GetProductById(int id) => _context.Products.Include(p => p.Category).Include(p => p.Supplier).FirstOrDefault(p => p.ProductID == id);

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
}
