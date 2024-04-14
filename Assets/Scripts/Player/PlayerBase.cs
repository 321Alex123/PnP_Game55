using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using TMPro;

public class PlayerBase : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI CoinsText;
    private float BaseHealth { get; set; } = 100;

    public int Coins { get; set; } = 0;

    //Пассвиный зарботок
    // private void Start()
    // {
    //     InvokeRepeating(nameof(PassiveIncome), 1, 1 );
    // }
    //
    // public void PassiveIncome()
    // {
    //     Coins += 1;
    // }

    public void AddCoins(int coinsToAdd)
    {
        Coins += coinsToAdd;
        CoinsText.text += $"Валюты: {Coins}";
    }
    
    public void ReceiveDamage(float damage)
    {
        BaseHealth -= damage;
        HealthText.text += $"Прочности: {Coins}";
    }
}
