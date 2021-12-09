using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SuddenEvents : MonoBehaviour
{
    PlayerData _inst = PlayerData.Instance;
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
    private void Start()
    {
        if (SceneManager.GetSceneByName("SuddenEvents 1").isLoaded) {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SuddenEvents 1"));
            popUpText.text = _inst.Name + " realised that " + _inst.Name + "'s current balance is 60 dollar short compared to the original balance.";
        }
        else if (SceneManager.GetSceneByName("SuddenEvents 2").isLoaded) {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SuddenEvents 2"));
            popUpText.text = _inst.Name + "'s friend asked if " + _inst.Name + " is keen to catch up while watching a movie.";
        }
        else if (SceneManager.GetSceneByName("SuddenEvents 3").isLoaded) {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SuddenEvents 3"));
            popUpText.text = _inst.Name + "'s uncle asked " + _inst.Name + " to help him pack and move his stuff into his new house.";
        }
        else if (SceneManager.GetSceneByName("SuddenEvents 4").isLoaded) {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SuddenEvents 4"));
            popUpText.text = _inst.Name + "'s bag is getting old and " + _inst.Name + " wants to get a new bag.";
        }
        else if (SceneManager.GetSceneByName("SuddenEvents 5").isLoaded) {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SuddenEvents 5"));
            popUpText.text = _inst.Name + "'s friends has invited " + _inst.Name + " to play basketball with them.";
        }
        else Debug.Log("Scene out of bounds or not found");
    }
    public void Scenario1Yes()
    {
        _inst.Energy -= 20;
        _inst.Hunger -= 10;
        popUpText.text = "The bank has replied and said that there's an error on their part and they have fixed it as well as given an additional 10 dollars as compensation.";
    }
    public void Scenario1No()
    {
        _inst.Money -= 60;
        popUpText.text = "There's a hidden fee and " + _inst.Name + " got charged 60 dollars without knowing, this could be avoided by contacting the bank.";
    }
    public void Scenario2Yes()
    {
        _inst.Money -= 30;
        _inst.Energy -= 20;
        _inst.Hunger -= 20;
        _inst.Happiness += 20;
        popUpText.text = _inst.Name + " had fun for the day.";
    }
    public void Scenario2No()
    {
        _inst.Happiness -= 10;
        popUpText.text = _inst.Name + " felt a little sad as " + _inst.Name + " decline his friend's offer to hang out.";
    }
    public void Scenario3Yes()
    {
        _inst.Money += 30;
        _inst.Energy -= 20;
        _inst.Hunger -= 20;
        _inst.Happiness += 20;
        popUpText.text = _inst.Name + " have been treated to a meal as well as received 20 dollars from his uncle.";
    }
    public void Scenario3No()
    {
        popUpText.text = _inst.Name + "'s uncle replied that he'll find someone else.";
    }
    public void Scenario4Yes()
    {
        _inst.Money -= 50;
        _inst.Happiness += 20;
        popUpText.text = _inst.Name + " like his new bag";
    }
    public void Scenario4No()
    {
        _inst.Money -= 30;
        popUpText.text = _inst.Name + " have a new bag";
    }
    public void Scenario5Yes()
    {
        _inst.Energy -= 40;
        _inst.Happiness += 30;
        popUpText.text = _inst.Name + " enjoyed playing basketball with his friends.";
    }
    public void Scenario5No()
    {
        _inst.Happiness -= 10;
        popUpText.text = _inst.Name + " is disheartened that he couldn't join his friends.";
    }
 
    public void closePopUp()
    {
        popUpBox.SetActive(false);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
    }

}
            
        






  



  
