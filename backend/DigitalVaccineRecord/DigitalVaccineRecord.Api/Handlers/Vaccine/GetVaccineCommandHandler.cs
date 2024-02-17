using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.Vaccine
{
    public class GetVaccineCommandHandler : IRequestHandler<GetVaccineCommand, VaccineModel>
    {
        private readonly IMediator _mediator;
        private readonly IVaccineService _vaccineService;
        public GetVaccineCommandHandler(IMediator mediator, IVaccineService service)
        {
            this._mediator = mediator;
            this._vaccineService = service;
        }

        public async Task<VaccineModel> Handle(GetVaccineCommand request, CancellationToken cancellationToken)
        {
            var vaccine = _vaccineService.Get(request.Id);


            return await Task.FromResult(vaccine);
        }
    }
}
