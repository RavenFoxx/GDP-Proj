using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    PlayerData _inst = PlayerData.Instance;
    public InputField PlayerName;
    public Text DoesNothingButtonText;
    public void BackToMenu() {
        Destroy(GameObject.Find("PlayerData"));
        Destroy(GameObject.Find("StoreData"));
        SceneManager.LoadScene("Main");
    }
    public void StartGame() {
        _inst.Name = PlayerName.text;
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void DoesNothingButtonFunction() {
        switch (Random.Range(1, 10))
        {
            case 1:
                DoesNothingButtonText.text = "I told you so.";
                break;
            case 2:
                DoesNothingButtonText.text = "Stop clicking me.";
                break;
            case 3:
                DoesNothingButtonText.text = "StAhP!";
                break;
            case 4:
                DoesNothingButtonText.text = "YaMErOooOOoOoOO!11!1!";
                break;
            case 5:
                DoesNothingButtonText.text = "No. Bad.";
                break;
            case 6:
                DoesNothingButtonText.text = "it's about time you stop.";
                break;
            case 7:
                DoesNothingButtonText.text = "Bruh.";
                break;
            case 8:
                DoesNothingButtonText.text = ">.>";
                break;
            case 9:
                DoesNothingButtonText.text = "*Flips table*";
                break;
            default:
                DoesNothingButtonText.text = "This button does nothing.";
                break;
        }
    }
}
