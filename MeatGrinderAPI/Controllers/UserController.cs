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
    public class UserController : ApiController
    {
        [MyAuthorize("Manager")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] User_VM_Register viewModel)
        {
            try
            {
                int returnValue = UserService.Users_Insert(viewModel.ConvertToModel());

                if (returnValue == -1)
                {
                    return BadRequest("Username already exists in database.");
                }

                User_VM_Get returnData = new User_VM_Get(UserService.Users_Select(id: returnValue)[0]);

                return Ok(returnData);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Login([FromBody] User_VM_Login viewModel)
        {
            try
            {
                List<User> users = UserService.Users_Select(username: viewModel.Username);
                if (users == null || users.Count == 0)
                {
                    return BadRequest("Username does not exist in database.");
                }

                User user = users[0];
                viewModel.Password = user.HashedPassword(viewModel.Password);

                if (user.Password != viewModel.Password)
                {
                    return BadRequest("Please input the correct password.");
                }

                return Ok(MyToken.TokenGeneration(user));
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
        [MyAuthorize]
        [HttpPost]
        public IHttpActionResult ChangePassword([FromBody] User_VM_ChangePassword viewModel)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                User user = UserService.Users_Select(id: MyToken.GetUserID(token))[0];

                viewModel.OldPassword = user.HashedPassword(viewModel.OldPassword);

                if (user.Password != viewModel.OldPassword)
                {
                    return BadRequest("your password is wrong!");
                }

                user.Password = user.HashedPassword(viewModel.NewPassword);

                int returnValue = UserService.Users_Update(user);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize("Manager")]
        [HttpPost]
        public IHttpActionResult Put([FromBody] User_VM_EditUser viewModel)
        {
            try
            {
                User user = UserService.Users_Select(id: viewModel.ID)[0];
                if (!string.IsNullOrEmpty(viewModel.Password))
                {
                    viewModel.Password = user.HashedPassword(viewModel.Password);
                }

                int returnValue = UserService.Users_Update(viewModel.ConvertToModel());

                if (returnValue == -1)
                {
                    return BadRequest("Username already exists in database.");
                }

                User_VM_Get returnData = new User_VM_Get(UserService.Users_Select(id: viewModel.ID)[0]);

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
                int roleid = 0;

                ClaimsPrincipal claimsPrincipal = MyToken.TokenDecryption(token);
                if (claimsPrincipal != null)
                {
                    roleid = Convert.ToInt32(claimsPrincipal.Claims.Where(c => c.Type == "roleid").Single().Value);
                }

                List<User> users = UserService.Users_Select(role_id: roleid);
                List<User_VM_Get> viewModels = new List<User_VM_Get>();
                if (users == null || users.Count == 0)
                {
                    return BadRequest("table is empty");
                }
                foreach (User user in users)
                {
                    if (user != null)
                        viewModels.Add(new User_VM_Get(user));
                }

                return Ok(viewModels);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
        [MyAuthorize("Manager")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                List<User> users = UserService.Users_Select(id: id);
                if (users == null || users.Count == 0)
                {
                    return BadRequest("table is empty");
                }

                User_VM_Get viewModel = new User_VM_Get(users[0]);

                return Ok(viewModel);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
    }
}
