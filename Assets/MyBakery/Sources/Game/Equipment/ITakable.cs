using Virvon.MyBackery.Items;

namespace Virvon.MyBackery.Equipment
{
    internal interface ITakable
    {
        bool TryTake(out Stackable item);
    }
}
