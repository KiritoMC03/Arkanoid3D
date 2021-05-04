using System;
using UnityEngine;

namespace Utils
{
    public class Validator : MonoBehaviour
    {
        public static bool CheckField<T>(T field, string inspectorFieldName = "")
        {
            if (field.Equals(null))
            {
                throw new NullReferenceException($"{inspectorFieldName} field is null.");
            }
            return true;
        }
    }
}