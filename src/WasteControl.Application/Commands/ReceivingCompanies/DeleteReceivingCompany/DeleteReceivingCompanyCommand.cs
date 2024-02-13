using MediatR;

namespace WasteControl.Application.Commands.ReceivingCompanies.DeleteReceivingCompany
{
    public class DeleteReceivingCompanyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}