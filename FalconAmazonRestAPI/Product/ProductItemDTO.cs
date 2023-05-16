    public class ProductItemDTO
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string? Category { get; set; }

        public ProductItemDTO() { }

    public ProductItemDTO(Product product) =>
        (ProductID, ProductName, ProductDescription, ProductPrice, Category) =
        (product.ProductID, product.ProductName, product.ProductDescription, product.ProductPrice, product.Category);
    }
