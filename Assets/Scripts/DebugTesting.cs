using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTesting : MonoBehaviour
{
     List<Enemy> enemies = new List<Enemy>()
    {
        new Enemy() { hp= 10, damage = 5},
        new Enemy() { hp= 20, damage = 3},
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


    private void Start()
    {
        Debug.LogWarning("Send a warning to the console");
        Debug.LogError("Send a Error to the console");
        foreach (Enemy enemy in enemies)
        {
            Debug.LogFormat($"<color=red> The enemy has {enemy.hp} hp and {enemy.damage} damage </color>");
        }
    }

    [ContextMenu("Call print name")] // You can have this function on your script menu on the three dots
    public void PrintName()
    {
        Debug.Log($"Player name is {name}");
    }

    public Enemy enemy;

}



[System.Serializable]
public class Enemy
{
    public int hp;
    public int damage;
}