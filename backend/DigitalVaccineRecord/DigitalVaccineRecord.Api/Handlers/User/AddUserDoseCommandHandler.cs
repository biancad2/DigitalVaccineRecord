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
            _userService.AddUserDose(dose);

            return await Task.FromResult(dose);
        }
    }
}
