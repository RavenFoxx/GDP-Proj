using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    PlayerData playerData = PlayerData.Instance;
    StoreData storeData = StoreData.Instance;
    public Text nameText;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        
    }
    public void ExitShop()
    {
        SceneManager.UnloadSceneAsync("StoreAction");
        //storeData.restockItems(); //for testing if it works - it worked so problem is it doesnt run when the next day happens
        //also idk why the noodles dont update? but the rest do
    }

    public void onPurchase()
    {
        Stuff selectedStuff = GameObject.FindGameObjectWithTag(nameText.text).GetComponent<Stuff>();
        if (playerData.Money >= selectedStuff.cost)
        {
            if (selectedStuff.amountLeft > 0)
            {
                printData();
                print(selectedStuff);
                playerData.Money -= selectedStuff.cost;
                playerData.Energy += selectedStuff.energy;
                playerData.Hunger += selectedStuff.hunger;
                playerData.Happiness += selectedStuff.happiness;
                playerData.Intelligence += selectedStuff.intelligence;
                selectedStuff.amountLeft--;
                selectedStuff.DisplayStats();
                storeData.updateAmount(selectedStuff.name, selectedStuff.amountLeft);
                printData();
            }
            else
            {
                print("no more left!");
            }
        }
        else
        {
            print("not enough money!");
        }
    }

    void printData()
    {
        print("Money: " + playerData.Money);
        print("Energy " + playerData.Energy);
        print("Hunger: " + playerData.Hunger);
        print("Happiness: " + playerData.Happiness);
        print("Intelligence: " + playerData.Intelligence);
    }
    //for player UI
    public Text Money;
    public Slider Energy;
    public Slider Hunger;
    public Slider Happiness;
    public void UpdateValues()
    {
        Energy.value = (float)playerData.Energy / 100;
        Hunger.value = (float)playerData.Hunger / 100;
        Happiness.value = (float)playerData.Happiness / 100;
        Money.text = "Money: $" + playerData.Money;
    }
    private void Update()
    {
        UpdateValues();
    }
}
