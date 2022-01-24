using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Terrain-Lab-Scene")
                SceneManager.LoadScene("SampleScene");
            else
                SceneManager.LoadScene("Terrain-Lab-Scene");
        }
    }
}
