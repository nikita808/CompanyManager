using CompanyManager.Contracts;
using CompanyManager.Entities;
using CompanyManager.Entities.Exceptions;
using CompanyManager.LoggerService;
using CompanyManager.Services.Contracts;
using CompanyManager.Services.Mappers;
using CompanyManager.Shared.DataTransferObjects;

namespace CompanyManager.Services;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repository;

    private readonly ILoggerManager _logger;

    public CompanyService(IRepositoryManager repository, ILoggerManager
        logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges)
    {
        var companies =
            await _repository.Company.GetAllCompanies(trackChanges);

        var enumerable = companies as Company[] ?? companies.ToArray();

        if (!enumerable.Any())
        {
            return Array.Empty<CompanyDto>();
        }

        return enumerable.Select(CompanyMapper.ToDto)!;
    }

    public async Task<CompanyDto> GetOne(int id, bool trackChanges)
    {
        var company = await _repository.Company.GetOne(id, trackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(id);
        }

        return CompanyMapper.ToDto(company);
    }
}