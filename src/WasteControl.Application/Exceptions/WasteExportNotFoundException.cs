using WasteControl.Core.Exceptions;

namespace WasteControl.Application.Exceptions
{
    public class WasteExportNotFoundException : BaseException
    {
        public WasteExportNotFoundException() : base("Waste export not found")
        {   
        }
    }
}