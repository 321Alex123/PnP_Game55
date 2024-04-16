using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAndLoss : MonoBehaviour
{
    [SerializeField] private PauseGame pauseGame;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lossPanel;
    public void WinOrLoss(bool won)
    {
        pauseGame.FreezeTime(true);
        if (won)
        {
            winPanel.SetActive(true);
        }
        else
        {
            lossPanel.SetActive(true);
        }
    }
}
