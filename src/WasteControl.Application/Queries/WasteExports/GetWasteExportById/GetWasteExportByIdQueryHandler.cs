using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.WasteExports.GetWasteExportById
{
    internal sealed class GetWasteExportByIdQueryHandler : IRequestHandler<GetWasteExportByIdQuery, WasteExportDto>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        private readonly IRepository<TransportCompany> _transportCompanyRepository;

        public GetWasteExportByIdQueryHandler(IRepository<WasteExport> wasteExportRepository, IRepository<User> userRepository, IRepository<ReceivingCompany> receivingCompanyRepository, IRepository<TransportCompany> transportCompanyRepository)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _receivingCompanyRepository = receivingCompanyRepository;
            _transportCompanyRepository = transportCompanyRepository;
        }

        public async Task<WasteExportDto> Handle(GetWasteExportByIdQuery request, CancellationToken cancellationToken)
        {
            var wasteExport = await _wasteExportRepository.GetAsync(request.Id);

            if (wasteExport is null)
                return default;

            var createdBy = await _userRepository.GetAsync(wasteExport.CreatedById);
            var modifiedBy = await _userRepository.GetAsync(wasteExport.ModifiedById);
            var receivingCompany = await _receivingCompanyRepository.GetAsync(wasteExport.ReceivingCompanyId);
            var transportCompany = await _transportCompanyRepository.GetAsync(wasteExport.TransportCompanyId);

            return new WasteExportDto
            {
                Id = wasteExport.Id,
                ReceivingCompanyName = wasteExport.ReceivingCompanyId is not null ? 
                    $"[{receivingCompany?.Code}] {receivingCompany?.Name}" : "",
                TransportCompanyName = wasteExport.TransportCompanyId is not null ? 
                    $"[{transportCompany?.Code}] {transportCompany?.Name}" : "",
                BookingDate = wasteExport.BookingDate,
                Description = wasteExport.Description,
                Status = wasteExport.Status,
                IsActive = wasteExport.IsActive,
                CreateDate = wasteExport.CreateDate?.Value,
                CreatedByName = createdBy is not null ? createdBy?.Name : "",
                ModifiedDate = wasteExport.ModifiedDate?.Value,
                ModifiedBy = modifiedBy is not null ? modifiedBy?.Name : "",
            };
        }
    }
}