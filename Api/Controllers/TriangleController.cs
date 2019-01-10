using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain;
using Shared.Service;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly ITriangleService triangleService;

        public TriangleController(ITriangleService triangleService)
        {
            this.triangleService = triangleService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Triangle>> Get()
        {
            return triangleService.GetDistinctTriangles();
        }

        // POST api/values
        [HttpPost]
        public void Post(int sideA, int sideB, int sideC)
        {
            triangleService.Save(Triangle.New().WithSideA(sideA).WithSideB(sideB).WithSideC(sideC));
        }
    }
}
