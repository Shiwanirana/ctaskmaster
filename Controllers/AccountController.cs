using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using ctaskmaster.Models;
using ctaskmaster.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ctaskmaster.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class AccountController : ControllerBase
  {
    private readonly ProfilesService _ps;
    public AccountController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
       Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
       return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}