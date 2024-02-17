using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.Vaccine
{
    public class AddVaccineCommandHandler : IRequestHandler<AddVaccineCommand, VaccineModel>
    {
        private readonly IMediator _mediator;
        private readonly IVaccineService _vaccineService;
        public AddVaccineCommandHandler(IMediator mediator, IVaccineService service)
        {
            this._mediator = mediator;
            this._vaccineService = service;
        }

        public async Task<VaccineModel> Handle(AddVaccineCommand request, CancellationToken cancellationToken)
        {
            var vaccine = request.ConvertRequestToVaccineModel();
            _vaccineService.Add(vaccine);

            return await Task.FromResult(vaccine);
        }
    }
}
