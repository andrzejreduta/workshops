using System;
using System.Threading.Tasks;
using Exercises._02_Generics;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Xunit;

namespace Exercises._10_AsyncAwait
{
    public class CrudAsyncRepositoryTests
    {
        private readonly Mock<IAsyncDataStore> _dataStoreMock = new Mock<IAsyncDataStore>();

        [Fact]
        public void CanCreateEntity()
        {
            var repository = CreateTestedRepository();
            var product = new Product(Guid.NewGuid());
            Invoke(repository, "Create", product);
            _dataStoreMock.Verify(s => s.Save(product), Times.Once);
        }

        [Fact]
        public async Task CanReadEntity()
        {
            var id = Guid.NewGuid();
            _dataStoreMock.Setup(s => s.Get(id)).ReturnsAsync(new Product(id));
            var repository = CreateTestedRepository();
            var product = await Invoke<Product>(repository, "Read", id);
            product.Id.Should().Be(id);
        }

        [Fact]
        public async Task CanUpdateEntity()
        {
            var repository = CreateTestedRepository();
            var product = new Product(Guid.NewGuid());
            await Invoke(repository, "Update", product);
            _dataStoreMock.Verify(s => s.Save(product), Times.Once);
        }

        [Fact]
        public async Task CanDeleteEntity()
        {
            var id = Guid.NewGuid();
            var product = new Product(id);
            _dataStoreMock.Setup(s => s.Get(id)).ReturnsAsync(product);
            var repository = CreateTestedRepository();
            await Invoke(repository, "Delete", id);
            product.IsDeleted.Should().BeTrue();
            _dataStoreMock.Verify(s => s.Save(product), Times.Once);
        }

        private object CreateTestedRepository()
        {
            var repositoryType = TestHelpers.GetType("CrudAsyncRepository");
            repositoryType.IsGenericType.Should().BeTrue();
            repositoryType = repositoryType.MakeGenericType(typeof(Product));
            var constructor = repositoryType.GetConstructor(new[] {typeof(IAsyncDataStore)});
            constructor.Should()
                .NotBeNull("CrudAsyncRepository should have constructor with single IAsyncDataStore argument");
            return constructor.Invoke(new object[] {_dataStoreMock.Object});
        }

        private static Task Invoke(object instance, string methodName, params object[] arguments)
        {
            var methodInfo = instance.GetType().GetMethod(methodName);
            if (methodInfo is null)
                throw new AggregateException($"Missing {methodName} method in CrudAsyncRepository");
            if (!(methodInfo.Invoke(instance, arguments) is Task task))
                throw new AssertionFailedException($"{methodName} method in CrudAsyncRepository should be async");
            return task;
        }

        private static Task<TOut> Invoke<TOut>(object instance, string methodName, params object[] arguments)
        {
            var methodInfo = instance.GetType().GetMethod(methodName);
            if (methodInfo is null)
                throw new AggregateException($"Missing {methodName} method in CrudAsyncRepository");
            if (!(methodInfo.Invoke(instance, arguments) is Task<TOut> task))
                throw new AssertionFailedException($"{methodName} method in CrudAsyncRepository should be async");
            return task;
        }
    }
}