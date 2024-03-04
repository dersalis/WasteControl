using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.WasteExports.GetWasteExports
{
    internal sealed class GetWasteExportsQueryHandler : IRequestHandler<GetWasteExportsQuery, IEnumerable<WasteExportDto>>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        private readonly IRepository<TransportCompany> _transportCompanyRepository;

        public GetWasteExportsQueryHandler(IRepository<WasteExport> wasteExportRepository, IRepository<ReceivingCompany> receivingCompanyRepository, IRepository<TransportCompany> transportCompanyRepository, IRepository<User> userRepository)
        {
            _wasteExportRepository = wasteExportRepository;
            _receivingCompanyRepository = receivingCompanyRepository;
            _transportCompanyRepository = transportCompanyRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<WasteExportDto>> Handle(GetWasteExportsQuery request, CancellationToken cancellationToken)
        {
            var wasteExports = await _wasteExportRepository.GetAllAsync();
            // var users = await _userRepository.GetAllAsync();
            // var receivingCompanies = await _receivingCompanyRepository.GetAllAsync();
            // var transportCompanies = await _transportCompanyRepository.GetAllAsync();

            return wasteExports.Select(w =>
            {
                // var createdBy = users.FirstOrDefault(u => u.Id == w.CreatedById);
                // var modifiedBy = users.FirstOrDefault(u => u.Id == w.ModifiedById);
                // var receivingCompany = receivingCompanies.FirstOrDefault(r => r.Id == w.ReceivingCompanyId);
                // var transportCompany = transportCompanies.FirstOrDefault(t => t.Id == w.TransportCompanyId);

                return new WasteExportDto
                {
                    Id = w.Id,
                    ReceivingCompanyName = w.ReceivingCompany is not null ? 
                        $"[{w.ReceivingCompany?.Code}] {w.ReceivingCompany?.Name}" : "",
                    TransportCompanyName = w.TransportCompany is not null ? 
                        $"[{w.TransportCompany?.Code}] {w.TransportCompany?.Name}" : "",
                    BookingDate = w.BookingDate,
                    Description = w.Description,
                    Status = w.Status,
                    IsActive = w.IsActive,
                    CreateDate = w.CreateDate?.Value,
                    // CreatedByName = createdBy is not null ? createdBy?.Name : "",
                    CreatedByName = w.CreatedBy is not null ? w.CreatedBy?.Name : "",
                    ModifiedDate = w.ModifiedDate?.Value,
                    // ModifiedBy = modifiedBy is not null ? modifiedBy?.Name : "",
                    ModifiedBy = w.ModifiedBy is not null ? w.ModifiedBy?.Name : "",
                };
            });
        }
    }
}