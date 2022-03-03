using Person.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Core.Services.Interfaces
{
    public interface IPersonService
    {
        List<string> Save(PersonModel person);
        IEnumerable<PersonModel> Get();
        PersonModel Get(Guid? personId);
        bool Delete(Guid? personId);
    }
}
