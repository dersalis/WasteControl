using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.ReceivingCompanies.GetReceivingCompanyById
{
    public class GetReceivingCompanyByIdQuery : IRequest<CompanyDto>
    {
        public Guid Id { get; set; }
    }
}