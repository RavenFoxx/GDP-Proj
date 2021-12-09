using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour
{
    StoreData _store;
    PlayerData _inst;
    int day;
    int minchance = 0;
    bool EventStarted;
    public Text OtherInfoText;
    public Text NameText;
    public Slider Energy;
    public Slider Hunger;
    public Slider Happiness;
    public Slider ProgressBar;
    public GameObject Dim;
    public GameObject IntroPopup;
    public GameObject WinPopup;
    public GameObject LosePopup;
    private void Awake() {
        if (_store == null) _store = StoreData.Instance;
        if (_inst == null) _inst = PlayerData.Instance;
        Dim.SetActive(true);
        IntroPopup.SetActive(true);
        ProgressBar.maxValue = _inst.Goal;
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        UpdateValues();
    }
    private void Update() {
        UpdateValues();
        if(day != _inst.Day) { //if proceeded into next day
            day = _inst.Day;
            _store.restockItems();
            _store.printAmountLeft();
            if(day % 7 == 0) EventStarted = false;
            if(EventStarted == false) ChooseEvent();
        }
        CheckGameState();
    }
    public void EnterHome() { SceneManager.LoadSceneAsync("HomeAction", LoadSceneMode.Additive); }
    public void EnterWorkplace() { SceneManager.LoadSceneAsync("WorkplaceAction", LoadSceneMode.Additive); }
    public void EnterBank() { SceneManager.LoadSceneAsync("BankAction", LoadSceneMode.Additive); }
    public void EnterStore() { SceneManager.LoadSceneAsync("StoreAction", LoadSceneMode.Additive); }
    public void UpdateValues() {
        NameText.text = _inst.Name;
        Energy.value = (float)_inst.Energy / 100;
        Hunger.value = (float)_inst.Hunger / 100;
        Happiness.value = (float)_inst.Happiness / 100;
        ProgressBar.value = _inst.Money;
        OtherInfoText.text = "Day " + _inst.Day + " | Money: $" + _inst.Money;
    }
    public void ChooseEvent() {
        int chance = Random.Range(1 + minchance, 8);
        if(chance != 7) minchance++;
        else if(chance == 7) {
            EventStarted = true;
            minchance = 0;
            switch((int)Random.Range(1, 6))
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
    void CheckGameState() {
        if ((_inst.Day >= 31 && _inst.Money < _inst.Goal) || (_inst.Hunger <= 0)) {
            Dim.SetActive(true);
            LosePopup.SetActive(true);
        }
        else if (_inst.Money > _inst.Goal) {
            Dim.SetActive(true);
            WinPopup.SetActive(true);
        }
    }
}
