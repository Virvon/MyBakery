using Virvon.MyBakery.Items;

namespace Virvon.MyBakery.Equipment
{
    internal interface ICollectible
    {
        bool TryTakeItem(ItemType type, out Stackable item);
        bool TryGiveItem(Stackable item);
    }
}
