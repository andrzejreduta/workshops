using System.Collections;
using FluentAssertions;
using Xunit;

namespace Exercises._04_Collections
{
    public class FibonacciTests
    {
        [Fact]
        public void NumbersAreElementsOfFibonacciSequence()
        {
            var numbers = Fibonacci.GetFirst(7);
            numbers.Should().NotBeAssignableTo<ICollection>();
            numbers.Should().ContainInOrder(0, 1, 1, 2, 3, 5, 8);
        }
    }
}