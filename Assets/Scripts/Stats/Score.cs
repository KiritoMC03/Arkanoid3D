using UnityEngine;
using System.Collections;

namespace Arkanoid.Stats
{
    public class Score : MonoBehaviour
    {
        private static uint _value = 0;

        public static void Increase()
        {
            _value++;
        }
    }
}