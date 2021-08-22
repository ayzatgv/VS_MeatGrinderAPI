using MeatGrinderAPI.DataAccess;
using MeatGrinderAPI.Helpers;
using MeatGrinderAPI.Models;
using MeatGrinderAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MeatGrinderAPI.Controllers
{
    public class ClusterController : ApiController
    {
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Cluster_VM_Post viewModel)
        {
            try
            {
                int returnValue = ClusterService.Clusters_Insert(new Cluster(viewModel.User_ID, viewModel.Site_ID));

                if (returnValue == -1)
                {
                    return BadRequest("cluster already exists!");
                }

                Cluster_VM_Get returnData = new Cluster_VM_Get(ClusterService.Clusters_Select(returnValue)[0]);

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
                List<Cluster> clusters = ClusterService.Clusters_Select();
                if (clusters == null || clusters.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }
                List<Cluster_VM_Get> viewModels = new List<Cluster_VM_Get>();

                foreach (Cluster cluster in clusters)
                {
                    viewModels.Add(new Cluster_VM_Get(cluster));
                }

                return Ok(viewModels);
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
                List<Cluster> clusters = ClusterService.Clusters_Select(id: id);
                if (clusters == null || clusters.Count == 0)
                {
                    return BadRequest("id does not exist.");
                }

                Cluster_VM_Get viewModel = new Cluster_VM_Get(clusters[0]);

                return Ok(viewModel);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetSites(int id)
        {
            try
            {
                List<Cluster> clusters = ClusterService.Clusters_Select(user_id: id);

                List<Site> sites = new List<Site>();

                if (clusters != null && clusters.Count != 0)
                {
                    foreach (Cluster cluster in clusters)
                    {
                        sites.Add(cluster.Site);
                    }
                }

                return Ok(sites);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize("Manager", "Dispatcher")]
        [HttpPost]
        public IHttpActionResult Put([FromBody] Cluster_VM_Put viewModel)
        {
            try
            {
                int returnValue = ClusterService.Clusters_Update(viewModel.ConvertToModel());

                if (returnValue == -1)
                {
                    return BadRequest("cluster already exists!");
                }

                Cluster_VM_Get returnData = new Cluster_VM_Get(ClusterService.Clusters_Select(id: viewModel.ID)[0]);

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
                int returnValue = ClusterService.Clusters_Delete(id);

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
