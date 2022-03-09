using AddressApp.Services;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace AddressApp.BaseClasses
{
    public class CommonPeopleFunctions : CommonComponent
    {
        #region Dependency Injection

        [Inject]
        public PeopleService Service { get; set; }

        #endregion

        #region Events

        public string GetDateOfBirth(DateTime? dateOfBirth)
        {
            return (dateOfBirth.HasValue) ? dateOfBirth.Value.ToString("MM/dd/yyyy", CultureInfo.CreateSpecificCulture("en-US")) : string.Empty;
        }
        #endregion
    }
}
