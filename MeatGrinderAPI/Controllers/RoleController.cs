using MeatGrinderAPI.DataAccess;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MeatGrinderAPI.Controllers
{
    public class RoleController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Role> roles = RoleService.Roles_Select();
                if (roles == null || roles.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                return Ok(roles);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Role> roles = RoleService.Roles_Select(id: id);
                if (roles == null || roles.Count == 0)
                {
                    return BadRequest("id does not exist.");
                }

                Role role = roles[0];

                return Ok(role);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
    }
}
