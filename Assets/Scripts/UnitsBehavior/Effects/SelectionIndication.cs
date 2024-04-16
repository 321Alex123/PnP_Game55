using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndication : MonoBehaviour
{
    [SerializeField] private GameObject selectionIndicator;
    public SelectionButton selectionButton;

    public void ChangeIndicator(bool selectrd)
    {
        if (selectrd)
        {
            selectionIndicator.SetActive(true);
            selectionButton.SelectionIndication(true);
        }
        else
        {
            selectionIndicator.SetActive(false);
            selectionButton.SelectionIndication(false);
        }
    }
}
