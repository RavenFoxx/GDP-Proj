using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BankAction : MonoBehaviour
{
    public Text monehText;
    public Text textboxText;
    public Text depositPopoutText;
    public Text withdrawPopoutText;
    public InputField depositAmount;
    public InputField withdrawAmount;
    public GameObject depositPopoutMsg;
    public GameObject withdrawPopoutMsg;
    PlayerData _inst = PlayerData.Instance;
    private void Awake() {
        monehText.text = "Account balance: $" + _inst.BankedMoney.ToString();
        textboxText.text = "You entered BankCent. What will you do?";
    }
    public void DepositAmt() {
        float amt = 0;
        try {
            amt = float.Parse(depositAmount.text);
            if (amt < 0) {
                Debug.Log("User entered a negative value.");
                depositPopoutText.text = "You cannot deposit less than $0.";
                return;
            }
        }
        catch(Exception e) {
            Debug.Log("User entered a non integer/float value into " + depositAmount + "\n" + e);
            return;
        }
        if (_inst.Money >= amt) {
            _inst.Money -= amt;
            _inst.BankedMoney += amt;
            depositPopoutMsg.SetActive(false);
            clearDataField();
            monehText.text = "$" + _inst.BankedMoney.ToString();
            textboxText.text = "You have deposited $" + amt.ToString() + ".";
        }
        else depositPopoutText.text = "You don't have enough money on hand.\nYou have $" + _inst.Money + " on hand.\nHow much do you want to deposit?";
    }
    public void WithdrawAmt() {
        float amt = 0;
        try {
            amt = float.Parse(withdrawAmount.text);
            if (amt < 0) {
                Debug.Log("User entered a negative value.");
                withdrawPopoutText.text = "You cannot withdraw less than $0.";
                return;
            }
        }
        catch (Exception e) {
            Debug.Log("User entered a non integer/float value into " + withdrawAmount + "\n" + e);
            return;
        }
        if (_inst.BankedMoney >= amt) {
            _inst.BankedMoney -= amt;
            _inst.Money += amt;
            withdrawPopoutMsg.SetActive(false);
            clearDataField();
            monehText.text = "$" + _inst.BankedMoney.ToString();
            textboxText.text = "You have withdrawn $" + amt.ToString() + ".";
        }
        else withdrawPopoutText.text = "You don't have enough money in the bank.\nYou have $" + _inst.BankedMoney + " in the bank.\nHow much do you want to withdraw?";
    }
    public void Deposit() {
        depositPopoutMsg.SetActive(true);
        depositPopoutText.text = "you have $" + _inst.Money + " on hand.\nHow much do you want to deposit?";
    }
    public void Withdraw() {
        withdrawPopoutMsg.SetActive(true);
        withdrawPopoutText.text = "you have $" + _inst.BankedMoney + " in the bank.\nHow much do you want to withdraw?";
    }
    public void clearDataField() {
        depositAmount.text = "";
        withdrawAmount.text = "";
        textboxText.text = "You hesitated.";
    }
    public void Cancelbtn() {
        depositPopoutMsg.SetActive(false);
        withdrawPopoutMsg.SetActive(false);
        clearDataField();
    }
    public void ExitBank()
    {
        _inst.NText = _inst.Name + " left BankCent.";
        SceneManager.UnloadSceneAsync("BankAction");
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
    private void Update()
    {
        UpdateValues();
    }
}
