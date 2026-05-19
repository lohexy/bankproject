using Xunit;
using Moq;
using System.Collections.Generic;
using BankEmulator.Domain;
using BankEmulator.App;
using BankEmulator.App.DTO;

namespace BankEmulator.Tests
{
    public class BankStorageTests
    {
        [Fact]
        public void LoadClients_FileHasData_ReturnsClientList()
        {
            var mockStorage = new Mock<IFileStorage>();
            var fakeClients = new List<ClientDto> { new ClientDto { Name = "Іван" } };
            mockStorage.Setup(s => s.LoadClients()).Returns(fakeClients);
            var result = mockStorage.Object.LoadClients();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Іван", result[0].Name);
        }

        [Fact]
        public void LoadClients_FileIsEmpty_ReturnsEmptyList()
        {
            var mockStorage = new Mock<IFileStorage>();
            mockStorage.Setup(s => s.LoadClients()).Returns(new List<ClientDto>());
            var result = mockStorage.Object.LoadClients();

            Assert.Empty(result);
        }

        [Fact]
        public void SaveClients_ValidList_CallsSaveMethodOnce()
        {
            var mockStorage = new Mock<IFileStorage>();
            var clientsToSave = new List<ClientDto> { new ClientDto { Name = "Марія" } };

            mockStorage.Object.SaveClients(clientsToSave);

            mockStorage.Verify(s => s.SaveClients(clientsToSave), Times.Once);
        }

        [Fact]
        public void SaveClients_EmptyList_CallsSaveMethodOnce()
        {
            var mockStorage = new Mock<IFileStorage>();
            var emptyList = new List<ClientDto>();

            mockStorage.Object.SaveClients(emptyList);

            mockStorage.Verify(s => s.SaveClients(emptyList), Times.Once);
        }

        [Fact]
        public void SaveClients_DoesNotCallLoadClients()
        {
            var mockStorage = new Mock<IFileStorage>();
            var emptyList = new List<ClientDto>();

            mockStorage.Object.SaveClients(emptyList);

            mockStorage.Verify(s => s.LoadClients(), Times.Never);
        }

        [Fact]
        public void LoadClients_DoesNotCallSaveClients()
        {
            var mockStorage = new Mock<IFileStorage>();
            mockStorage.Setup(s => s.LoadClients()).Returns(new List<ClientDto>());
            var result = mockStorage.Object.LoadClients();

            mockStorage.Verify(s => s.SaveClients(It.IsAny<List<ClientDto>>()), Times.Never);
        }
    }
}