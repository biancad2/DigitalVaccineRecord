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
            var Vaccine = request.ConvertRequestToVaccineModel();
            //try
            //{
            _VaccineService.Edit(Vaccine);

            //await _mediator.Publish(new VaccineUpdatedNotification(Vaccine));

            return await Task.FromResult(Vaccine);
            //}
            //catch (Exception ex)
            //{
            //await _mediator.Publish(new VaccineCreatedNotification(Vaccine));
            //await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            //return await Task.FromResult("Error");
        }
    }
}
