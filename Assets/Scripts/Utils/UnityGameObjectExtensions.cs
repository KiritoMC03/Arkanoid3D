using System;
using UnityEngine;

namespace Utils
{
    public static class UnityGameObjectExtensions
    {
        public static Interface GetInterface<Interface>(this GameObject thisGameObject, string usedObjectInspectorName = "")
        {
            var obj = thisGameObject.GetComponent<Interface>();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                throw new NullReferenceException($"Component {usedObjectInspectorName} does not implemet the target interface.");
            }
        }

        public static Interface GetInterface<Interface>(this Component thisComponent, string usedComponentInspectorName = "")
        {
            return thisComponent.gameObject.GetInterface<Interface>(usedComponentInspectorName);
        }
    }
}
