using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teleware.Data;
using Teleware.Foundation.Data;
using Teleware.Foundation.Diagnostics;

namespace Playground.AspNet.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ICRUDRepository<TestEntity> _repo;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger, ICRUDRepository<TestEntity> repo)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            _logger.Trace(0, "msg");
            var foo = _repo.Query().FirstOrDefault();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}