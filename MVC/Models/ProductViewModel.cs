using System.ComponentModel.DataAnnotations;

public class ProductViewModel
{
    public int ProductID { get; set; }

    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string ProductName { get; set; }

    [Required]
    public int? SupplierID { get; set; }

    [Required]
    public int? CategoryID { get; set; }

    [StringLength(20)]
    public string QuantityPerUnit { get; set; }

    [Range(0, double.MaxValue)]
    public decimal UnitPrice { get; set; }

    [Range(0, short.MaxValue)]
    public short UnitsInStock { get; set; }

    [Range(0, short.MaxValue)]
    public short UnitsOnOrder { get; set; }

    [Range(0, short.MaxValue)]
    public short ReorderLevel { get; set; }

    public bool Discontinued { get; set; }
}
