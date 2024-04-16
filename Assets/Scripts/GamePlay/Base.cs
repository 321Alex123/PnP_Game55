using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] WinAndLoss winAndLoss;
    [SerializeField] TextMeshProUGUI healthText;

    private void Start()
    {
        DisplayDamage(GetComponent<Health>().health);
    }

    public void BaseDestroyed()
    {
        winAndLoss.WinOrLoss(false);
    }

    public void DisplayDamage(int health)
    {
        healthText.text = health.ToString();
    }
}
