using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timemachinecontroller : MonoBehaviour
{
    public float health = 100;
    public GameObject tmobj;
    public AudioClip sound;
    private AudioSource adso;

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
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("menu");
        }
    }
}
