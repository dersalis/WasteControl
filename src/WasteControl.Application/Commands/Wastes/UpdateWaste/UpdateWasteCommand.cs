using MediatR;

namespace WasteControl.Application.Commands.Wastes.UpdateWaste
{
    public class UpdateWasteCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}