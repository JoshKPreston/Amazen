using System;
using System.Collections.Generic;
using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
  public class WishlistRepository
  {
    private readonly IDbConnection _db;

    public WishlistRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Wishlist> Get(Profile userInfo)
    {
      string sql = "select * from wishlists where creatorId = @creatorId";
      return _db.Query<Wishlist>(sql, new { userInfo.Id });
    }

    public Wishlist GetOne(int id)
    {
      string sql = "select * from wishlists where id = @Id";
      return _db.QueryFirstOrDefault<Wishlist>(sql, new { id });
    }

    public int Create(Wishlist newWishlist)
    {
      string sql = @"
        insert into wishlists
        (title, creatorId)
        values
        (@title, @creatorId);
        select last_insert_id();";
      return _db.ExecuteScalar<int>(sql, newWishlist);
    }

    internal void Edit(Wishlist data)
    {
      string sql = @"
        update wishlists
        set
        title = @title
        where id = @id";
      _db.Execute(sql, data);
    }

    internal void Delete(int id, Profile userInfo)
    {
      string sql = "delete from wishlists where id = @id and creatorId = @creatorId";
      _db.Execute(sql, new { id, creatorId = userInfo.Id });
    }
  }
}