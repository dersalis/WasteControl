using MediatR;

namespace WasteControl.Application.Commands.TransportCompanies.DeleteTransportCompany
{
    public class DeleteTransportCompanyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}