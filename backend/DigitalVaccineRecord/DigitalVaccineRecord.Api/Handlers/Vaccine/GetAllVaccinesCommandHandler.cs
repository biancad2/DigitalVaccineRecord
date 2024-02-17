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
            //try
            //{
            var vaccines = await _VaccineService.GetAllAsync();

            //await _mediator.Publish(new VaccineUpdatedNotification(Vaccine));

            return vaccines;
            //}
            //catch (Exception ex)
            //{
            //await _mediator.Publish(new VaccineCreatedNotification(Vaccine));
            //await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            //return await Task.FromResult("Error");
        }
    }
}
