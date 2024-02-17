using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.Vaccine
{
    public class UpdateVaccineCommandHandler : IRequestHandler<UpdateVaccineCommand, VaccineModel>
    {
        private readonly IMediator _mediator;
        private readonly IVaccineService _VaccineService;
        public UpdateVaccineCommandHandler(IMediator mediator, IVaccineService service)
        {
            this._mediator = mediator;
            this._VaccineService = service;
        }

        public async Task<VaccineModel> Handle(UpdateVaccineCommand request, CancellationToken cancellationToken)
        {
            var vaccine = request.ConvertRequestToVaccineModel();
            _VaccineService.Edit(vaccine);

            return await Task.FromResult(vaccine);
        }
    }
}
