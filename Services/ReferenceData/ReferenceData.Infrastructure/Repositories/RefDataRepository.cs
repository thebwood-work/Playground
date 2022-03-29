using Microsoft.Extensions.Logging;
using Playground.Infrastructure.Base.Repositories;
using ReferenceData.Infrastructure.Entities;
using ReferenceData.Infrastructure.Repositories.Interfaces;

namespace ReferenceData.Infrastructure.Repositories
{
    public class RefDataRepository : PlaygroundRepository<RefDataRepository>, IRefDataRepository
    {
        private RefDataContext _context;

        public RefDataRepository(ILogger<RefDataRepository> logger, RefDataContext context) : base(logger)
        {
            _context = context ?? throw new ArgumentNullException();
        }


        public IEnumerable<Country> GetCountries() => _context.Countries;

        public IEnumerable<State> GetStates() => _context.States;
    }
}
