using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zadanie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Zadanie2Controller : ControllerBase
    {
        private List<TestMessage> messages = new List<TestMessage>
        {
            new TestMessage { Id = 1, Message = "ну типо строка 1" },
            new TestMessage { Id = 2, Message = "ну типо строка 2" },
            new TestMessage { Id = 3, Message = "ну типо строка 3" }
        };

        // GET: api/<Zadanie2Controller>
        [HttpGet]
        public IEnumerable<TestMessage> Get()
        {
            return messages;
        }

        // GET api/<Zadanie2Controller>/5
        [HttpGet("{id}")]
        public TestMessage? Get(int id)
        {
            return messages.FirstOrDefault(t => t.Id == id);
        }

        // POST api/<Zadanie2Controller>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Значение не может быть пустым");
            }
            return Ok();
        }

        // PUT api/<Zadanie2Controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= messages.Count) 
            {
                return NotFound();
            }
            return Ok("Данные успешно обновлены");
        }

        // DELETE api/<Zadanie2Controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= messages.Count)
            {
                return NotFound();
            }
            return Ok("Такой элемент с Id = " + id + " был удален");
        }
    }
}
