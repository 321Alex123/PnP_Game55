using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] WinAndLoss winAndLoss;
    public void BaseDestroyed()
    {
        winAndLoss.WinOrLoss(false);
    }
}
