using Virvon.MyBackery.Items;

namespace Virvon.MyBackery.Equipment
{
    internal interface IGivable : ITakable
    {
        ItemType ItemType { get; }

        bool TryGive(Stackable item);
    }
}
