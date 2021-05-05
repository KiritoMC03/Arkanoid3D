using UnityEngine;
using UnityEngine.Events;

namespace Arkanoid.GameStatus
{
    public class VictoryTracker : MonoBehaviour, IVictoryTracker
    {
        public UnityEvent OnVictoryLink { get => OnVictory; }
        public UnityEvent OnVictory;
    }
}