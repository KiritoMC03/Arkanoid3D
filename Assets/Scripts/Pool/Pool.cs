using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Pool
    {
        internal Transform container { get; set; }
        internal Queue<GameObject> objects = null;

        public Pool(Transform container)
        {
            this.container = container;
            objects = new Queue<GameObject>();
        }
    }
}