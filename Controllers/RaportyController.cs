using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Zajecia_07._04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaportyController : ControllerBase
    {
        private readonly SaleRepository _repo;

        RaportyController(SaleRepository repo)
        {
            _repo = repo;
        }

        // GET api/region/3
        [HttpGet("{wielkoscPremii}")]
        public ActionResult<IEnumerable<RaportPremia>> Get(int wielkoscPremii)
        {
            var res = _repo.RaportPremia(wielkoscPremii);
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
        public void Delete(int id)
        {
        }
    }
}