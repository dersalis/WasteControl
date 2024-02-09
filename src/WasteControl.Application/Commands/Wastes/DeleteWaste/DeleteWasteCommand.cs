using MediatR;

namespace WasteControl.Application.Commands.Wastes.DeleteWaste
{
    public class DeleteWasteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}