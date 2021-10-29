using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

    [SerializeField]private float _destroyTime;

	void OnEnable () 
    {
        StartCoroutine(DestroyObject());
	}

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(_destroyTime);
        ObjectPool.instance.PoolObject(this.gameObject);
    }
}
