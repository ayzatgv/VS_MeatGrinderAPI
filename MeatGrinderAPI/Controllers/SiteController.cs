using MeatGrinderAPI.DataAccess;
using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MeatGrinderAPI.Controllers
{
    public class SiteController : ApiController
    {
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Site site)
        {
            try
            {
                int returnValue = SiteService.Sites_Insert(site);

                if (returnValue == -1)
                {
                    return BadRequest("site name already exists!");
                }

                Site returnData = SiteService.Sites_Select(id: returnValue)[0];

                return Ok(returnData);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Site> sites = SiteService.Sites_Select();
                if (sites == null || sites.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                return Ok(sites);
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
                List<Site> sites = SiteService.Sites_Select(id: id);
                if (sites == null || sites.Count == 0)
                {
                    return BadRequest("id does not exist.");
                }

                Site site = sites[0];
                return Ok(site);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Put([FromBody] Site site)
        {
            try
            {
                int returnValue = SiteService.Sites_Update(site);

                if (returnValue == -1)
                {
                    return BadRequest("site name already exists!");
                }

                Site returnData = SiteService.Sites_Select(id: site.ID)[0];

                return Ok(returnData);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int returnValue = SiteService.Sites_Delete(id);

                if (returnValue == -1)
                {
                    return BadRequest("Site is in use in Task Table!");
                }

                if (returnValue == -2)
                {
                    return BadRequest("Site is in use in Cluster Table!");
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
    }
}
