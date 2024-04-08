using MediatR;

namespace WasteControl.Application.Commands.TransportCompanies.UpdateTransportCompany
{
    public class UpdateTransportCompanyCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}