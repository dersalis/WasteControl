using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.ReceivingCompanies.GetReceivingCompanies
{
    public class GetReceivingCompaniesQuery : IRequest<IEnumerable<CompanyDto>>
    {
        
    }
}