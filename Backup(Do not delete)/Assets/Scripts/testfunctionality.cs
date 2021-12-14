using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class testfunctionality : MonoBehaviour
{
    //Buttons
    public Button workButton;
    public Button promotionButton;
    public Button exitButton;
    //Popups
    public GameObject workPopup;
    public GameObject promotionPopup;

    public float minimumChanceToPromote = 0.1f;
    public float currentChanceToPromote;
    PlayerData _inst = PlayerData.Instance;
    //Text
    public Text textDisplay;
    public Text WorkTextDisplay;
    public Text PromotionTextDisplay;

    public void showWorkPopup()
    {
        WorkTextDisplay.text = "Work to earn $" + _inst.Wage + " but lose 50 Energy?" +"\n" + "You will also increase your chance of promoting by 10%";
        workPopup.SetActive(true);
        workButton.interactable = false;
        promotionButton.interactable = false;
        exitButton.interactable = false;
    }

    public void hideWorkPopup()
    {
        workPopup.SetActive(false);
        workButton.interactable = true;
        promotionButton.interactable = true;
        exitButton.interactable = true;
    }
    public void GoToWork()
    {
        if(PlayerData.Instance.Energy < 50)
        {
            workPopup.SetActive(false);
            workButton.interactable = true;
            promotionButton.interactable = true;
            exitButton.interactable = true;
            textDisplay.text = "You do not have enough energy to go to work!";
        }
        if(PlayerData.Instance.Energy >= 50)
        {
            StartCoroutine(Working());
            workPopup.SetActive(false);
            workButton.interactable = true;
            promotionButton.interactable = true;
            exitButton.interactable = true;
        }
    }

    private IEnumerator Working()
    {
        SceneManager.LoadSceneAsync("Workplace", LoadSceneMode.Additive);
        Debug.Log("Playing Animation");

        yield return new WaitForSecondsRealtime (5);
        SceneManager.UnloadSceneAsync("Workplace");
        Work();
    }

    public void Work()
    {
        PlayerData.Instance.Money += _inst.Wage;
        Debug.Log("You earned $100 from working today!");
        textDisplay.text = "You earned $" + _inst.Wage + " from working today!" + "\n" + "You lost 50 energy from working!" + "\n" + "You have increased your chances of promoting by 10%";
        PlayerData.Instance.Energy -= 50;
        Debug.Log("You lost 50 energy from working.");
        //textDisplay.text = " You lost 50 energy from working!";
        currentChanceToPromote += 0.1f;
    }

    public void showPromotionPopup()
    {
        if (currentChanceToPromote < minimumChanceToPromote)
        {
            Debug.Log("Sorry, You do not meet the requirements!");
            textDisplay.text = "Sorry, You do not meet the requirements!" + "\n" + "You have to work to increase your chances to promote!";
        }
        else
        {
            PromotionTextDisplay.text = "Current Chance to Promote:" + currentChanceToPromote * 100 + "%" + "\n" + "Do you want to try and promote to earn more money from working?";
            promotionPopup.SetActive(true);
            workButton.interactable = false;
            promotionButton.interactable = false;
            exitButton.interactable = false;
        }

    }
    public void hidePromotionPopup()
    {
        promotionPopup.SetActive(false);
        workButton.interactable = true;
        promotionButton.interactable = true;
        exitButton.interactable = true;
    }
    public void GoToPromote()
    {
        StartCoroutine(Promoting());
        promotionPopup.SetActive(false);
        workButton.interactable = true;
        promotionButton.interactable = true;
        exitButton.interactable = true;
    }
    private IEnumerator Promoting()
    {
        SceneManager.LoadSceneAsync("PromotionScene", LoadSceneMode.Additive);
        Debug.Log("Playing Animation");

        yield return new WaitForSecondsRealtime(5);
        SceneManager.UnloadSceneAsync("PromotionScene");
        Promotion();
    }
 
    public void Promotion()
    {
        if(PlayerData.Instance.Intelligence == 0f)
        {
            float randomNumber = Random.Range(0.1f, 1f);
            Debug.Log(randomNumber);
            if(currentChanceToPromote >= 1f)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                textDisplay.text = "Congratulations, You have been promoted and now have higher pay from working!" + "\n" + "Your chances to promote have reset to 0%";
                _inst.Wage += 50;
                currentChanceToPromote = 0.0f;
            }
            if(randomNumber < currentChanceToPromote)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                textDisplay.text = "Congratulations, You have been promoted and now have higher pay from working!" + "\n" + "Your chances to promote have reset to 0%";
                _inst.Wage += 50;
                currentChanceToPromote = 0.0f;
            }
            else if (randomNumber > currentChanceToPromote)
            {
                Debug.Log("Sorry, You have failed to promote!");
                currentChanceToPromote -= 0.05f;
                textDisplay.text = "Sorry, You have failed to promote!" + "\n" + "You have also lost 5% chance to promote.";
            }
        }
        else if(PlayerData.Instance.Intelligence > 0f)
        {
            currentChanceToPromote += PlayerData.Instance.Intelligence / 100;
            float randomNumber = Random.Range(0.1f, 1f);
            Debug.Log(randomNumber);
            if (currentChanceToPromote >= 1f)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                textDisplay.text = "Congratulations, You have been promoted and now have higher pay from working!" + "\n" + "Your chances to promote have reset to 0%";
                _inst.Wage += 50;
                currentChanceToPromote = 0.0f;
            }
            if (randomNumber < currentChanceToPromote)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                textDisplay.text = "Congratulations, You have been promoted and now have higher pay from working!" + "\n" + "Your chances to promote have reset to 0%";
                _inst.Wage += 50;
                currentChanceToPromote = 0.0f;
            }
            else if (randomNumber > currentChanceToPromote)
            {
                Debug.Log("Sorry, You have failed to promote!");
                currentChanceToPromote -= 0.05f;
                textDisplay.text = "Sorry, You have failed to promote!" + "\n" + "You have also lost 5% chance to promote.";
            }
        }
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
        Money.text = "Money: $" + _inst.Money + "/$" + _inst.Goal;
    }
    private void Update()
    {
        UpdateValues();
    }
    public void ExitWorkplace()
    {
        _inst.NText = _inst.Name + " left WacDonald.";
        SceneManager.UnloadSceneAsync("WorkplaceAction");
    }
}
