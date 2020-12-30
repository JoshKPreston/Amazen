using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class ProductService
    {
      private readonly ProductRepository _productRepository;

      public ProductService(ProductRepository productRepository)
      {
          _productRepository = productRepository;
      }

      public IEnumerable<Product> Get()
      {
        return _productRepository.Get();
      }

      public Product GetOne(int id)
      {
        return _productRepository.GetOne(id);
      }

      public Product Create(Product newProduct)
      {
        newProduct.Id = _productRepository.Create(newProduct);
        return newProduct;
      }

      internal Product Edit(Product data, string userId)
      {
        Product original = _productRepository.GetOne(data.Id);
        if (original == null)
        {
          throw new Exception("Cannot find product with that <Id>");
        }
        if (original.CreatorId != userId)
        {
          throw new Exception("Invalid product creator");
        }
        _productRepository.Edit(data);
        return _productRepository.GetOne(data.Id);
      }
  }
}