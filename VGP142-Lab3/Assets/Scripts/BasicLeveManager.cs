using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BasicLeveManager : MonoBehaviour
{
    public GameObject player;

    public Transform[] checkpoints;
    public Transform startPoint;
    public Transform endPoint;

    public string nextScene;
    public string prevScene;

    bool levelHasPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        player = GameManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToNextScene()
    {
        if(nextScene.Length > 0)
            SceneManager.LoadScene(nextScene);
    }

    public void SwitchToPrevScene()
    {
        if (prevScene.Length > 0)
            SceneManager.LoadScene(prevScene);
    }

    public void ContinueGame()
    {
        if (player == null) player = GameManager.Instance.SpawnPlayer(checkpoints[0]);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
