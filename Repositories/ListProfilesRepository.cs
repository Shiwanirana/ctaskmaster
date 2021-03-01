using System;
using System.Data;
using Dapper;
using ctaskmaster.Models;

namespace ctaskmaster.Repositories
{
  public class ListProfilesRepository
  {
    private readonly IDbConnection _db;

    public ListProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal void Create(ListProfile lp)
    {
      string sql = @"
      INSERT INTO listProfiles
      (profileId, listId)
      VALUES
      (@ProfileId, @ListId);";
      _db.Execute(sql, lp);
    }
    internal ListProfile GetById(int id)
    {
      string sql = "SELECT * FROM listProfiles WHERE id = @id;";
      return _db.QueryFirstOrDefault<ListProfile>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM listProfiles WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}