using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class Waste : BaseEntity
    {
        public WasteCode Code { get; private set; }
        public WasteName Name { get; private set; }
        public WasteQuantity Quantity { get; private set; }
        public WasteUnit Unit { get; private set; }

        public Waste(WasteCode code, WasteName name, WasteQuantity quantity, WasteUnit unit)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public void ChangeCode(string code)
        {
            Code = new WasteCode(code);
        }

        public void ChangeName(string name)
        {
            Name = new WasteName(name);
        }

        public void ChangeQuantity(decimal quantity)
        {
            Quantity = new WasteQuantity(quantity);
        }

        public void ChangeUnit(string unit)
        {
            Unit = new WasteUnit(unit);
        }
    }
}