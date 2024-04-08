using MediatR;

namespace WasteControl.Application.Commands.ReceivingCompanies.DeleteReceivingCompany
{
    public class DeleteReceivingCompanyCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
    }
}