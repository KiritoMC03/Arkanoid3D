using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace ObjectPool
{
    public class ObjectPooler : MonoBehaviour
    {
        internal static ObjectPooler Instance = null;
        [SerializeField] private List<ObjectInfo> objectsInfo;

        private Dictionary<ObjectInfo.ObjectType, Pool> pools;
        private GameObject emptyGameObject = null;
        private GameObject tempContainer = null;
        private GameObject tempStartGameObject = null;
        private GameObject tempInstantiateGameObject = null;

        [Serializable]
        public struct ObjectInfo
        {
            public enum ObjectType
            {
                Ball,
                Brick
            }
            public ObjectType Type;
            [Header("Require IPooledObject component.")]
            public GameObject Prefab;
            public int StartCount;
        }

        private void Awake()
        {
            emptyGameObject = new GameObject();

            if (Instance == null)
            {
                Instance = this;
            }

            InitPool();
        }

        private void InitPool()
        {
            pools = new Dictionary<ObjectInfo.ObjectType, Pool>();

            foreach (var obj in objectsInfo)
            {
                tempContainer = Instantiate(emptyGameObject, transform, false);
                tempContainer.name = obj.Type.ToString() + "_Pool";

                pools[obj.Type] = new Pool(tempContainer.transform);

                for (int i = 0; i < obj.StartCount; i++)
                {
                    tempStartGameObject = InstantiateObject(obj.Type, tempContainer.transform);
                    pools[obj.Type].objects.Enqueue(tempStartGameObject);
                }
            }
            Destroy(emptyGameObject);
        }

        private GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform parent)
        {
            tempInstantiateGameObject = Instantiate(objectsInfo.Find(elem => elem.Type == type).Prefab, parent);
            tempInstantiateGameObject.SetActive(false);
            return tempInstantiateGameObject;
        }

        public GameObject GetObject(ObjectInfo.ObjectType type)
        {
            var obj = (pools[type].objects.Count > 0) ?
                pools[type].objects.Dequeue() : InstantiateObject(type, pools[type].container);

            obj.SetActive(true);
            return obj;
        }

        public void DestroyObject(GameObject obj)
        {
            pools[obj.GetInterface<IPooledObject>().Type].objects.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}