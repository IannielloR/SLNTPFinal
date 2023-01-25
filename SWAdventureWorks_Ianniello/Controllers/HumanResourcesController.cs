using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Ianniello.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Ianniello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanResourcesController : ControllerBase
    {
        private readonly AdventureWorks2019Context context;

        public HumanResourcesController(AdventureWorks2019Context context)
        {
            this.context = context;
        }
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetClinica()
        {
            return context.Department.ToList();
        }

        //UPDATE
        //PUT api/autor/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("name/{name}")]
        public ActionResult<Department> GetByName(string name)
        {
            Department store = (from d in context.Department
                                where d.Name == name
                            select d).SingleOrDefault();

            return store;
        }

        [HttpPost]
        public ActionResult Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Department.Add(department);
            context.SaveChanges();

            return Ok();
        }
    }
}
