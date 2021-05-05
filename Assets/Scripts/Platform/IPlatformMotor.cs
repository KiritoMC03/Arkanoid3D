using UnityEngine;

namespace Arkanoid.Platform
{
    public interface IPlatformMotor
    {
        void MoveTo(Vector3 position);
        void MoveToStartPosition();
        void SetStartPosition(Vector3 position);
    }
}