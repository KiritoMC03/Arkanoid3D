using UnityEngine.Events;

namespace Arkanoid.Stats
{
    public interface IScore
    {
        UnityEvent OnChangeLink { get; }
        UnityEvent OnMaxChangeLink { get; }
        int GetMaxValue();
        void Increase();
        void Save();
        void SetCountersText();
        void ResetValue();
    }
}