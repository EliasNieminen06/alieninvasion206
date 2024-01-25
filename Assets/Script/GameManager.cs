using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawner;
    [SerializeField] GameObject olio;
    [SerializeField] TextMeshProUGUI scoretxt;
    private float nextSpawn;
    private float spawnRate = 2f;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score++;
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
        scoretxt.text = "Score: " + score.ToString();
    }
}
