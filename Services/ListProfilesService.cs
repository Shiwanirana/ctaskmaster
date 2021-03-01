using System;
using ctaskmaster.Models;
using ctaskmaster.Repositories;

namespace ctaskmaster.Services
{
  public class ListProfilesService
  {
    private readonly ListProfilesRepository _repo;
    private readonly ListsRepository _lr;
    public ListProfilesService(ListProfilesRepository repo, ListsRepository lr)
    {
      _repo = repo;
      _lr = lr;
    }

    internal void Create(ListProfile lr, string id)
    {
      Listy list = _lr.GetById(lr.ListId);
      if (list == null)
      {
        throw new Exception("Invalid Id");
      }
      if (list.CreatorId != id)
      {
        throw new NotAuthorized("Not The Owner of this List");
      }
      _repo.Create(lr);
    }

    internal void Delete(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
  }
}