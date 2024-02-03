using AutoMapper;
using EmploMetrica.API.Controllers;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace EmploMetrica.API.Test
{
    public class CompanyCrudTest
    {
    //    [Fact]
    //    public void Get_ReturnsListOfCompanies()
    //    {
    //        // Arrange
    //var dbContextMock = Substitute.For<AppDbContext>();
    //var mapperMock = Substitute.For<IMapper>();

    //var companies = new List<Company> { new Company(), new Company() };
    //dbContextMock.CompanyDbSet.Returns(companies.AsQueryable());

    //var expectedDtoList = new List<GetCompanyDTO> { new GetCompanyDTO(), new GetCompanyDTO() };

    //// Use Arg.Any explicitly for the argument type
    //mapperMock.Map<IEnumerable<GetCompanyDTO>>(Arg.Any<IEnumerable<Company>>()).Returns(expectedDtoList);

    //var controller = new CompanyController(dbContextMock, mapperMock);

    //// Act
    //var result = controller.Get();

    //// Assert
    //Assert.IsType<OkObjectResult>(result.Result);
    //var okResult = result.Result as OkObjectResult;
    //Assert.NotNull(okResult?.Value);
    //Assert.IsType<List<GetCompanyDTO>>(okResult?.Value);
    //Assert.Equal(expectedDtoList, okResult?.Value);
    //    }

    //    [Fact]
    //    public void GetById_ExistingId_ReturnsCompany()
    //    {
    //        // Arrange
    //        var dbContextMock = Substitute.For<AppDbContext>();
    //        var mapperMock = Substitute.For<IMapper>();

    //        var existingCompanyId = 1;
    //        var existingCompanyDto = new GetCompanyDTO { Id = existingCompanyId, /* Other properties */ };

    //        dbContextMock.CompanyDbSet.Find(existingCompanyId).Returns(new Company());
    //        mapperMock.Map<GetCompanyDTO>(Arg.Any<Company>()).Returns(existingCompanyDto);

    //        var controller = new CompanyController(dbContextMock, mapperMock);

    //        // Act
    //        var result = controller.GetById(existingCompanyId);

    //        // Assert
    //        Assert.IsType<OkObjectResult>(result.Result);
    //        var okResult = result.Result as OkObjectResult;
    //        Assert.NotNull(okResult?.Value);
    //        Assert.IsType<GetCompanyDTO>(okResult?.Value);
    //        Assert.Equal(existingCompanyId, (okResult?.Value as GetCompanyDTO)?.Id);
    //    }

    //    [Fact]
    //    public void GetById_NonExistingId_ReturnsNotFound()
    //    {
    //        // Arrange
    //        var dbContextMock = Substitute.For<AppDbContext>();
    //        var mapperMock = Substitute.For<IMapper>();

    //        var nonExistingCompanyId = 999;

    //        dbContextMock.CompanyDbSet.Find(nonExistingCompanyId).Returns((Company)null);

    //        var controller = new CompanyController(dbContextMock, mapperMock);

    //        // Act
    //        var result = controller.GetById(nonExistingCompanyId);

    //        // Assert
    //        Assert.IsType<NotFoundResult>(result.Result);
    //    }
    }
}