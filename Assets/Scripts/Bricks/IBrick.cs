using UnityEngine.Events;

namespace Arkanoid.Bricks
{
    public interface IBrick
    {
        UnityEvent OnBallHitLink { get; }
        void Destroy();
    }
}