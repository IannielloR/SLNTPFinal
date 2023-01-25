using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Ianniello.Data;
using SWProvincias_Ianniello.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Ianniello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly DbProvinciasContext context;

        public CiudadController(DbProvinciasContext context)
        {
            this.context = context;
        }
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> GetClinica()
        {
            return context.Ciudades.ToList();
        }

        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();

            return Ok();
        }

        //UPDATE
        //PUT api/autor/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }

            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }


        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudad = (from c in context.Ciudades
                             where c.IdCiudad == id
                             select c).SingleOrDefault();

            if (ciudad == null)
            {
                return NotFound();
            }

            context.Ciudades.Remove(ciudad);
            context.SaveChanges();

            return ciudad;
        }
    }
}
