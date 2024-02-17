using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.Vaccine
{
    public class GetVaccineHandle : IRequestHandler<GetVaccineRequest, VaccineModel>
    {
        private readonly IMediator _mediator;
        private readonly IVaccineService _VaccineService;
        public GetVaccineHandle(IMediator mediator, IVaccineService service)
        {
            this._mediator = mediator;
            this._VaccineService = service;
        }

        public async Task<VaccineModel> Handle(GetVaccineRequest request, CancellationToken cancellationToken)
        {
            //try
            //{
            var Vaccine = _VaccineService.Get(request.Id);

            //await _mediator.Publish(new VaccineCreatedNotification(Vaccine));

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
