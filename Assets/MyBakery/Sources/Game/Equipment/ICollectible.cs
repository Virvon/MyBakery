namespace Virvon.MyBackery.Equipment
{
    internal interface ICollectible
    {
        bool TryTakeItem();
        bool TryGiveItem();
    }
}
