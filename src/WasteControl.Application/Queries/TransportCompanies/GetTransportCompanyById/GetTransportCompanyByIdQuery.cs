using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.TransportCompanies.GetTransportCompanyById
{
    public class GetTransportCompanyByIdQuery : IRequest<CompanyDto>
    {
        public Guid Id { get; set; }
    }
}