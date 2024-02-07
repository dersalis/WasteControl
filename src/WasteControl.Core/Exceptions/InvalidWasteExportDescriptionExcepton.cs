namespace WasteControl.Core.Exceptions
{
    public class InvalidWasteExportDescriptionExcepton : BaseException
    {
        public InvalidWasteExportDescriptionExcepton(string description) : base($"Invalid waste export description: {description}")
        {
            
        }
    }
}