using ReferenceData.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.Infrastructure.Repositories.Interfaces
{
    public interface IRefDataRepository
    {
        IEnumerable<State> GetStates();
        IEnumerable<Country> GetCountries();

    }
}
