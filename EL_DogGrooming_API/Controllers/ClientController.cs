using EL_DogGrooming_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EL_DogGrooming_API.Controllers
{
    [RoutePrefix("api/Client")]
    public class ClientController : ApiController
    {
        private static List<Client> Clients = new List<Client>
        {
            new Client() { Id = 1, Name = "Esther", DogName = "Josephine", Phone = "0861235555", Email = "esther@firhouse.ie"},
            new Client() { Id = 2, Name = "Nikki", DogName = "Maddie", Phone = "0871234567", Email = "nikki@stepaside.ie"},
            new Client() { Id = 3, Name = "Kyra", DogName = "Miley", Phone = "0862345678", Email = "kyra@dundrum.ie"}

        };

        // GET all clients
        [HttpGet]
        [Route("all")]
        public IEnumerable<Client> Get()
        {
            return Clients;
        }

        //GET clients by id
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var foundLease = Clients.FirstOrDefault(i => i.Id == id);
            if (foundLease != null)
            {
                return Ok(foundLease);
            }
            else
            {
                return NotFound();
            }
        }

        //GET all client names
        [HttpGet]
        [Route("names")]
        public IEnumerable<String> names()
        {
            return Clients.Select(c => c.Name).ToList();
        }

        //POST add client
        [HttpPost]
        [Route("AddClient")]
        public IHttpActionResult AddClient(Client newClient)
        {
            var foundClient = Clients.FirstOrDefault(i => i.Id == newClient.Id);
            if (foundClient == null)
            {
                Clients.Add(newClient);
                return Ok();
            }
            else
            {
                return BadRequest("Client already exists");
            }
        }

        //PUT update a client's dog name
        [HttpPut]
        [Route("UpdateClient")]
        public IHttpActionResult UpdateClient(Client newClient)
        {
            var foundClient = Clients.FirstOrDefault(i => i.Id == newClient.Id);
            if (foundClient == null)
            {
                return BadRequest("Client doesn't exist");

            }
            else
            {
                foundClient.DogName = newClient.DogName;
                return Ok();
            }
        }

        //DELETE delete a client
        [HttpDelete]
        [Route("DeleteClient/{id}")]
        public string DeleteClient(int id, [FromBody]Client newClient)
        {
            if (newClient != null)
            {
                try
                {
                    var foundClient = Clients.FirstOrDefault(i => i.Id == newClient.Id);
                    if (foundClient != null)
                    {
                        foundClient.Id = newClient.Id;
                        Clients.Remove(foundClient);
                        return "Client deleted";
                    }
                    else
                    {
                        return ("Failed to find client!");
                    }

                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return "Invalid input!";
            }
        }
    }
}