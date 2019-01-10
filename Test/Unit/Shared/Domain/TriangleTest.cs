using System;
using NUnit.Framework;
using Shared.Domain;

namespace Test.Unit.Shared.Domain
{
    [TestFixture]
    public class TriangleTest
    {
        [TestCase(4,4,4,TriangleType.Equilateral)]
        [TestCase(4,4,6,TriangleType.Isosceles)]
        [TestCase(4,5,6,TriangleType.Scalene)]
        public void Valid_Type_Mapped(int sideA, int sideB, int sideC, TriangleType type)
        {
            var triagle = Triangle.New().WithSideA(sideA).WithSideB(sideB).WithSideC(sideC).ValidateThrowOnError();
            Assert.That(triagle.Type, Is.EqualTo(type));
        }
        
        [TestCase(1,2,3,TriangleType.Invalid)]
        public void InValid_Type_Mapped(int sideA, int sideB, int sideC, TriangleType type)
        {
            var triagle = Triangle.New().WithSideA(sideA).WithSideB(sideB).WithSideC(sideC);
            Assert.That(triagle.IsValid(), Is.False);
            Assert.That(triagle.Type, Is.EqualTo(type));
        }

        [Test]
        public void Default_IsValid()
        {
            Assert.That(Triangle.New().IsValid(), Is.True);
        }

        [Test]
        public void Immutable()
        {
            var a = Triangle.New().WithSideA(4);
            var b = a.WithSideB(4);
            var c = b.WithSideC(4);
        
            Assert.That(a, Is.Not.EqualTo(b));
            Assert.That(b, Is.Not.EqualTo(c));
            Assert.That(c, Is.Not.EqualTo(a));
        }

        [Test]
        public void Value_Equals()
        {
            var a = Triangle.New().WithSideA(4).WithSideB(4).WithSideC(4);
            var b = Triangle.New().WithSideA(4).WithSideB(4).WithSideC(4);
            var c = Triangle.New().WithSideA(4).WithSideB(4).WithSideC(4);
        
            Assert.That(a, Is.EqualTo(b));
            Assert.That(b, Is.EqualTo(c));
            Assert.That(c, Is.EqualTo(a));
        }

        [Test]
        public void Value_NotEquals()
        {
            var a = Triangle.New().WithSideA(4).WithSideB(4).WithSideC(4);
            var b = Triangle.New().WithSideA(4).WithSideB(6).WithSideC(4);
            var c = Triangle.New().WithSideA(4).WithSideB(4).WithSideC(6);
        
            Assert.That(a, Is.Not.EqualTo(b));
            Assert.That(b, Is.Not.EqualTo(c));
            Assert.That(c, Is.Not.EqualTo(a));
        }

        [Test]
        public void ValidateThrowOnError()
        {
            Assert.Throws<Exception>(()=> Triangle.New()
            .WithSideA(1).WithSideB(2).WithSideC(3)
            .ValidateThrowOnError(),"did not throw expected exception");
        }
    }
}