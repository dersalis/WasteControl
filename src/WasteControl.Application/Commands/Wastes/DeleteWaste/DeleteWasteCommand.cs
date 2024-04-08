using MediatR;

namespace WasteControl.Application.Commands.Wastes.DeleteWaste
{
    public class DeleteWasteCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
    }
}