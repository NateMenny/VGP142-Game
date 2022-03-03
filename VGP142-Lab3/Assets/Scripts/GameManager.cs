using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager instance;

    private GameObject player;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int playerLives;

    public static GameManager Instance { get => instance; }
    public GameObject Player { get => player; }
    public GameObject PlayerPrefab { get => playerPrefab; }
    public int PlayerLives { get => playerLives; }

    private void Awake()
    {
        if (!instance) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    void Start()
    {
        if (!(player = FindObjectOfType<PlayerController>().gameObject))
        {
            Debug.Log("PLAYER COULD NOT BE FOUND");
        }

        if (playerLives == 0) playerLives = 2;
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
            if (playerLives < 0) GameIsOver();
        }
        return player;
    }

    void GameIsOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
