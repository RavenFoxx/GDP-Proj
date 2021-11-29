using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    //Popups
    public GameObject bedPopup;
    public GameObject phonePopup;
    public GameObject compPopup;
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
        PlayerData.Instance.Energy = 100;
        PlayerData.Instance.Hunger -= hungerLoss;
        PlayerData.Instance.Day += 1;

        //checking values
        Debug.Log("Energy is " + PlayerData.Instance.Energy);
        Debug.Log("Happinesss is " + PlayerData.Instance.Happiness);
        Debug.Log("Money is " + PlayerData.Instance.Money);
        Debug.Log("Hunger is " + PlayerData.Instance.Hunger);
        Debug.Log("Day " + PlayerData.Instance.Day);
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
        PlayerData.Instance.Money -= moneyTaken;
        PlayerData.Instance.Happiness += happinessGain;
        PlayerData.Instance.Hunger += hungerGain;

        if (PlayerData.Instance.Happiness > 50)
        {
            PlayerData.Instance.Happiness = 50;
        }

        if (PlayerData.Instance.Hunger > 50)
        {
            PlayerData.Instance.Hunger = 50;
        }

        //check values
        Debug.Log("Energy is " + PlayerData.Instance.Energy);
        Debug.Log("Happinesss is " + PlayerData.Instance.Happiness);
        Debug.Log("Hunger is " + PlayerData.Instance.Hunger);
        Debug.Log("Money is " + PlayerData.Instance.Money);
        DisablePhonePopup();
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
        PlayerData.Instance.Energy -= energyTaken;
        PlayerData.Instance.Happiness += comHappinessGain;

        if (PlayerData.Instance.Happiness > 50)
        {
            PlayerData.Instance.Happiness = 50;
        }

        Debug.Log("Energy is " + PlayerData.Instance.Energy);
        Debug.Log("Happinesss is " + PlayerData.Instance.Happiness);
        DisableComPopup();
    }

    //Door
    public void LeaveHome()
    {
        SceneManager.UnloadSceneAsync("HomeAction");
        Debug.Log("Total Energy is " + PlayerData.Instance.Energy);
        Debug.Log("Total Happinesss is " + PlayerData.Instance.Happiness);
        Debug.Log("Total Hunger is " + PlayerData.Instance.Hunger);
        Debug.Log("Total Money is " + PlayerData.Instance.Money);
    }
    
}
