using System.Linq;
using Api.Controllers;
using NUnit.Framework;
using Shared.Domain;
using Shared.Repository;
using Shared.Service;

namespace Test.Integration.Api.Controllers
{
    [TestFixture]
    public class TriangleControllerTest
    {
        private InMemoryTriangleRepository inMemoryTriangleRepository;
        private TriangleController triangleController;

        [SetUp]
        public void Setup()
        {
            // here we ought to have used the container, but I had a hard time finding the internal .net core cotainer.
            // normally I would use StructureMap or Unity.
            inMemoryTriangleRepository = new InMemoryTriangleRepository();
            // static inmem clearing
            inMemoryTriangleRepository.Clear();
            triangleController = new TriangleController(new TriangleService(inMemoryTriangleRepository));
        }

        [Test]
        public void Post_Get_DistinctList()
        {
            triangleController.Post(4,4,4);
            triangleController.Post(4,4,6);
            triangleController.Post(4,4,4);

            var distinctList = triangleController.Get().Value.ToList();
            
            Assert.That(distinctList.Count,Is.EqualTo(2));
            
            // we can reuse domain model, as long as there are no dto's (contracts)
            Assert.That(distinctList.Contains(Triangle.New().WithSideA(4).WithSideB(4).WithSideC(4)),Is.True);
            Assert.That(distinctList.Contains(Triangle.New().WithSideA(4).WithSideB(4).WithSideC(6)),Is.True);
        }
    }
}