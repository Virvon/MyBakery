using Virvon.MyBackery.Items;

namespace Virvon.MyBackery.Equipment
{
    internal interface ICollectible
    {
        bool TryTakeItem(out Stackable item);
        bool TryGiveItem(Stackable item);
    }
}
