using WasteControl.Core.Exceptions;

namespace WasteControl.Application.Exceptions
{
    public class TransportCompanyNotFoundException : BaseException
    {
        public TransportCompanyNotFoundException() : base("Transport company not found.")
        {
            
        }
    }
}