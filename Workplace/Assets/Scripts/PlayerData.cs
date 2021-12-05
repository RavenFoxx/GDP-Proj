using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }
    public float Money;
    public int Energy;
    public int Hunger;
    public int Happiness;
    public int Day;
    public int Intelligence;
    public int Goal;
    public string Name = "PlayerNameNotFound";
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Money = 300;
            Energy = 100;
            Hunger = 50;
            Happiness = 50;
            Goal = 3000;
        }
        else Destroy(gameObject);
    }
}
