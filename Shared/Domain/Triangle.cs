using System;
using System.Runtime.Serialization;

namespace Shared.Domain
{
    public class Triangle
    {
        public TriangleType Type { get; private set; } 
        public int SideA { get; }
        public int SideB { get; }
        public int SideC { get; }

        private Triangle(int sideA, int sideB, int sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            Type = GetTriangleType();
        }

        public bool IsValid()
        {
            if(GetValidationError()==null)
                return true;
            return false;
        }

         public string GetValidationError()
        {
            if (!(SideA + SideB > SideC &&
                SideA + SideC > SideB &&
                SideB + SideC > SideA))
            {
                return "The following must be true for you to have a triangle SideA + SideB > SideC\nSideA + SideC > SideB\nSideB + SideC > SideA";
            }
            return null;
        }

        public static Triangle New()
        {
            return new Triangle(3, 3, 3);
        }

        public Triangle WithSideA(int sideA) => new Triangle(sideA, SideB, SideC);

        public Triangle WithSideB(int sideB) => new Triangle(SideA, sideB, SideC);

        public Triangle WithSideC(int sideC) => new Triangle(SideA, SideB, sideC);

        public Triangle ValidateThrowOnError()
        {
            if (!IsValid())
            {
                throw new Exception(GetValidationError());
            }
            return this;
        }

        private TriangleType GetTriangleType()
        {
            if (!IsValid())
            {
                return TriangleType.Invalid;
            }
            if (SideA == SideB && SideB == SideC)
            {
                return TriangleType.Equilateral;
            }
            if (SideA == SideB || SideB == SideC || SideC == SideA)
            {
                return TriangleType.Isosceles;
            }
            return TriangleType.Scalene;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Triangle);
        }

        public bool Equals(Triangle triangle)
        {
            if (Object.ReferenceEquals(triangle, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, triangle))
            {
                return true;
            }

            if (this.GetType() != triangle.GetType())
            {
                return false;
            }
            return (SideA == triangle.SideA) && (SideB == triangle.SideB)&& (SideC == triangle.SideC);
        }

        public override int GetHashCode()
        {
            return SideA * 0x00010000 + SideB+SideC;
        }

        public static bool operator ==(Triangle lhs, Triangle rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Triangle lhs, Triangle rhs)
        {
            return !(lhs == rhs);
        }
    }
}