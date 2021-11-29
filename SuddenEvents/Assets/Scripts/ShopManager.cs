using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    PlayerData playerData = PlayerData.Instance;
    public Text nameText;
    public GameObject selectedObject;


    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }
    public void ExitShop()
    {
        SceneManager.UnloadSceneAsync("StoreAction");
    }

    public void onPurchase() // fix this so it only deducts from the selected
    {
        selectedObject = GameObject.FindGameObjectWithTag(nameText.text);
        var selectedStuff = selectedObject.GetComponent<Stuff>();
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
}
