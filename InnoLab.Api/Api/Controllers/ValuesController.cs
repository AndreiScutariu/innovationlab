using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Bus;
using MessageContracts;

namespace Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            var somethingHappened = new InnoEvent
            {
                What = "something",
                When = DateTime.Now
            };

            await MassTransitBus.Instance.Publish(somethingHappened);

            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        public async Task<string> Get(int id)
        {
            var somethingHappened = new InnoEvent
            {
                What = "something with id " + id,
                When = DateTime.Now
            };

            await MassTransitBus.Instance.Publish(somethingHappened);

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
