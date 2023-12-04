using Virvon.MyBakery.Items;

namespace Virvon.MyBakery.Equipment
{
    internal interface IGivable : ITakable
    {
        ItemType ItemType { get; }

        bool TryGive(Stackable item);
    }
}
