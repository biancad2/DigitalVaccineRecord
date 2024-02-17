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
        private readonly IVaccineService _VaccineService;
        public DeleteVaccineCommandHandler(IMediator mediator, IVaccineService service)
        {
            this._mediator = mediator;
            this._VaccineService = service;
        }

        public async Task<bool> Handle(DeleteVaccineCommand request, CancellationToken cancellationToken)
        {
            //var Vaccine = request.ConvertRequestToVaccineModel();
            //try
            //{
            _VaccineService.Delete(request.Id);

            //await _mediator.Publish(new VaccineDeletedNotification(Vaccine));

            return await Task.FromResult(true);
            //}
            //catch (Exception ex)
            //{
            //await _mediator.Publish(new VaccineCreatedNotification(Vaccine));
            //await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            //return await Task.FromResult("Error");
        }
    }
}
