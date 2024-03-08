using AutoMapper;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using EmploMetrica.Domain.Shared;
using EmploMetrica.API.Controllers;
using EmploMetrica.Application.Interfaces;
using NSubstitute.ExceptionExtensions;

namespace EmploMetrica.API.Test
{
    public class CompanyControllerTests
    {
        private readonly CompanyController _companyController;
        private readonly ICrudService<GetCompanyDTO, CreateCompanyDTO, UpdateCompanyDTO> _companyService;

        public CompanyControllerTests()
        {
            _companyService = Substitute.For<ICrudService<GetCompanyDTO, CreateCompanyDTO, UpdateCompanyDTO>>();
            _companyController = new CompanyController(_companyService);
        }

        [Fact]
        public void Get_ReturnsOk_WhenEmptyData()
        {
            // Arrange
            var testData = new List<GetCompanyDTO>();
            _companyService.Get().Returns(new Domain.Shared.Result<List<GetCompanyDTO>>(true, testData, null));

            // Act
            var result = _companyController.Get();

            // Assert
            Assert.IsType(typeof(IActionResult), result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_ReturnsOk_WhenServiceReturnsData()
        {
            // Arrange
            var testData = new List<GetCompanyDTO> {
                new GetCompanyDTO { Id = 12, Name = "Apple Inc.", IsActive = true },
                new GetCompanyDTO { Id = 13, Name = "BlackBerry Ltd.", IsActive = false }
            };
            _companyService.Get().Returns(new Domain.Shared.Result<List<GetCompanyDTO>>(true, testData, null));

            // Act
            var result = _companyController.Get();

            // Assert
            Assert.IsType(typeof(IActionResult), result);
            Assert.NotNull(result);
        }
    }
 }