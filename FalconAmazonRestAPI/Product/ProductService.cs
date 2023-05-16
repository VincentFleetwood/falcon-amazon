using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
public class ProductService
    {
    private readonly IDatabaseContext _dbContext;

    public ProductService(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ProductItemDTO>GetAllProductsAsync()
    {
        var product = await _dbContext.tblProducts.FindAsync();
        var productItemDTO = new ProductItemDTO()
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            ProductPrice = product.ProductPrice,
            Category = product.Category
        };
            return productItemDTO;
    }

    public async Task<ProductItemDTO> GetProductFromIDAsync(int productID)
    {
        var product = await _dbContext.tblProducts.FindAsync(productID);

        var productItemDTO = new ProductItemDTO()
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            ProductPrice = product.ProductPrice,
            Category = product.Category
        };

        return productItemDTO;
    }

    public async Task<IResult> AddNewProductAsync(Product product)
    {
        _dbContext.tblProducts.Add(product);

        await _dbContext.SaveChangesToDatabaseAsync();

        return Results.Ok(product);
    }

    public async Task<Product> UpdateProductFromIDAsync(int productID, Product updatedProduct)
    {
        var product = await _dbContext.tblProducts.FindAsync(productID);

        product.ProductID = updatedProduct.ProductID;
        product.ProductName = updatedProduct.ProductName;
        product.ProductDescription = updatedProduct.ProductDescription;
        product.ProductPrice = updatedProduct.ProductPrice;
        product.Category = updatedProduct.Category;

        await _dbContext.SaveChangesToDatabaseAsync();

        return product;
    }

    public async Task<Product> DeleteProductFromIDAsync(int productID)
    {
        var product = await _dbContext.tblProducts.FindAsync(productID);

        _dbContext.tblProducts.Remove(product);

        await _dbContext.SaveChangesToDatabaseAsync();

        return product;
    }

}


