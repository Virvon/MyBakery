using Virvon.MyBackery.Items;

namespace Virvon.MyBackery.Equipment
{
    internal interface IGivable : ITakable
    {
        ItemType Type { get; }

        bool TryGive(Stackable item);
    }
}
