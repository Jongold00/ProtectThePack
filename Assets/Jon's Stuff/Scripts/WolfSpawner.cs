using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{

    public float SpawnInterval;
    public float spawnRadius;
    public GameObject wolfPrefab;

    float spawnTimer;

    bool isNighttime;

    LightingManager dayCycle;

    public void Start()
    {
        dayCycle = FindObjectOfType<LightingManager>();
    }
    public void Update()
    {
        if (dayCycle.TimeOfDay > 18 || dayCycle.TimeOfDay < 6)
        {
            isNighttime = true;
        }
        else
        {
            isNighttime = false;
        }

        if (isNighttime)
        {
            if (spawnTimer <= 0)
            {
                spawnTimer = SpawnInterval;
                SpawnWolf(ChooseSpawnLocation());
            }
            spawnTimer -= Time.deltaTime;
        }


    }

    Vector3 ChooseSpawnLocation()
    {
        Vector3 ret = Random.onUnitSphere * spawnRadius;
        ret.y = 0;
        return ret;
    }

    void SpawnWolf(Vector3 location)
    {
        Instantiate(wolfPrefab, location, new Quaternion(0,0,0,0));
    }
}
