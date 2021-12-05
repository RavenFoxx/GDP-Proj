using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SuddenEvents : MonoBehaviour
{
    PlayerData playerData = PlayerData.Instance;
    public float Money = 100;
    public int Energy;
    public int Hunger;
    public int Happiness;
    public GameObject popUpBox;
    public Animator animator;
    public Text popUpText;
    public Button yesButton;
    public Button noButton;

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }
    
    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }
    public void Scenario1Yes()
    {
 
        PlayerData.Instance.Energy -= 20;
        PlayerData.Instance.Hunger -= 10;
        popUpText.text = "bank replied there's an error on their part and gave 10 dollars as compensation";
    }
    public void Scenario1No()
    {
        PlayerData.Instance.Money -= 60;
        popUpText.text = "there's a hidden fee and tommy got charged 60 dollar without knowing, this could b avoid thru contacting the bank";
    }
    public void Scenario2Yes()
    {
        PlayerData.Instance.Money -= 30;
        PlayerData.Instance.Energy -= 20;
        PlayerData.Instance.Hunger -= 20;
        PlayerData.Instance.Happiness += 20;
        popUpText.text = "you had fun for the day";
    }
    public void Scenario2No()
    {
        PlayerData.Instance.Happiness -= 10;
        popUpText.text = " you felt a little sad as you decline his offer to hang out";

    }
    public void Scenario3Yes()
    {
        PlayerData.Instance.Money += 30;
        PlayerData.Instance.Energy -= 20;
        PlayerData.Instance.Hunger -= 20;
        PlayerData.Instance.Happiness += 20;

        popUpText.text = "gain 20 dollar as well as being treated a meal by your uncle)";
    }
    public void Scenario3No()
    {
        popUpText.text = "your uncle replied that he'll find someone else";
    }
    public void Scenario4Yes()
    {
        PlayerData.Instance.Money -= 50;
        PlayerData.Instance.Happiness += 20;

        popUpText.text = "you like your new bag";

    }
    public void Scenario4No()
    {
        PlayerData.Instance.Money -= 30;

        popUpText.text = "you have a new bag";
    }
    public void Scenario5Yes()
    {


        PlayerData.Instance.Energy -= 40;
        PlayerData.Instance.Happiness += 30;

        popUpText.text = "you enjoyed playing basketball with your friends";

    }
    public void Scenario5No()
    {
        
        PlayerData.Instance.Happiness -= 10;

        popUpText.text = "you're disheartened that you can't play";


    }
 
    public void closePopUp()
    {
        popUpBox.SetActive(false);
    }

}
            
        






  



  
