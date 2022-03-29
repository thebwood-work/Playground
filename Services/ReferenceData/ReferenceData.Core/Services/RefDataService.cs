using AutoMapper;
using Microsoft.Extensions.Logging;
using Playground.Core.Base.Services;
using ReferenceData.Core.Models;
using ReferenceData.Core.Services.Interfaces;
using ReferenceData.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.Core.Services
{
    public class RefDataService : PlaygroundService<RefDataService>, IRefDataService
    {
        private readonly IRefDataRepository _repository;
        private readonly IMapper _mapper;

        public RefDataService(ILogger<RefDataService> logger, IRefDataRepository respository, IMapper mapper) : base(logger)
        {
            _repository = respository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }


        public IEnumerable<CountryModel> GetCountries()
        {
            IEnumerable<CountryModel> results = new List<CountryModel>();
            try
            {
                var values = _repository.GetCountries();
                _mapper.Map(values, results);
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetCountries", ex);
            }
            return results;
        }

        public IEnumerable<StateModel> GetStates()
        {
            IEnumerable<StateModel> results = new List<StateModel>();
            try
            {
                var values = _repository.GetStates();
                _mapper.Map(values, results);
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetStates", ex);
            }
            return results;
        }
    }
}
