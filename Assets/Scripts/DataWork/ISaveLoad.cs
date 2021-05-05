namespace Arkanoid.DataWork
{
    public interface ISaveLoad
    {
        int LoadInt(string key);
        void Save(string key, int value);
    }
}