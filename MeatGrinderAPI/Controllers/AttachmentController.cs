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
    public class AttachmentController : ApiController
    {
        [MyAuthorize]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Attachment attachment)
        {
            try
            {
                int returnValue = AttachmentService.Attachments_Insert(attachment);

                Attachment returnData = AttachmentService.Attachments_Select(id: returnValue)[0];

                return Ok(returnData);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Attachment> attachments = AttachmentService.Attachments_Select(id: id);
                if (attachments == null || attachments.Count == 0)
                {
                    return BadRequest("id does not exist.");
                }

                Attachment attachment = attachments[0];
                return Ok(attachment);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult GetTaskAttachments(int task_ID)
        {
            try
            {
                List<Attachment> attachments = AttachmentService.Attachments_Select(task_ID: task_ID);
                if (attachments == null || attachments.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                return Ok(attachments);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize]
        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int returnValue = AttachmentService.Attachments_Delete(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
    }
}
