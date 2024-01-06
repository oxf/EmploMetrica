using NSubstitute;

namespace EmploMetrica.API.Test
{
    public class CompanyCrudTest
    {
        [Fact]
        public async Task GetAllCompanies_ReturnsAllCompanies()
        {
            // Arrange
            //var mockRepository = Substitute.For<ICompanyRepository>(); // Assuming you have a repository interface
            //var companies = new List<Company>
            //{
            //    new Company { Id = 1, Name = "Company 1", IsActive = true },
            //    new Company { Id = 2, Name = "Company 2", IsActive = false }
            //};
            //mockRepository.GetAllCompaniesAsync().Returns(companies);
            //var controller = new CompanyController(mockRepository);

            //// Act
            //var result = await controller.GetAllCompanies();

            //// Assert
            //var actionResult = Assert.IsType<ActionResult<IEnumerable<Company>>>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<Company>>(actionResult.Value);
            //Assert.Equal(2, model.Count);
        }
    }
}