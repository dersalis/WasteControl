namespace WasteControl.Application.DTO
{
    public class WasteDto : BaseDto
    {
        public String Code { get; set; }
        public String Name { get; set; }
        public Decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}