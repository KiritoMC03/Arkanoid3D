using UnityEngine;
using Arkanoid.Bricks;
using Utils;

namespace Arkanoid.Ball
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Ball : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            var brick = collision.gameObject.GetComponent<IBrick>();
            if (brick != null)
            {
                brick.OnBallHitLink?.Invoke();
            }
        }
    }
}