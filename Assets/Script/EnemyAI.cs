using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform maaranPaa;
    [SerializeField] NavMeshAgent olio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 olioMaaranPaa = new Vector3(maaranPaa.position.x, maaranPaa.position.y, maaranPaa.position.z);
        olio.SetDestination(olioMaaranPaa);
    }
}
