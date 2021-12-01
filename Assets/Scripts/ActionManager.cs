using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour
{
    PlayerData _inst;
    public Text OtherInfoText;
    public Text NameText;
    public Slider Energy;
    public Slider Hunger;
    public Slider Happiness;
    public Slider ProgressBar;
    private void Awake() {
        if (_inst == null) _inst = PlayerData.Instance;
        ProgressBar.maxValue = _inst.Goal;
        NameText.text = _inst.Name;
        UpdateValues();
    }
    private void Update()
    {
        UpdateValues();
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
}
