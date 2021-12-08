using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stuff : MonoBehaviour
{
    //StoreData storeData = StoreData.Instance;

    public new string name;
    public string description;

    public Sprite artwork;
    public Sprite artwork_bw;

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

    public void Awake()
    {

    }
    public void DisplayStats()
    {
        //storeData.updateAmount(this.name, this.amountLeft);
        nameText.text = this.name;
        descriptionText.text = this.description;
        if (amountLeft != 0) artworkImage.sprite = this.artwork;
        else artworkImage.sprite = this.artwork_bw;

        costText.text = "Cost: $" + this.cost.ToString();
        energyText.text = "Energy: " + this.energy.ToString();
        hungerText.text = "Hunger: +" + this.hunger.ToString();
        happinessText.text = "Happiness: +" + this.happiness.ToString();
        intelligenceText.text = "Intelligence: +" + this.intelligence.ToString();
        amountLeftText.text = "Amount left: " + this.amountLeft.ToString();
    }


}
