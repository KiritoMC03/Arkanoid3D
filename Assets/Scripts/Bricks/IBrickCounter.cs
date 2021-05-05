namespace Arkanoid.Bricks
{
    public interface IBrickCounter
    {
        void Decrease(int value);
        int GetCount();
        void Increase(int value);
        void ResetCount();
    }
}