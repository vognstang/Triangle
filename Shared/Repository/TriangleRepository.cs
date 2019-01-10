using Shared.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Repository
{
    public interface ITriangleRepository
    {
        void Add(Triangle triangle);
        List<Triangle> DistinctList();
    }

    public class InMemoryTriangleRepository : ITriangleRepository
    {
        private static ConcurrentBag<Triangle> bag = new ConcurrentBag<Triangle>();
        public void Add(Triangle triangle)
        {
            bag.Add(triangle);
        }

        public List<Triangle> DistinctList()
        {
            return bag.Distinct().ToList();
        }

        public void Clear()
        {
            bag = new ConcurrentBag<Triangle>();
        }
    }
}