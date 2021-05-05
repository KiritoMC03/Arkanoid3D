using ObjectPool;

namespace Arkanoid.Ball
{
    public interface IBall
    {
        ObjectPooler.ObjectInfo.ObjectType Type { get; }
        void ResetRigidbody();
        void Destroy();
    }
}
