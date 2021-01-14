using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject MessagePanel;

    public GameObject Mektup;

    public Text MessagePanelText;
    public Text LetterText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }

    public void OpenLetter(string text)
    {
        Mektup.SetActive(true);
    }

    public void CloseLetter()
    {
        Mektup.SetActive(false);
    }

    public void MessagePanelTextChanger(string text)
    {
        MessagePanelText.text = text;
    }

    public void LetterTextChanger(string text)
    {
        LetterText.text = text;
    }

}
