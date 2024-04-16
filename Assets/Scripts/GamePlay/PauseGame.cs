using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;

    private void Awake()
    {
        FreezeTime(true);
    }

    public void FreezeTime(bool a)
    {
        if (a) 
        { 
            Time.timeScale = 0;
            pauseButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            pauseButton.SetActive(true);
        }
    }
}
