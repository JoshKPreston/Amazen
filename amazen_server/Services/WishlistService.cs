using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class WishlistService
  {
    private readonly WishlistRepository _wishlistRepository;

    public WishlistService(WishlistRepository wishlistRepository)
    {
      _wishlistRepository = wishlistRepository;
    }

    public IEnumerable<Wishlist> Get(Profile userInfo)
    {
      return _wishlistRepository.Get(userInfo);
    }

    public Wishlist GetOne(int id)
    {
      return _wishlistRepository.GetOne(id);
    }

    public Wishlist Create(Wishlist newWishlist)
    {
      newWishlist.Id = _wishlistRepository.Create(newWishlist);
      return newWishlist;
    }

    internal Wishlist Edit(Wishlist data, string userId)
    {
      Wishlist original = _wishlistRepository.GetOne(data.Id);
      if (original == null)
      {
        throw new Exception("Cannot find wishlist with that <Id>");
      }
      if (original.CreatorId != userId)
      {
        throw new Exception("Invalid product creator");
      }
      _wishlistRepository.Edit(data);
      return _wishlistRepository.GetOne(data.Id);
    }
  }
}