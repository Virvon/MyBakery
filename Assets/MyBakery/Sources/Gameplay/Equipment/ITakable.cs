using Virvon.MyBakery.Items;

namespace Virvon.MyBakery.Equipment
{
    internal interface ITakable
    {
        EquipmentType Type { get; }

        bool TryTake(out Stackable item);
    }
}
