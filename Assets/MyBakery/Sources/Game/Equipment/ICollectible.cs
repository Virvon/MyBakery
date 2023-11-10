using Virvon.MyBackery.Items;

namespace Virvon.MyBackery.Equipment
{
    internal interface ICollectible
    {
        bool TryTakeItem(ItemType type, out Stackable item);
        bool TryGiveItem(Stackable item);
    }
}
