using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.Vaccine
{
    public class GetAllVaccinesCommandHandler : IRequestHandler<GetAllVaccinesCommand, List<VaccineModel>>
    {
        private readonly IMediator _mediator;
        private readonly IVaccineService _VaccineService;
        public GetAllVaccinesCommandHandler(IMediator mediator, IVaccineService service)
        {
            this._mediator = mediator;
            this._VaccineService = service;
        }

        public async Task<List<VaccineModel>> Handle(GetAllVaccinesCommand request, CancellationToken cancellationToken)
        {
            var vaccines = await _VaccineService.GetAllAsync();

            return vaccines;
        }
    }
}
