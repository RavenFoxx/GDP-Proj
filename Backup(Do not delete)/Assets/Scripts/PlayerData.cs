using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }
    public float Money;
    public float BankedMoney;
    public int Energy;
    public int Hunger;
    public int Happiness;
    public int Day;
    public int Intelligence;
    public int Goal;
    public int Wage;
    public string Name;
    public string NText;
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Day = 1;
            Money = 300;
            Energy = 100;
            Hunger = 50;
            Happiness = 50;
            Goal = 3000;
            Wage = 100;
        }
        else Destroy(gameObject);
    }
}
