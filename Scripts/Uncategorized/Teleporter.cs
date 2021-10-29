using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
    private Transform _portal1;
    private Transform _portal2;

    void Start()
    {
        _portal1 = GameObject.Find("Portal1").GetComponent<Transform>();
        _portal2 = GameObject.Find("Portal2").GetComponent<Transform>();
    }

    void Update()
    {
        if(this.transform.position.x < _portal1.position.x)
        {
            this.transform.position = new Vector3(_portal2.transform.position.x, transform.position.y,transform.position.z);
        }
        if (this.transform.position.x > _portal2.position.x)
        {
            this.transform.position = new Vector3(_portal1.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
