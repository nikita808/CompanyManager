using CompanyManager.Contracts;
using CompanyManager.Entities;
using CompanyManager.LoggerService;
using CompanyManager.Services;
using CompanyManager.Services.Contracts;
using CompanyManager.Services.Mappers;
using CompanyManager.Shared.DataTransferObjects;
using Moq;

namespace CompanyManager.Tests;

[TestFixture]
public class CompaniesServiceTests
{
    private ICompanyService _service = null!;
    private Mock<IRepositoryManager> _mockRepository = null!;
    private Mock<ILoggerManager> _mockLogger = null!;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<IRepositoryManager>();
        _mockLogger = new Mock<ILoggerManager>();
        _service = new CompanyService(_mockRepository.Object, _mockLogger.Object);
    }

    [Test]
    public async Task GetAllCompanies_Returns_Correct_Type()
    {
        var companyToCreate = new Company { Name = "Test Company", Address = "123 Test St.", Country = "Testland" };

        _mockRepository
            .Setup(r => r.Companies.AddOneAsync(companyToCreate)).Returns(Task.CompletedTask);

        _mockRepository.Setup(r => r.SaveAsync()).Returns(Task.CompletedTask);

        _mockRepository
            .Setup(r => r.Companies.GetAllCompaniesAsync(false)).ReturnsAsync(new List<Company>());


        await _service.CreateOne(CompanyMapper.ToDto(companyToCreate));

        _mockRepository.VerifyAll();
    }
}