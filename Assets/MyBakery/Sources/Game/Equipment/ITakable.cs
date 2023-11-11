using Virvon.MyBackery.Items;

namespace Virvon.MyBackery.Equipment
{
    internal interface ITakable
    {
        EquipmentType Type { get; }

        bool TryTake(out Stackable item);
    }
}
