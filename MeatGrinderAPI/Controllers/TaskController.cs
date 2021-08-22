using MeatGrinderAPI.DataAccess;
using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using MeatGrinderAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace MeatGrinderAPI.Controllers
{
    public class TaskController : ApiController
    {
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Task_VM_Post viewModel)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                int returnValue = TaskService.Tasks_Insert(viewModel.ConvertToModel(MyToken.GetUserID(token)));

                Task_VM_Get returnData = new Task_VM_Get(TaskService.Tasks_Select(id: returnValue)[0]);

                return Ok(returnData);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";
                int roleid = MyToken.GetRoleID(token);

                List<Task> tasks;
                if (roleid == 3)
                {
                    tasks = TaskService.Tasks_Select(user_ID: MyToken.GetUserID(token));
                }
                else
                {
                    tasks = TaskService.Tasks_Select();
                }
                if (tasks == null || tasks.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                List<Task_VM_Get> viewModels = new List<Task_VM_Get>();
                foreach (Task task in tasks)
                {
                    viewModels.Add(new Task_VM_Get(task));
                }

                return Ok(viewModels);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Task> tasks = TaskService.Tasks_Select(id: id);
                if (tasks == null || tasks.Count == 0)
                {
                    return BadRequest("id does not exist.");
                }


                Task_VM_Get viewModel = new Task_VM_Get(tasks[0]);

                return Ok(viewModel);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize]
        [HttpPost]
        public IHttpActionResult Search([FromBody] Task_VM_Search viewModel)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                int roleid = MyToken.GetRoleID(token);

                List<Task> tasks;

                if (roleid == 3)
                    tasks = TaskService.Tasks_Search(Username: MyToken.GetUsername(token), Category_Name: viewModel.Category, Site_Name: viewModel.Site, WO: viewModel.WO, TT: viewModel.TT, Status: viewModel.Status);
                else
                    tasks = TaskService.Tasks_Search(Username: viewModel.FME, Category_Name: viewModel.Category, Site_Name: viewModel.Site, WO: viewModel.WO, TT: viewModel.TT, Status: viewModel.Status);

                if (tasks == null || tasks.Count == 0)
                {
                    return BadRequest("id does not exist.");
                }

                List<Task_VM_Get> returnData = new List<Task_VM_Get>();
                foreach (Task task in tasks)
                {
                    returnData.Add(new Task_VM_Get(task));
                }

                return Ok(returnData);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult Count()
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                int roleid = MyToken.GetRoleID(token);

                Task_VM_Count returnData;

                if (roleid == 3)
                    returnData = TaskService.Tasks_Count(user_id: MyToken.GetUserID(token));
                else
                    returnData = TaskService.Tasks_Count();

                return Ok(returnData);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize()]
        [HttpGet]
        public IHttpActionResult GetMyTasks()
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                List<Task> tasks = TaskService.Tasks_Select(user_ID: MyToken.GetUserID(token));
                if (tasks == null || tasks.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                List<Task_VM_Get> viewModels = new List<Task_VM_Get>();

                foreach (Task task in tasks)
                {
                    viewModels.Add(new Task_VM_Get(task));
                }

                return Ok(viewModels);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Put([FromBody] Task_VM_Put viewModel)
        {
            try
            {
                int returnValue = TaskService.Tasks_Update(viewModel.ConvertToModel());

                if (returnValue != 0)
                {
                    return BadRequest("Unknown error");
                }

                Task_VM_Get returnData = new Task_VM_Get(TaskService.Tasks_Select(viewModel.ID)[0]);

                return Ok(returnData);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
        [MyAuthorize]
        [HttpPost]
        public IHttpActionResult Status([FromBody] Task_VM_Status viewModel)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                List<Task> tasks = TaskService.Tasks_Select(id: viewModel.ID);
                if (tasks == null || tasks.Count == 0)
                {
                    return BadRequest("id does not exist.");
                }
                if (tasks[0].Task_Assigned_To.ID != MyToken.GetUserID(token))
                {
                    return BadRequest("task is not assigned to you.");
                }

                Task task = tasks[0];
                if (!string.IsNullOrEmpty(viewModel.Task_Status))
                {
                    if (viewModel.Task_Status == "Open")
                    {
                        task.Date_Completed = "";
                        task.Task_Status = viewModel.Task_Status;

                    }
                    else if (viewModel.Task_Status == "Complete")
                    {
                        task.Date_Completed = DateTime.Now.Date.ToString("d");
                        task.Task_Status = viewModel.Task_Status;
                    }
                }

                int returnValue = TaskService.Tasks_Update(task);

                if (returnValue != 0)
                {
                    return BadRequest("Unknown error");
                }

                Task_VM_Get returnData = new Task_VM_Get(TaskService.Tasks_Select(id: viewModel.ID)[0]);

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
                int returnValue = TaskService.Tasks_Delete(id);

                if (returnValue != 0)
                {
                    return BadRequest("Unknown error.");
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
