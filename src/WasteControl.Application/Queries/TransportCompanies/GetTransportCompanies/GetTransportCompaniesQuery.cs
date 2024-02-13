using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.TransportCompanies.GetTransportCompanies
{
    public class GetTransportCompaniesQuery : IRequest<IEnumerable<CompanyDto>>
    {
        
    }
}