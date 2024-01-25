using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform maaranPaa;
    [SerializeField] NavMeshAgent olio;
    [SerializeField] float health;
    public GameObject tmobj;
    // Start is called before the first frame update
    void Start()
    {
        olio = GetComponent<NavMeshAgent>();
        health = 100;
        maaranPaa = GameObject.FindGameObjectWithTag("maaranPaa").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 olioMaaranPaa = new Vector3(maaranPaa.position.x, maaranPaa.position.y, maaranPaa.position.z);
        olio.SetDestination(olioMaaranPaa);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage()
    {
        health -= 50;
    }
}
