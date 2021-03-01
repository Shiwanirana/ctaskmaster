using System;
using System.Collections.Generic;
using ctaskmaster.Models;
using ctaskmaster.Repositories;

namespace ctaskmaster.Services
{
  public class ListsService
  {
    private readonly ListsRepository _repo;
    public ListsService(ListsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Listy> GetAll()
    {
      // FIXME Should not be able to get any and all Listys
      return _repo.GetAll();
    }

    internal Listy GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Listy Create(Listy newList)
    {
      return _repo.Create(newList);
    }

    internal Listy Edit(Listy editList)
    {
      var data = GetById(editList.Id);
      editList.Title = editList.Title != null ? editList.Title : data.Title;
      return _repo.Edit(editList);
    }

    internal Listy Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return data;
    }

    internal IEnumerable<ListProfileViewModel> GetListsByProfileId(string id)
    {
      IEnumerable<ListProfileViewModel> data = _repo.GetListsByProfileId(id);
      return data;
    }
  }
}