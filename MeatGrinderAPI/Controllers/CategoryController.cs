using MeatGrinderAPI.DataAccess;
using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using MeatGrinderAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MeatGrinderAPI.Controllers
{
    public class CategoryController : ApiController
    {
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Category_VM_Post viewModel)
        {
            try
            {
                int returnValue = CategoryService.Categories_Insert(new Category(viewModel.Category_Name));

                Category returnData = CategoryService.Categories_Select(returnValue)[0];

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
                List<Category> categories = CategoryService.Categories_Select();
                if (categories == null || categories.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                return Ok(categories);
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
                List<Category> categories = CategoryService.Categories_Select(id: id);
                if (categories == null || categories.Count == 0)
                {
                    return BadRequest("id does not exist.");
                }

                Category category = categories[0];

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Put([FromBody] Category category)
        {
            try
            {
                int returnValue = CategoryService.Categories_Update(category);

                if (returnValue != 0)
                {
                    return BadRequest("update failed!");
                }

                Category returnData = CategoryService.Categories_Select(id: category.ID)[0];

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
                int returnValue = CategoryService.Categories_Delete(id);

                if (returnValue == -1)
                {
                    return BadRequest("Category is in use in Task Table!");
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
