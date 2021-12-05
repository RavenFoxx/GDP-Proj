using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour
{
    PlayerData _inst;
    int day;
    bool EventStarted;
    public Text OtherInfoText;
    public Text NameText;
    public Slider Energy;
    public Slider Hunger;
    public Slider Happiness;
    public Slider ProgressBar;
    private void Awake() {
        if(_inst == null) _inst = PlayerData.Instance;
        ProgressBar.maxValue = _inst.Goal;
        NameText.text = _inst.Name;
        UpdateValues();
    }
    private void Update() {
        UpdateValues();
        if(day != _inst.Day) { //if proceeded into next day
            day = _inst.Day;
            if(day % 7 == 0) EventStarted = false;
            if(EventStarted == false) ChooseEvent();
        }
    }
    public void EnterHome() { SceneManager.LoadSceneAsync("HomeAction", LoadSceneMode.Additive); }
    public void EnterWorkplace() { SceneManager.LoadSceneAsync("WorkplaceAction", LoadSceneMode.Additive); }
    public void EnterBank() { SceneManager.LoadSceneAsync("BankAction", LoadSceneMode.Additive); }
    public void EnterStore() { SceneManager.LoadSceneAsync("StoreAction", LoadSceneMode.Additive); }
    public void UpdateValues() {
        Energy.value = (float)_inst.Energy / 100;
        Hunger.value = (float)_inst.Hunger / 100;
        Happiness.value = (float)_inst.Happiness / 100;
        ProgressBar.value = _inst.Money;
        OtherInfoText.text = "Day " + _inst.Day + "\nMoney: $" + _inst.Money;
    }
    public void ChooseEvent() {
        int minchance = 0;
        int chance = Random.Range(1 + minchance, 8);
        if(chance != 7) minchance++;
        else if(chance == 7) {
            EventStarted = true;
            minchance = 0;
            switch((int)Random.RandomRange(1, 6))
            {
                case 1:
                    SceneManager.LoadSceneAsync("SuddenEvents 1", LoadSceneMode.Additive);
                    EventStarted = true;
                    break;
                case 2:
                    SceneManager.LoadSceneAsync("SuddenEvents 2", LoadSceneMode.Additive);
                    EventStarted = true;
                    break;
                case 3:
                    SceneManager.LoadSceneAsync("SuddenEvents 3", LoadSceneMode.Additive);
                    EventStarted = true;
                    break;
                case 4:
                    SceneManager.LoadSceneAsync("SuddenEvents 4", LoadSceneMode.Additive);
                    EventStarted = true;
                    break;
                case 5:
                    SceneManager.LoadSceneAsync("SuddenEvents 5", LoadSceneMode.Additive);
                    EventStarted = true;
                    break;
                default:
                    Debug.Log("Scenario chose out of bounds");
                    break;
            }
        }
    }
}
