using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stuff : MonoBehaviour
{
    StoreData storeData = StoreData.Instance;

    public new string name;
    public string description;

    public Sprite artwork;

    public int cost;
    public int energy;
    public int hunger;
    public int happiness;
    public int intelligence;
    public int amountLeft;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text costText;
    public Text energyText;
    public Text hungerText;
    public Text happinessText;
    public Text intelligenceText;
    public Text amountLeftText;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        amountLeft = storeData.getAmount(this.name);
        Debug.Log(storeData.getAmount(this.name));
    }

    public void DisplayStats()
    {
        nameText.text = this.name;
        descriptionText.text = this.description;
        artworkImage.sprite = this.artwork;

        costText.text = "Cost: $" + this.cost.ToString();
        energyText.text = "Energy: " + this.energy.ToString();
        hungerText.text = "Hunger: +" + this.hunger.ToString();
        happinessText.text = "Happiness: +" + this.happiness.ToString();
        intelligenceText.text = "Intelligence: +" + this.intelligence.ToString();
        amountLeftText.text = "Amount left: " + this.amountLeft.ToString();
    }

    public void UpdateStats()
    {

    }

    public string GetStuff()
    {
        return gameObject.tag;
    }
    // object ideas: energy drink, suit (wear to increase promotion chance), 
}
