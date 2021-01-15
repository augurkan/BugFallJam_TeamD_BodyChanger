using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingMenuItems : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;
    public Image itemImage;


    void Start()
    {
        itemImage.color = baseColor;
    }


    public void Select()
    {
        itemImage.color = hoverColor;
    }

    public void Deselect()
    {
        itemImage.color = baseColor;
    }
}
