using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTesting : MonoBehaviour
{
     List<SimpleEnemy> enemies = new List<SimpleEnemy>()
    {
        new SimpleEnemy() { hp= 10, damage = 5},
        new SimpleEnemy() { hp= 20, damage = 3},
    };


    [Space]
    [Header("VariableGroup1")]
    [SerializeField]
    private int someVariable = 0;
    [SerializeField]
    [Range(0,5)]
    private float someVariable1 = 0;

    [Space]
    [Header("VariableGroup2")]
    [SerializeField]
    [Min(0)]
    private int someVariable2 = 0;
    [HideInInspector]
    private int someVariable3 = 0;

    [Space]
    [Header("Texts")]
    public string name = "emanuel";
    [TextArea]
    [Tooltip("One of the great things on games")]
    public string description = "This is a description";

    public Dictionary<string, PlayerData> playerDict = new Dictionary<string, PlayerData>();

    private void Start()
    {
            Debug.LogWarning("Send a warning to the console");
            Debug.LogError("Send a Error to the console");
            foreach (SimpleEnemy enemy in enemies)
            {
                Debug.LogFormat($"<color=red> The enemy has {enemy.hp} hp and {enemy.damage} damage </color>");
            }

            playerDict["PedroElPro"] = new PlayerData("Pedro", 10);
            playerDict["JMaster"] = new PlayerData("Juan", 100);

            foreach (PlayerData player in playerDict.Values)
            {
                Debug.Log(player.name);
            }
    }

    [ContextMenu("Call print name")] // You can have this function on your script menu on the three dots
    public void PrintName()
    {
        Debug.Log($"Player name is {name}");
    }

    public SimpleEnemy enemy;

}



[System.Serializable]
public class SimpleEnemy
{
    public int hp;
    public int damage;
}

public class PlayerData
{
    public string name;
    public int score;

    public PlayerData(string nameP, int scoreP)
    {
        name = nameP;
        score = scoreP;
    }
}