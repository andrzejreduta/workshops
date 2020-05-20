using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace Exercises._02_Generics
{
    public class CrudRepositoryTests
    {
        private readonly Mock<IDataStore> _dataStoreMock = new Mock<IDataStore>();

        [Fact]
        public void CanCreateEntity()
        {
            var repository = CreateTestedRepository();
            var product = new Product(Guid.NewGuid());
            Invoke(repository, "Create", product);
            _dataStoreMock.Verify(s => s.Save(product), Times.Once);
        }
        
        [Fact]
        public void CanReadEntity()
        {
            var id = Guid.NewGuid();
            _dataStoreMock.Setup(s => s.Get(id)).Returns(new Product(id));
            var repository = CreateTestedRepository();
            var product = Invoke<Product>(repository, "Read", id);
            product.Id.Should().Be(id);
        }
        
        [Fact]
        public void CanUpdateEntity()
        {
            var repository = CreateTestedRepository();
            var product = new Product(Guid.NewGuid());
            Invoke(repository, "Update", product);
            _dataStoreMock.Verify(s => s.Save(product), Times.Once);
        }
        
        [Fact]
        public void CanDeleteEntity()
        {
            var id = Guid.NewGuid();
            var product = new Product(id);
            _dataStoreMock.Setup(s => s.Get(id)).Returns(product);
            var repository = CreateTestedRepository();
            Invoke(repository, "Delete", id);
            product.IsDeleted.Should().BeTrue();
            _dataStoreMock.Verify(s => s.Save(product), Times.Once);
        }

        private object CreateTestedRepository()
        {
            var repositoryType = TestHelpers.GetType("CrudRepository");
            repositoryType.IsGenericType.Should().BeTrue();
            repositoryType = repositoryType.MakeGenericType(typeof(Product));
            var constructor = repositoryType.GetConstructor(new[] {typeof(IDataStore)});
            constructor.Should().NotBeNull("CrudRepository should have constructor with single IDataStore argument");
            return constructor.Invoke(new object[] {_dataStoreMock.Object});
        }
        
        private static void Invoke(object instance, string methodName, params object[] arguments)
        {
            var methodInfo = instance.GetType().GetMethod(methodName);
            if (methodInfo is null)
                throw new AggregateException($"Missing {methodName} method in CrudRepository");
            methodInfo.Invoke(instance, arguments);
        }

        private static TOut Invoke<TOut>(object instance, string methodName, params object[] arguments)
        {
            var methodInfo = instance.GetType().GetMethod(methodName);
            if (methodInfo is null)
                throw new AggregateException($"Missing {methodName} method in CrudRepository");
            return (TOut) methodInfo.Invoke(instance, arguments);
        }
    }
}