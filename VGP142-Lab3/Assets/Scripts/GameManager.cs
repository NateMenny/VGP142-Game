using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager instance;

    private GameObject player;
    private SaveableData playerData;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int playerLives;
    [SerializeField] private BasicLeveManager currentLevelManager;

    public static GameManager Instance { get => instance; }
    public GameObject Player { get => player; }
    public GameObject PlayerPrefab { get => playerPrefab; }
    public int PlayerLives { get => playerLives; }
    public BasicLeveManager CurrentLevelManager { get => currentLevelManager; }

    private void Awake()
    {
        if (!instance) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(instance);
    }

    void Start()
    {
        if (!(player = FindObjectOfType<PlayerController>().gameObject))
        {
            Debug.Log("PLAYER COULD NOT BE FOUND");
        }
        if (!(currentLevelManager = FindObjectOfType<BasicLeveManager>()))
        {
            Debug.Log("LEVEL MANAGER COULD NOT BE FOUND");
        }

        playerData = FileSaver.Instance.LoadData(Application.dataPath + "/SaveGameData/GameSaveData.text");

        if (playerData == null)
        {
            Debug.Log("NO SAVE DATA FOUND");
            playerData = new SaveableData();
        }
        else
        {
            playerLives = playerData.playerLives;
            currentLevelManager.checkpoints[0].position = new Vector3(playerData.checkpointPositionX, playerData.checkpointPositionY, playerData.checkpointPositionZ);
        }

        if (playerLives <= 0) playerLives = 3;
        UpdateSaveData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnPlayer(Transform location_)
    {
        if (player == null)
        {
            player = Instantiate(playerPrefab, location_.position, location_.rotation);
            playerLives--;
            UpdateSaveData();
            if (playerLives < 0) GameIsOver();
        }
        return player;
    }

    void GameIsOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        UpdateSaveData();
        FileSaver.Instance.SaveData(playerData);
    }

   private void UpdateSaveData()
    {
        // Player Data
        playerData.playerLives = playerLives;

        // Checkpoint Data
        playerData.checkpointPositionX = currentLevelManager.checkpoints[0].position.x;
        playerData.checkpointPositionY = currentLevelManager.checkpoints[0].position.y;
        playerData.checkpointPositionZ = currentLevelManager.checkpoints[0].position.z;
    }
}
