using System;
using UnityEngine;

namespace Utils
{
    public static class UnityGameObjectExtensions
    {
        public static Interface GetInterface<Interface>(this GameObject thisGameObject, string usedObjectInspectorName = "")
        {
            try
            {
                var obj = thisGameObject.GetComponent<Interface>();
                if (obj.NotEquals(null))
                {
                    return obj;
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException($"Component {usedObjectInspectorName} does not implemet the target interface.");
            }
            return default;
        }

        public static Interface GetInterface<Interface>(this Component thisComponent, string usedComponentInspectorName = "")
        {
            return thisComponent.gameObject.GetInterface<Interface>(usedComponentInspectorName);
        }
    }
}
