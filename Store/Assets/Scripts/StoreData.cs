using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData : MonoBehaviour
{
    public static StoreData Instance { get; private set; }
    public string[] itemNames = { "Burger", "Cup Noodles", "Energy Drink", "Coffee", "Educational book", "Tie", "Glasses" };
    public int burger_amt_left;
    public int noodles_amt_left;
    public int energydrink_amt_left;
    public int book_amt_left;
    public int tie_amt_left;
    public int coffee_amt_left;
    public int glasses_amt_left;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);

    }

    public void printAmountLeft()
    {
        print(burger_amt_left + noodles_amt_left + energydrink_amt_left + book_amt_left + tie_amt_left + coffee_amt_left + glasses_amt_left);
    }

    public void updateAmount(string name, int amt_left)
    {
        if (name == "Burger") burger_amt_left = amt_left;
        else if (name == "Cup Noodles")
        {
            noodles_amt_left = amt_left;
            print("updated noodles");
        }
        else if (name == "Energy Drink") energydrink_amt_left = amt_left;
        else if (name == "Coffee") coffee_amt_left = amt_left;
        else if (name == "Educational book") book_amt_left = amt_left;
        else if (name == "Tie") tie_amt_left = amt_left;
        else if (name == "Glasses") glasses_amt_left = amt_left;

    }

    public int getAmount(string name)
    {
        if (name == "Burger") return burger_amt_left;
        else if (name == "Cup Noodles") return noodles_amt_left;
        else if (name == "Energy Drink") return energydrink_amt_left;
        else if (name == "Coffee") return coffee_amt_left;
        else if (name == "Educational book") return book_amt_left;
        else if (name == "Tie") return tie_amt_left;
        else if (name == "Glasses") return glasses_amt_left;
        else return 100;
    }
    public void restockItems()
    {
        foreach (string i in itemNames) updateAmount(i, Random.Range(1, 4));
    }

}
