using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData : MonoBehaviour
{
    public static StoreData Instance { get; private set; }
    public string[] itemNames = { "Burger", "Noodles", "EnergyDrink", "Coffee", "Book", "Tie", "Mask" };
    public int burger_amt_left = 3;
    public int noodles_amt_left;
    public int energydrink_amt_left;
    public int book_amt_left;
    public int tie_amt_left;
    public int coffee_amt_left;
    public int mask_amt_left;
    //burger instant noodles, energy drink, coffee, book, tie, disguise mask (give happiness)
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);

    }

    public void updateAmount(string name, int amt_left)
    {
        if (name == "Burger") burger_amt_left = amt_left;
        else if (name == "Noodles") noodles_amt_left = amt_left;
        else if (name == "EnergyDrink") energydrink_amt_left = amt_left;
        else if (name == "Coffee") coffee_amt_left = amt_left;
        else if (name == "Book") book_amt_left = amt_left;
        else if (name == "Tie") tie_amt_left = amt_left;
        else if (name == "Mask") mask_amt_left = amt_left;

    }
    
    public int getAmount(string name)
    {
        if (name == "Burger") return burger_amt_left;
        else if (name == "Noodles") return noodles_amt_left;
        else if (name == "EnergyDrink") return energydrink_amt_left;
        else if (name == "Coffee") return coffee_amt_left;
        else if (name == "Book") return book_amt_left;
        else if (name == "Tie") return tie_amt_left;
        else if (name == "Mask") return mask_amt_left;
        else return 0;
    }
    public void restockItems()
    {
        foreach (string i in itemNames) updateAmount(i, Random.Range(1, 4));
    }

}
