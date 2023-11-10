using Virvon.MyBackery.Items;

namespace Virvon.MyBackery.Equipment
{
    internal interface ICollectible
    {
        bool TryTakeItem();
        bool TryGiveItem(Stackable item);
    }
}
