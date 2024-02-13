using WasteControl.Core.Exceptions;

namespace WasteControl.Application.Exceptions
{
    public class ReceivingCompanyNotFoundException : BaseException
    {
        public ReceivingCompanyNotFoundException() : base("Receiving company not found")
        {
            
        }
    }
}