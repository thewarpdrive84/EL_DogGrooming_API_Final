using EL_DogGrooming_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EL_DogGrooming_API.Controllers
{
    [RoutePrefix("api/Service")]
    public class ServiceController : ApiController
    { 
        private static List<Service> Services = new List<Service>
        {
            new Service(){Code=101, Description = "Wash and Cut", Price = 40},
            new Service(){Code=102, Description = "Anal Glands", Price = 5},
            new Service(){Code=103, Description = "Flea Treatment", Price = 5}
        };

        //GET all services
        [HttpGet]
        [Route("all")]
        public IEnumerable<Service> Get()
        {
            return Services;
        }

        //GET services by code
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var foundService = Services.FirstOrDefault(i => i.Code == id);
            if (foundService != null)
            {
                return Ok(foundService);
            }
            else
            {
                return NotFound();
            }
        }

        //GET all descriptions of services
        [HttpGet]
        [Route("descriptions")]
        public IEnumerable<String> descriptions()
        {
            return Services.Select(c => c.Description).ToList();
        }

        //POST add a service
        [HttpPost]
        [Route("AddService")]
        public IHttpActionResult AddService(Service newService)
        {
            var foundService = Services.FirstOrDefault(i => i.Code == newService.Code);
            if (foundService == null)
            {
                Services.Add(newService);
                return Ok();
            }
            else
            {
                return BadRequest("Service already exists");
            }
        }

        //PUT update a service
        [HttpPut]
        [Route("UpdateService")]
        public IHttpActionResult UpdateService(Service newService)
        {
            var foundService = Services.FirstOrDefault(i => i.Code == newService.Code);
            if (foundService == null)
            {
                return BadRequest("Service doesn't exist");

            }
            else
            {
                foundService.Price = newService.Price;
                return Ok();
            }
        }

    }
}