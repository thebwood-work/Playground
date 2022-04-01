
using Locations.Core.Models;
using Locations.Core.Services.Interfaces;
using MassTransit;

namespace Locations.API.Consumers
{
    public class PeopleAddressConsumer : IConsumer<PersonAddressModel>
    {
        private readonly ILogger<PeopleAddressConsumer> _logger;
        private readonly IAddressService _service;
        public PeopleAddressConsumer(ILogger<PeopleAddressConsumer> logger, IAddressService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<PersonAddressModel> context)
        {
            await Console.Out.WriteLineAsync($"Order submitted: {context.Message.PersonId}");

            _service.SavePeopleAddresses(context.Message);
        }
    }
}