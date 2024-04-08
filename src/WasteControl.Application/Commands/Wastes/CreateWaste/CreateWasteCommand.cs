using MediatR;

namespace WasteControl.Application.Commands.Wastes.CreateWaste
{
    public class CreateWasteCommand : CommandBase, IRequest<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}