using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ctaskmaster.Models;
using ctaskmaster.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Ctaskmaster.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly ListsService _ls;
    public ProfilesController(ProfilesService ps, ListsService ls)
    {
      _ps=ps;
      _ls =ls;
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfileById(string id)
    {
      try{
      return Ok(_ps.GetProfileById(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/Lists")]
    [Authorize]
    public ActionResult<IEnumerable<ListProfileViewModel>> GetListsByProfileId(string id)
    {
      try
      {
        IEnumerable<ListProfileViewModel> lists = _ls.GetListsByProfileId(id);
        return Ok(lists);
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}