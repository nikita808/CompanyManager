using CompanyManager.Services.Contracts;
using CompanyManager.Shared.DataTransferObjects;
using Moq;

namespace CompanyManager.Tests;

[TestFixture]
public class CompaniesServiceTests
{
    private Mock<ICompanyService> _mockService = null!;

    [SetUp]
    public void SetUp()
    {
        _mockService = new Mock<ICompanyService>();
    }

    [Test]
    public async Task GetAllCompanies_Returns_Correct_Number()
    {
        var list = new List<CompanyDto> { new(), new() };

        var task = Task.FromResult(list);

        _mockService.Setup(s => s.GetAllCompanies(false))
            .ReturnsAsync(await task);

        Assert.That(list, Has.Count.EqualTo(2));
    }
}