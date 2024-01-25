using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawner;
    [SerializeField] GameObject olio;
    private float nextSpawn;
    private float spawnRate = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int selectedSpawner = Random.Range(0, 5);
            Vector3 spawnPos = spawner[selectedSpawner].transform.position;
            Instantiate(olio, spawnPos, Quaternion.identity);
        }
    }
}
