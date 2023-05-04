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
    }
