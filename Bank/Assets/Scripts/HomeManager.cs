using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    PlayerData _inst = PlayerData.Instance;
    //Popups
    public GameObject bedPopup;
    public GameObject phonePopup;
    public GameObject compPopup;
    public GameObject infoPopup;
    //Text
    public Text text;
    //Buttons
    public Button bedBtn;
    public Button phoneBtn; 
    public Button computerBtn;
    public Button doorBtn;
    //Fade screen
    public bool fadeNow;
    public Animator anim;

    //Bed values- sleeping
    private int hungerLoss = 10;
    //Phone values - calling delivery
    public int happinessGain = 5;
    public int hungerGain = 30;
    public int moneyTaken = 25;
    //Computer values - browsing online
    public int comHappinessGain = 20;
    public int energyTaken = 30;


    // Update is called once per frame
    void Update()
    {
        if (fadeNow)
        {
            fadeOut();
            Invoke("fadeIn", 1f);
            fadeNow = false;
        }
        UpdateValues();
    }
    //Fade animation
    private void fadeOut()
    {
        anim.SetTrigger("FadeOut");
    }

    private void fadeIn()
    {
        anim.SetTrigger("FadeIn");
    }

    //Bed
    public void ShowBedPopup()
    {
        bedPopup.SetActive(true);
        phoneBtn.interactable = false;
        computerBtn.interactable = false;
        doorBtn.interactable = false;
        
    }

    public void DisableBedPopup()
    {
        bedPopup.SetActive(false);
        phoneBtn.interactable = true;
        computerBtn.interactable = true;
        doorBtn.interactable = true;
    }

    public void SleepNow()
    {
        fadeNow = true;
        _inst.Energy = 100;
        _inst.Hunger -= hungerLoss;
        _inst.Day += 1;

        //checking values
        //Debug.Log("Energy is " + _inst.Energy);
        //Debug.Log("Happinesss is " + _inst.Happiness);
        //Debug.Log("Money is " + _inst.Money);
        //Debug.Log("Hunger is " + _inst.Hunger);
        //Debug.Log("Day " + _inst.Day);
        DisableBedPopup();
    }

    //Phone
    public void ShowPhonePopup()
    {
        phonePopup.SetActive(true);
        bedBtn.interactable = false;
        computerBtn.interactable = false;
        doorBtn.interactable = false;

    }
    public void DisablePhonePopup()
    {
        phonePopup.SetActive(false);
        bedBtn.interactable = true;
        computerBtn.interactable = true;
        doorBtn.interactable = true;
    }
    public void CallingDelivery()
    {
        if (_inst.Money >= 25)
        {
            _inst.Money -= moneyTaken;
            _inst.Happiness += happinessGain;
            _inst.Hunger += hungerGain;

            if (_inst.Happiness > 50)
            {
                _inst.Happiness = 50;
            }

            if (_inst.Hunger > 50)
            {
                _inst.Hunger = 50;
            }

            //check values
            //Debug.Log("Energy is " + _inst.Energy);
            //Debug.Log("Happinesss is " + _inst.Happiness);
            //Debug.Log("Hunger is " + _inst.Hunger);
            //Debug.Log("Money is " + _inst.Money);
            DisablePhonePopup();
        }
        else
        {
            DisablePhonePopup();
            infoPopup.SetActive(true);
            text.text = "You have no more money!";

        }
    }

    //Computer
    public void ShowComPopup()
    {
        compPopup.SetActive(true);
        phoneBtn.interactable = false;
        bedBtn.interactable = false;
        doorBtn.interactable = false;
    }
    public void DisableComPopup()
    {
        compPopup.SetActive(false);
        phoneBtn.interactable = true;
        bedBtn.interactable = true;
        doorBtn.interactable = true;
    }
    public void BrowsingOnline()
    {
        if(_inst.Energy >= 30)
        {
            _inst.Energy -= energyTaken;
            _inst.Happiness += comHappinessGain;

            if (_inst.Happiness > 50)
            {
                _inst.Happiness = 50;
            }

            //Debug.Log("Energy is " + _inst.Energy);
            //Debug.Log("Happinesss is " + _inst.Happiness);
            DisableComPopup();
        }
        else
        {
            DisableComPopup();
            infoPopup.SetActive(true);
            text.text = "You have no more Energy!";
        }
    }
    //infoPopup

    public void Okay()
    {
        infoPopup.SetActive(false);
    }

    //Door
    public void LeaveHome()
    {
        SceneManager.UnloadSceneAsync("HomeAction");
        //Debug.Log("Total Energy is " + _inst.Energy);
        //Debug.Log("Total Happinesss is " + _inst.Happiness);
        //Debug.Log("Total Hunger is " + _inst.Hunger);
        //Debug.Log("Total Money is " + _inst.Money);
    }
    //for player UI
    public Text Money;
    public Slider Energy;
    public Slider Hunger;
    public Slider Happiness;
    public void UpdateValues()
    {
        Energy.value = (float)_inst.Energy / 100;
        Hunger.value = (float)_inst.Hunger / 100;
        Happiness.value = (float)_inst.Happiness / 100;
        Money.text = "Money: $" + _inst.Money;
    }
}
