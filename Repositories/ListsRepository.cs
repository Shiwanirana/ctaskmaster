using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using ctaskmaster.Models;

namespace ctaskmaster.Repositories
{
  public class ListsRepository
  {
    private readonly IDbConnection _db;

    public ListsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Listy> GetAll()
    {
      string sql = @"
      SELECT * FROM lists";
      return _db.Query<Listy>(sql);
    }


    // REVIEW[epic=Populate] add the creator to the object
    internal Listy GetById(int id)
    {
      string sql = @" 
      SELECT 
      lis.*,
      pr.*
      FROM lists lis
      JOIN profiles pr ON lis.creatorId = pr.id
      WHERE id = @id";
      return _db.Query<Listy, Profile, Listy>(sql, (listy, profile) =>
      {
        listy.Creator = profile;
        return listy;
      }, new { id }, splitOn: "id").FirstOrDefault();

    }

    internal Listy Create(Listy newList)
    {
      string sql = @"
      INSERT INTO lists 
      (creatorId, title) 
      VALUES 
      (@CreatorId, @Title);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newList);
      newList.Id = id;
      return newList;
    }

    internal Listy Edit(Listy updated)
    {
      string sql = @"
        UPDATE lists
        SET
         title = @Title
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    // REVIEW[epic=many-to-many] This sql will add the relationship id to a Listy, as the PartyPartyMemberViewModel
    // REVIEW[epic=Populate] and get the creator
    internal IEnumerable<ListProfileViewModel> GetListsByProfileId(string id)
    {
      string sql = @"
      SELECT
      lis.*,
      lp.id as ListProfileId,
      pr.*
      FROM listprofiles lp
      JOIN lists lis ON lp.listId == lis.id
      JOIN profiles pr ON lis.creatorId = pr.id
      WHERE profileId = @id
      ";
      return _db.Query<ListProfileViewModel, Profile, ListProfileViewModel>(sql, (list, profile) =>
      {
        list.Creator = profile;
        return list;
      }
        , new { id }, splitOn: "id");
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM parties WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}