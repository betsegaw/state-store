using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using state_store.Configuration;
using System.Linq;

namespace state_store.Controllers
{
    [Route("api/{token}/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
/*         // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
        } */

        // api/TOKENVALUE/events/name
        [HttpGet("name")]
        public string Get(string token) 
        {
            if (token != StateStoreConfiguration.StateStoreConfigurationInstance.Token) 
            {
                return null;
            }

            return StateStoreConfiguration.StateStoreConfigurationInstance.Name;
        }

        // https://localhost:5001/api/MY_UNIQUE_TOKEN/events/usercalled
        [HttpGet("{eventName}")]
        public bool? Get(string token, string eventName) 
        {
            if (token != StateStoreConfiguration.StateStoreConfigurationInstance.Token) 
            {
                return null;
            }

            var matchingConditions = StateStoreConfiguration.StateStoreConfigurationInstance.ConditionConfigurations.Where(x => x.URL == eventName);

            if (matchingConditions.Count() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
