using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Notifications;
using DigitalVaccineRecord.Core.Interfaces;
using DigitalVaccineRecord.Core.Models;
using MediatR;

namespace DigitalVaccineRecord.Api.Handlers.User
{
    public class AddUserDoseCommandHandler : IRequestHandler<AddUserDoseCommand, UserDoseModel>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public AddUserDoseCommandHandler(IMediator mediator, IUserService service)
        {
            this._mediator = mediator;
            this._userService = service;
        }

        public async Task<UserDoseModel> Handle(AddUserDoseCommand request, CancellationToken cancellationToken)
        {
            var dose = request.ConvertRequestToUserDoseModel();
            //try
            //{
            _userService.AddUserDose(dose);

            //await _mediator.Publish(new UserCreatedNotification(user));

            return await Task.FromResult(dose);
            //}
            //catch (Exception ex)
            //{
            //await _mediator.Publish(new UserCreatedNotification(user));
            //await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            //return await Task.FromResult("Error");
        }
    }
}
