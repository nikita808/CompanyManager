using CompanyManager.Contracts;
using CompanyManager.Entities;
using CompanyManager.LoggerService;
using CompanyManager.Services.Contracts;

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

    public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges)
    {
        try
        {
            var companies =
                await _repository.Company.GetAllCompanies(trackChanges);
            return companies;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");
            throw;
        }
    }
}