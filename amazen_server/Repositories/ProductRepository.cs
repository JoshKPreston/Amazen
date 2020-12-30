using System;
using System.Collections.Generic;
using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
    public class ProductRepository
    {
    private readonly IDbConnection _db;

    public ProductRepository(IDbConnection db)
        {
            _db = db;   
        }

    public IEnumerable<Product> Get()
    {
        string sql = "select * from products";
        return _db.Query<Product>(sql);
    }
    public Product GetOne(int id)
    {
        string sql = "select * from products where id = @id";
        return _db.QueryFirstOrDefault(sql, new { id });
    }

    public int Create(Product newProduct)
    {
        string sql = @"
            insert into products
            (image, category, title, description, price, rating, creatorId)
            values
            (@image, @category, @title, @description, @price, @rating, @creatorId);
            select last_insert_id();";
        return _db.ExecuteScalar<int>(sql, newProduct);
    }

    internal void Edit(Product data)
    {
        string sql = @"
        update products
        set
        image = @image,
        category = @category,
        title = @title,
        description = @description,
        price = @price,
        rating = @rating
        where id = @id";
        _db.Execute(sql, data);
    }

    internal void Delete(int id)
    {
        string sql = "delete from products where id = @id";
        _db.Execute(sql, new { id });
    }
  }
}