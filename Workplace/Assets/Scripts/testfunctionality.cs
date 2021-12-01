using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class testfunctionality : MonoBehaviour
{
    public int MoneyEarned = 100;
    public float minimumChanceToPromote = 0.1f;
    public float currentChanceToPromote;
    public Text textDisplay;
    
    private IEnumerator Working()
    {
        SceneManager.LoadSceneAsync("Workplace", LoadSceneMode.Additive);
        Debug.Log("Playing Animation");

        yield return new WaitForSecondsRealtime (5);
        SceneManager.UnloadSceneAsync("Workplace");
        Work();
    }
    public void GoToWork()
    {
        StartCoroutine(Working());      
    }

    public void Work()
    {
        PlayerData.Instance.Money += MoneyEarned;
        Debug.Log("You earned $100 from working today!");
        textDisplay.text = "You earned $" + MoneyEarned + " from working today!" + "\n" + "You lost 50 energy from working!";
        PlayerData.Instance.Energy -= 50;
        Debug.Log("You lost 50 energy from working.");
        //textDisplay.text = " You lost 50 energy from working!";
        currentChanceToPromote += 0.1f;
    }

    private IEnumerator Promoting()
    {
        SceneManager.LoadSceneAsync("PromotionScene", LoadSceneMode.Additive);
        Debug.Log("Playing Animation");

        yield return new WaitForSecondsRealtime(5);
        SceneManager.UnloadSceneAsync("PromotionScene");
        Promotion();
    }

    public void GoToPromote()
    {
        if(currentChanceToPromote < minimumChanceToPromote)
        {
            Debug.Log("Sorry, You do not meet the requirements!");
            textDisplay.text = "Sorry, You do not meet the requirements!";
        }
        else
        {
            StartCoroutine(Promoting());
        }
        
    } 
    public void Promotion()
    {
        if(currentChanceToPromote >= minimumChanceToPromote)
        {
            if(currentChanceToPromote == 1f)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                textDisplay.text = "Congratulations, You have been promoted and now have higher pay!";
                MoneyEarned += 50;
                currentChanceToPromote = 0.0f;
            }
            if(Random.value > currentChanceToPromote)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                textDisplay.text = "Congratulations, You have been promoted and now have higher pay!";
                MoneyEarned += 50;
                currentChanceToPromote = 0.0f;
            }
            else
            {
                Debug.Log("Sorry, You have failed to promote!");
                currentChanceToPromote -= 0.05f;
                textDisplay.text = "Sorry, You have failed to promote!";
            }
        }
    }

    public void displayChance()
    {
        textDisplay.text = "Current Chance to promote:" + currentChanceToPromote * 10;
    }

    public void displayWorkingConditions()
    {
        textDisplay.text = "Work to earn $" + MoneyEarned + " but lose 50 Energy?"; 
    }
    public void ExitWorkplace()
    {
        textDisplay.text = "You left your workplace.";
        SceneManager.UnloadSceneAsync("WorkplaceAction");
    }
}
