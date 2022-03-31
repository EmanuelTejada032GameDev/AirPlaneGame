using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    delegate void SimpleMessagePrint();
    SimpleMessagePrint simpleMessagePrint;

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public GameObject GameOverScreen;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        GameOverScreen.SetActive(false);
        OnPlayerDeath += ShowGameOverScreen;
    }



    void Start()
    {
        // You can use += to add more than a method to a delegate and execute a bunch of differents methods
        simpleMessagePrint = PrintStartOfGame;         
        simpleMessagePrint.Invoke();
        simpleMessagePrint = PrintExtraMessage;
        simpleMessagePrint.Invoke();
    }


    private void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }
    private void PrintStartOfGame()
    {
        Debug.Log("The game started");
    }

    private void PrintExtraMessage()
    {
        Debug.Log("Printing an extra message");
    }

    public void PlayerKilled()
    {
        OnPlayerDeath?.Invoke();
    }
}
