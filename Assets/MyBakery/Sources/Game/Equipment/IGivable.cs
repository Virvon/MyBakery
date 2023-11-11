namespace Virvon.MyBackery.Equipment
{
    internal interface IGivable : ITakable
    {
        bool TryGive();
    }
}
