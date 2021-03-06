using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Repository of commonly used prefabs.
/// </summary>
[AddComponentMenu("Gameplay/ObjectPool")]
public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance { get; private set; }

    #region member
    /// <summary>
    /// Member class for a prefab entered into the object pool
    /// </summary>
    /// ObjectPool.instance.GetObjectForType(object string, true); <---use to spawn
    /// _objectPoolScript = GameObject.FindWithTag(Tags.objectPoolTag).GetComponent<ObjectPool>();
    /// _objectPoolScript.PoolObject(gameObject); <---use instead of destroy
    [Serializable]
    public class ObjectPoolEntry
    {
        /// <summary>
        /// the object to pre instantiate
        /// </summary>
        [SerializeField]
        private GameObject _prefab;
        public GameObject Prefab
        {
            get
            {
                return _prefab;
            }

            set
            {
                _prefab = value;
            }
        }

        /// <summary>
        /// quantity of object to pre-instantiate
        /// </summary>
        [SerializeField]
        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
    }
    #endregion

    /// <summary>
    /// The object prefabs which the pool can handle
    /// by The amount of objects of each type to buffer.
    /// </summary>
    [SerializeField]
    private ObjectPoolEntry[] Entries;

    /// <summary>
    /// The pooled objects currently available.
    /// Indexed by the index of the objectPrefabs
    /// </summary>
    [HideInInspector]
    private List<GameObject>[] Pool;

    /// <summary>
    /// The container object that we will keep unused pooled objects so we dont clog up the editor with objects.
    /// </summary>
    /// use: GameObject obj = ObjectPool.instance.GetObjectForType(ObjectName, true/false); 
    /// to take objects from pool. True to limit objectpool to spawned objects, false to not limit the pool
    /// use: ObjectPool.instance.PoolObject(ObjectName); to put objects back into pool
    private GameObject _containerObject;

    void OnEnable()
    {
        instance = this;
    }

    // Use this for initialization
    void Awake()
    {
        _containerObject = this.gameObject;

        //Loop through the object prefabs and make a new list for each one.
        //We do this because the pool can only support prefabs set to it in the editor,
        //so we can assume the lists of pooled objects are in the same order as object prefabs in the array
        Pool = new List<GameObject>[Entries.Length];

        for (int i = 0; i < Entries.Length; i++)
        {
            var objectPrefab = Entries[i];

            //create the repository
            Pool[i] = new List<GameObject>();

            //fill it
            for (int n = 0; n < objectPrefab.Count; n++)
            {

                var newObj = Instantiate(objectPrefab.Prefab) as GameObject;

                newObj.name = objectPrefab.Prefab.name;

                PoolObject(newObj);
            }
        }
    }



    /// <summary>
    /// Gets a new object for the name type provided.  If no object type exists or if onlypooled is true and there is no objects of that type in the pool
    /// then null will be returned.
    /// </summary>
    /// <returns>
    /// The object for type.
    /// </returns>
    /// <param name='objectType'>
    /// Object type.
    /// </param>
    /// <param name='onlyPooled'>
    /// If true, it will only return an object if there is one currently pooled.
    /// </param>
    public GameObject GetObjectForType(string objectType, bool onlyPooled)
    {

        for (int i = 0; i < Entries.Length; i++)
        {
            var prefab = Entries[i].Prefab;

            if (prefab.name != objectType)
                continue;

            if (Pool[i].Count > 0)
            {

                GameObject pooledObject = Pool[i][0];

                Pool[i].RemoveAt(0);

                pooledObject.transform.parent = null;

                pooledObject.SetActive(true);

                return pooledObject;
            }
            if (!onlyPooled)
            {
                GameObject newObj = Instantiate(Entries[i].Prefab) as GameObject;
                newObj.name = Entries[i].Prefab.name;
                return newObj;
            }
        }

        //If we have gotten here either there was no object of the specified type or non were left in the pool with onlyPooled set to true
        return null;
    }

    /// <summary>
    /// Pools the object specified.  Will not be pooled if there is no prefab of that type.
    /// </summary>
    /// <param name='obj'>
    /// Object to be pooled.
    /// </param>
    public void PoolObject(GameObject obj)
    {

        for (int i = 0; i < Entries.Length; i++)
        {
            if (Entries[i].Prefab.name != obj.name)
                continue;

            Pool[i].Add(obj);

            obj.transform.parent = _containerObject.transform;

            obj.SetActive(false);

            return;
        }
    }
}