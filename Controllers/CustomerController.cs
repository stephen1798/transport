using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zajecia_07._04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly SaleRepository _repo;

        public CustomerController(SaleRepository repo)
      {
          _repo=repo;
      }
      
        // GET api/region/3
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<Customers>> Get(int Id)
        {         
          var res = _repo.GetCostumersByCity(Id);
          return res;
        }

        // GET api/values/5

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
          _repo.DeleteCustomerById(id);
        }
    }
}