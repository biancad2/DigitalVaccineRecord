using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.Vaccine
{
    public class DeleteVaccineCommandHandler : IRequestHandler<DeleteVaccineCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IVaccineService _vaccineService;
        public DeleteVaccineCommandHandler(IMediator mediator, IVaccineService service)
        {
            this._mediator = mediator;
            this._vaccineService = service;
        }

        public async Task<bool> Handle(DeleteVaccineCommand request, CancellationToken cancellationToken)
        {
            _vaccineService.Delete(request.Id);

            return await Task.FromResult(true);
        }
    }
}
