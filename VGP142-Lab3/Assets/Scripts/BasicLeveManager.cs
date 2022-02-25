using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BasicLeveManager : MonoBehaviour
{
    public GameObject player;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null && levelHasPlayer)
            SceneManager.LoadScene("GameOverScene");
    }

    public void SwitchToNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void SwitchToPrevScene()
    {
        SceneManager.LoadScene(prevScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
