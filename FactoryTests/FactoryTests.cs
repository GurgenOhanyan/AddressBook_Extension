using AddressBook.Application.Services;
using AddressBook.Controllers;
using AddressBook.Factory;
using AddressBook.Factory.MappingHelpers;
using AddressBook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryTests
{
    [TestClass]
    public class FactoryTests
    {
        private readonly Mock<IContactService> _mockService;
        private readonly Mock<ContactController> _mockController;
        private readonly ContactFactory _contactFactory;

        public FactoryTests()
        {
            _mockService = new Mock<IContactService>();
            _contactFactory = new ContactFactory(_mockService.Object);
            _mockController = new Mock<ContactController>();
        }

        [TestMethod]
        public void GetAll_ReturnsExact()
        {
            //Arrange
            _mockService.Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<AddressBook.Application.ApplicationModels.Contact>
                {
                    new AddressBook.Application.ApplicationModels.Contact(){FullName="John Doe",PhoneNumber="+37494000000" }
                ,
                    new AddressBook.Application.ApplicationModels.Contact()
                });


            var appModels = _mockService.Object.GetAll().Result;

            //Application Model Map To ViewModel

            var viewModels = appModels.Select(appcontact => MapperExtension.MapTo<Contact>(appcontact)).ToList();
            //Act

            var result = _contactFactory.GetAll().Result;

            //Assert
            Assert.IsTrue(result.Count == 2);

            Assert.IsInstanceOfType(result, typeof(List<Contact>));
            Assert.AreEqual("John Doe", result[0].FullName);
        }
        [TestMethod]
        public void GetSingle_ReturnsExact()
        {
            //Arrange
            _mockService.Setup(repo => repo.GetSingle(2))
                .ReturnsAsync(new AddressBook.Application.ApplicationModels.Contact() { EmailAddress = "test@gmail.com", Id = 2 });

            var appModel = _mockService.Object.GetSingle(2).Result;

            var viewModel = MapperExtension.MapTo<Contact>(appModel);
            //Act

            var result = _contactFactory.GetSingle(2).Result;
            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual("test@gmail.com", result.EmailAddress);
            Assert.AreEqual(2, result.Id);
        }

        [TestMethod]
        public void Create_WorksExact()
        {
            //Arrange

            var viewModel = new Contact() { EmailAddress = "test@gmail.com", PhoneNumber = "123456" };

            //Act

            Task.FromResult(_contactFactory.Create(viewModel));

            //Assert


            _mockService.Verify(mockService => mockService.Create(It.Is<AddressBook.Application.ApplicationModels.Contact>(contact => contact.EmailAddress == "test@gmail.com" && contact.PhoneNumber == "123456")), Times.Once);
        }
        [TestMethod]
        public void Update_WorksExact()
        {

            //Arrange
            var viewModel = new Contact() { EmailAddress = "test@gmail.com", FullName = "John Doe" };

            //Act
            var task = Task.FromResult(_contactFactory.Update(viewModel));

            //Assert
            _mockService.Verify(mockService => mockService.EditContact(It.Is<AddressBook.Application.ApplicationModels.Contact>(contact => contact.EmailAddress == "test@gmail.com" &&
                                                                                                                                contact.FullName == "John Doe"
                                                                                                                              )), Times.Once());
        }
        [TestMethod]
        public void Delete_WorksExact()
        {

            //Arrange

            int id = 1;

            //Act

            var task = _contactFactory.Delete(id);

            task.Wait();

            //Assert

            _mockService.Verify(mockService => mockService.DeleteContact(It.Is<int>(transferredId => transferredId == id)), Times.Once());

        }
    }
}
