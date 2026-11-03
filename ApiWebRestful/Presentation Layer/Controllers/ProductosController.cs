using Microsoft.AspNetCore.Mvc;

//Expone los Endpoints HTTP y tiene q retornar IActionResult (Ok, CreatedAtAction, BadRequest, NotFound, NoContent)


namespace ApiWebRestful.Presentation_Layer.Controllers {
  [Route("api/[controller]")]
  [ApiController] //atributos que me hacen la vida mas facil
  public class ProductosController : ControllerBase {
    // GET: api/<ProductosController>
    [HttpGet]
    public IEnumerable<string> Get() {
      return new string[] { "value1", "value2" };
    }

    // GET api/<ProductosController>/5
    [HttpGet("{id}")]
    public string Get(int id) {
      return "value";
    }

    // POST api/<ProductosController>
    [HttpPost]
    public void Post([FromBody] string value) {
    }

    // PUT api/<ProductosController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE api/<ProductosController>/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }
  }
}
