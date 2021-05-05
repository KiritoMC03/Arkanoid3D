using UnityEngine;
using Utils;

namespace Arkanoid.Ball
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class StartImpulse : MonoBehaviour
    {
        [SerializeField] private Vector3 _value = Vector3.zero;
        private Rigidbody _rigidbody = null;

        private void Awake()
        {
            InitFields();
        }

        private void OnEnable()
        {
            _rigidbody.AddForce(_value, ForceMode.Impulse);
        }

        private void InitFields()
        {
            _rigidbody = GetComponent<Rigidbody>();
            if (_rigidbody.Equals(null))
            {
                ExceptionsStorage.ThrowNoComponent<Rigidbody>();
            }
        }
    }
}