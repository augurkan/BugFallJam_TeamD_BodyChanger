using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMenu : MonoBehaviour
{
    public Vector2 normalizedMousePosition;
    public float currentAngle;
    public int selection;

    public GameObject[] menuItems;
    private int previousSelection;

    //private RingMenuItems ringMenuItems_Sc;
    //private RingMenuItems previousRingMenuItems_Sc;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        normalizedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(normalizedMousePosition.x, normalizedMousePosition.y) * Mathf.Rad2Deg;

        currentAngle = (currentAngle + 360) % 360;

        selection = (int)currentAngle / 72;  //(360 / 5)

        //if(selection != previousSelection)
        //{
        //    previousRingMenuItems_Sc = menuItems[previousSelection].GetComponent<RingMenuItems>();
        //    previousRingMenuItems_Sc.Deselect();
        //    previousSelection = selection;

        //    ringMenuItems_Sc = menuItems[selection].GetComponent<RingMenuItems>();
        //    ringMenuItems_Sc.Select();
        //}


        Debug.Log(currentAngle);
    }
}
