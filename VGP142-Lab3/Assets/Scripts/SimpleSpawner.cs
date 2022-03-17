using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> thingsICanSpawn;
    [SerializeField] List<GameObject> placesToSpawnThings;

    [Header("Settings")]
    [SerializeField] int amountToSpawn;
    [SerializeField] bool randomizeSpawnLocation;
    [SerializeField] bool randomizeThingToSpawn;

    bool canSpawnStuff;

    public bool CanSpawnStuff { get => canSpawnStuff;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (thingsICanSpawn.Count > 0 && placesToSpawnThings.Count > 0) canSpawnStuff = true;

        StartCoroutine(SpawnStuffAtLocations());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnStuffAtLocations()
    {
        Transform[] patrolPositions = FindObjectOfType<AIMovement>().PatrolPositions;
        for (int spawnCount = 0; spawnCount < amountToSpawn; spawnCount++)
        {
            if (canSpawnStuff)
            {
                GameObject whichThingToSpawn = null;
                if (randomizeThingToSpawn)
                {
                    whichThingToSpawn = thingsICanSpawn[Random.Range(0, thingsICanSpawn.Count)];
                }
                Transform whereToSpawnThing = null;
                if (randomizeSpawnLocation)
                {
                    whereToSpawnThing = placesToSpawnThings[Random.Range(0, placesToSpawnThings.Count)].GetComponent<Transform>();
                }
                
                GameObject spawnedThing = Instantiate(whichThingToSpawn, whereToSpawnThing.position, whereToSpawnThing.rotation);
                spawnedThing.GetComponent<AIMovement>().PatrolPositions = patrolPositions;
            }
        }
        yield return new WaitForEndOfFrame();
    }
}
