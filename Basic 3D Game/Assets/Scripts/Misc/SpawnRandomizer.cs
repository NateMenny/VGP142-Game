using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomizer : MonoBehaviour
{
    public List<GameObject> objectSpawnList;
    public List<Transform> spawnTransforms;

    public bool randomizeObjects;
    // Start is called before the first frame update
    void Start()
    {
        if(spawnTransforms.Count> 0 && objectSpawnList.Count > 0)
        {
            
            for(int i = 0; i < objectSpawnList.Count; i++)
            {
                try
                {
                    GameObject spawnObj = objectSpawnList[i];
                    if (randomizeObjects)
                    {
                        int objectsRandInt = UnityEngine.Random.Range(0, objectSpawnList.Count - 1);
                        spawnObj = objectSpawnList[objectsRandInt];
                    }
                    int spawnTransformRandInt = UnityEngine.Random.Range(0, spawnTransforms.Count - 1);

                    Instantiate(spawnObj, spawnTransforms[spawnTransformRandInt].position, spawnTransforms[spawnTransformRandInt].rotation);
                }
                catch (IndexOutOfRangeException e)
                {
                    Debug.Log("You dun GOOFED \n" + e.Message);
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomObjectSelection()
    {

    }
}
