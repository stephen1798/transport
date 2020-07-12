using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zajecia_07._04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityDetailsController : ControllerBase
    {
        private readonly SaleRepository _repo;

        public CityDetailsController(SaleRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {

            //  var res = _repo.GetSaleByCountriyBetweenDate();
            return "OK1";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return id.ToString();
        }

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
        public void Delete(int id)
        {
        }
    }
}