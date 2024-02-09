using WasteControl.Core.Exceptions;

namespace WasteControl.Application.Exceptions
{
    public class WasteNotFoundException : BaseException
    {
        public WasteNotFoundException() : base("Waste not found")
        {
            
        }
    }
}