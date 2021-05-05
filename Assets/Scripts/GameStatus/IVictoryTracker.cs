using UnityEngine.Events;

namespace Arkanoid.GameStatus
{
    public interface IVictoryTracker
    {
        UnityEvent OnVictoryLink { get; }
    }
}