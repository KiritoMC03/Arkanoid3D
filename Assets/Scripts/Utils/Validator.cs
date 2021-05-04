using System;
using UnityEngine;

namespace Utils
{
    public class Validator : MonoBehaviour
    {
        public static bool CheckFieldOrException<T>(T field, string inspectorFieldName = "")
        {
            if (field == null)
            {
                throw new NullReferenceException($"{inspectorFieldName} field is null.");
            }
            return true;
        }
    }
}