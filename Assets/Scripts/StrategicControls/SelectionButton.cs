using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionButton : MonoBehaviour
{
    [SerializeField] private Color32 selectionColor = new Color32(0, 255, 252, 255);
    [SerializeField] private Color32 defaultColor = new Color32(0, 0, 0, 255);

    public void SelectionIndication(bool selected)
    {
        if (selected)
        {
            gameObject.GetComponent<Image>().color = selectionColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
}
