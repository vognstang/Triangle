using System.Collections.Generic;
using System.Linq;
using Shared.Domain;
using Shared.Repository;

namespace Shared.Service
{
    public interface ITriangleService
    {
        void Save(Triangle triangle);
        List<Triangle> GetDistinctTriangles();
    }
    
    public class TriangleService : ITriangleService
    {
        private readonly ITriangleRepository triangleRepository;

        public TriangleService(ITriangleRepository triangleRepository)
        {
            this.triangleRepository = triangleRepository;
        }

        public List<Triangle> GetDistinctTriangles() => triangleRepository.DistinctList();

        public void Save(Triangle triangle)
        {
            // we decide to let any invalid triangle into store.
            triangle.ValidateThrowOnError();
            triangleRepository.Add(triangle);
        }

    }
}