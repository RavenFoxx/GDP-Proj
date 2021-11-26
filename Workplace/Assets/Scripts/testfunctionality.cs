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
    public GameObject textDisplay;
    
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
        textDisplay.GetComponent<Text>().text = "You earned $" + MoneyEarned + " from working today!";
        PlayerData.Instance.Energy -= 50;
        Debug.Log("You lost 50 energy from working.");
        //textDisplay.GetComponent<Text>().text = " You lost" +  
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
            textDisplay.GetComponent<Text>().text = "Sorry, You do not meet the requirements!";
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
                textDisplay.GetComponent<Text>().text = "Congratulations, You have been promoted and now have higher pay!";
                MoneyEarned += 50;
                currentChanceToPromote = 0.0f;
            }
            if(Random.value > currentChanceToPromote)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                textDisplay.GetComponent<Text>().text = "Congratulations, You have been promoted and now have higher pay!";
                MoneyEarned += 50;
                currentChanceToPromote = 0.0f;
            }
            else
            {
                Debug.Log("Sorry, You have failed to promote!");
                currentChanceToPromote -= 0.05f;
                textDisplay.GetComponent<Text>().text = "Sorry, You have failed to promote!";
            }
        }      
    }
}
