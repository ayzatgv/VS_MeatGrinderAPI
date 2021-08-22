using MeatGrinderAPI.DataAccess;
using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeatGrinderAPI.Controllers
{
    public class Work_OrderController : ApiController
    {
        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult GetOpen()
        {
            try
            {
                List<Work_Order> results;

                results = Work_OrderService.Work_Orders_Select_Open();
                
                if (results == null || results.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                
                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        public IHttpActionResult GetOpen7Day()
        {
            try
            {
                List<Work_Order> results;

                results = Work_OrderService.Work_Orders_Select_Open7Day();

                if (results == null || results.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }


                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        public IHttpActionResult GetOpenSLApass()
        {
            try
            {
                List<Work_Order> results;

                results = Work_OrderService.Work_Orders_Select_OpenSLApass();

                if (results == null || results.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }


                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        public IHttpActionResult GetCompletePass()
        {
            try
            {
                List<Work_Order> results;

                results = Work_OrderService.Work_Orders_Select_CompletePass();

                if (results == null || results.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }


                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
    }
}
