using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using TMPro;
using UnityEngine.Serialization;

public class Recources : MonoBehaviour
{
    public int Scrap = 0;

    public TextMeshProUGUI ScrapText;
    public float passiveIncomeTime = 3;

    //Пассивный Заработок
    private void Start()
    {
        InvokeRepeating(nameof(AddScrapPassively), 1, passiveIncomeTime);
    }

    public void AddScrapPassively()
    {
        Scrap += 1;
        ScrapText.text = $" {Scrap}";
    }

    //Методы для работы покупок дронов
    public bool HasEnoughScrap(int amount)
    {
        return Scrap >= amount;
    }

    public void SpendScrap(int amount)
    {
        Scrap -= amount;
        ScrapText.text = $"Scrap: {Scrap}";
    }

    public void AddScrap(int amount)
    {
        Scrap += amount;
        ScrapText.text = $"Scrap: {Scrap}";
    }
}