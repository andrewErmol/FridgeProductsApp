using AutoMapper;
using FluentAssertions;
using FridgeProductsApp.API.Controllers;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain;
using FridgeProductsApp.Domain.DTO.Fridge;
using FridgeProductsApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FridgeProductsApp.Tests.ControllerTests
{
    public class FridgeControllerTests
    {
        private static IMapper _mapper;

        public FridgeControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        private IEnumerable<Fridge> GetFridgeList()
        {
            return new List<Fridge>
            {
                new Fridge
                {
                    Id = new Guid("a910e94a-624c-4e57-8541-05a53a8ff9da"),
                    Name = "Atlant",
                    OwnerName = "Vlada",
                    ModelId = new Guid("d53237e3-ecd7-4cba-a920-d5fdba75f4c8")
                },
                new Fridge
                {
                    Id = new Guid("5209d214-af14-42c1-92b1-537b28897719"),
                    Name = "Samsung",
                    OwnerName = "Anna",
                    ModelId = new Guid("b1525dab-732b-48b1-9146-96382a7e5303"),
                }
            };
        }

        private IEnumerable<FridgeDto> GetFridgeDtoList()
        {
            return new List<FridgeDto>
            {
                new FridgeDto
                {
                    Id = new Guid("a910e94a-624c-4e57-8541-05a53a8ff9da"),
                    OwnerName = "Vlada",
                    ModelName = "Atlant R2D2"
                },
                new FridgeDto
                {
                    Id = new Guid("5209d214-af14-42c1-92b1-537b28897719"),
                    OwnerName = "Anna",
                    ModelName = "Samsung KJ-118"
                }
            };
        }

        [Fact]
        public void GetAll_SendRequest_ReturnEmptyList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var mapper = new Mock<IMapper>();

            repositoryManager.Setup(r => r.Fridge.GetAllFridges(false))
                .Returns(new List<Fridge>());
            mapper.Setup(m => m.Map<List<Fridge>, List<FridgeDto>>(
                It.IsAny<List<Fridge>>())).Returns(new List<FridgeDto>());

            var controller = new FridgeController(repositoryManager.Object, null, mapper.Object);

            // Act
            var response = controller.GetAllFridges();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var models = result.Value as IEnumerable<FridgeDto>;
            models.Should().HaveCount(0);
        }

        [Fact]
        public void GetAll_SendRequest_ReturnCompletedList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var fakeFridgesList = GetFridgeList();
            var fakeFridgesDtoList = GetFridgeDtoList();

            repositoryManager.Setup(r => r.Fridge.GetAllFridges(false))
                .Returns(fakeFridgesList);

            var controller = new FridgeController(repositoryManager.Object, null, _mapper);

            // Act
            var response = controller.GetAllFridges();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var models = result.Value as IEnumerable<FridgeDto>;
            models.Should().HaveSameCount(fakeFridgesDtoList);
        }

        [Fact]
        public void Get_SendRequest_ReturnFridgeById()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("a910e94a-624c-4e57-8541-05a53a8ff9da");
            var fridge = GetFridgeList().ToList().Find(f => f.Id.Equals(id));
            var fridgeDto = GetFridgeDtoList().ToList().Find(f => f.Id.Equals(id));

            repositoryManager.Setup(r => r.Fridge.GetFridge(id, false))
                .Returns(fridge);

            var controller = new FridgeController(repositoryManager.Object, null, _mapper);

            // Act
            var response = controller.GetFridge(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var resultModel = result.Value as FridgeDto;

            Assert.Equal(fridgeDto.Id, resultModel.Id);
            Assert.Equal(fridgeDto.OwnerName, resultModel.OwnerName);
        }

        [Fact]
        public void Create_SendRequest_ReturnStatusCode201()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            Fridge fridge = new Fridge
            {
                Name = "Atlant",
                OwnerName = "Anna"
            };

            FridgeForCreationDto fridgeForCreation = new FridgeForCreationDto
            {
                Name = "Atlant",
                OwnerName = "Anna"
            };

            repositoryManager.Setup(r => r.Fridge.CreateFridge(fridge));

            var controller = new FridgeController(repositoryManager.Object, null, _mapper);

            // Act
            var response = controller.CreateFridge(fridgeForCreation);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(response);
        }

        [Fact]
        public void Delete_SendRequest_ReturnStatusCode200()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("a910e94a-624c-4e57-8541-05a53a8ff9da");
            var fridge = GetFridgeList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.Fridge.GetFridge(id, false))
                .Returns(fridge);
            repositoryManager.Setup(r => r.Fridge.DeleteFridge(fridge));

            var controller = new FridgeController(repositoryManager.Object, null, null);

            // Act
            var response = controller.DeleteFridge(id);

            // Assert
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public void Update_SendRequest_ReturnStatusCode200()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("a910e94a-624c-4e57-8541-05a53a8ff9da");
            var fridge = GetFridgeList().ToList().Find(m => m.Id.Equals(id));
            var fridgeForUpdate = new FridgeForUpdateDto
            {
                Id = id,
                Name = "Philyps"
            };

            repositoryManager.Setup(r => r.Fridge.GetFridge(id, true))
                .Returns(fridge);

            var controller = new FridgeController(repositoryManager.Object, null, _mapper);

            // Act
            var response = controller.UpdateFridge(fridgeForUpdate);

            // Assert
            Assert.IsType<NoContentResult>(response);
        }
    }
}
