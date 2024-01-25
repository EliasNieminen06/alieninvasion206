using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timemachinecontroller : MonoBehaviour
{
    public float health = 100;
    public GameObject tmobj;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "triggered");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            health -= 20;
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            tmobj.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
