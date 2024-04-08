using MediatR;

namespace WasteControl.Application.Commands.TransportCompanies.DeleteTransportCompany
{
    public class DeleteTransportCompanyCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
    }
}