using InMemoryDatabase.Controllers;
using InMemoryDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InMemoryDatabase.Tests
{
    [TestClass]
    public class LibraryControllerTests
    {
        private LibraryController _controller;
        private ILibraryRepository _repository;

        private ILibraryRepository GetInMemoryRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                             .UseInMemoryDatabase(databaseName: "MockDB")
                             .Options;

            var context = new LibraryContext(options);

            var repository = new DbRepository(context);

            return repository;
        }

        [TestInitialize]
        public void Setup()
        {
            _repository = GetInMemoryRepository();// new Mocks.MockRepository();
            _controller = new LibraryController(_repository);
        }

        [TestMethod]
        public void Create()
        {
            _controller.Create();

            Assert.AreEqual(1, _repository.Books.Count());
            Assert.AreEqual("Jane Austen", _repository.Books.First().Author.Name);
            Assert.AreEqual(1, _repository.Authors.Count());
            Assert.AreEqual("Emma", _repository.Authors.First().Books.First().Title);
        }
    }
}
