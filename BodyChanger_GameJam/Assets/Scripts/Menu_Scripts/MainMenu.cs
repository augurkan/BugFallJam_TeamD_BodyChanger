using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// 
    ///  -------- DATA KEYWORD'LERİ ---------
    ///  
    ///     "lastSave"  =  Son kaydımız 
    ///     
    /// 
    /// </summary>

    [Header("CHANGE CURSOR ARROW")]
    public Texture2D cursorArrow;

    [Header("CANVAS")]
    public GameObject canvas_UI;
    public GameObject canvas_story;
    public GameObject canvas_Settings;

    [Header("STORY OBJECTS")]
    public GameObject storyScreenBook;
    public GameObject storyScreen1;
    public GameObject storyScreen2;
    public GameObject storyScreen3;

    [Header("SECENE MANAGEMENT")]
    public bool freshStart = true;   //oyuna ilk kez başlamak
    public bool storyRed = false;   //hikayeyi izlemiş olmak
    
    int activeScene;  //(play, nereden devam ettirecek)
    

    void Start()
    {
        //istediğimiz objeyi mouse ikonu olarak atayabiliriz bu tek satırla (ve Texture2D ekleyerek tabi). Etkileşimler için özel ikonlar kullanabiliriz
        Cursor.SetCursor(cursorArrow,Vector2.zero,CursorMode.ForceSoftware);

        activeScene = PlayerPrefs.GetInt("lastSave", SceneManager.GetActiveScene().buildIndex);

        canvas_UI.SetActive(true);
        canvas_Settings.SetActive(false);

        storyScreenBook.SetActive(false);
        storyScreen1.SetActive(false);
        storyScreen2.SetActive(false);
        storyScreen3.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //STORY
    public void StorySheetChangeButtons(int buttonNo)   //sayfa numarası ile buton numarası aynı olsun
    {
        if(buttonNo == 1)
        {
            storyScreenBook.SetActive(false);
            storyScreen1.SetActive(true);
        }
        else if (buttonNo == 2)
        {
            storyScreen1.SetActive(false);
            storyScreen2.SetActive(true);
        }
        else if (buttonNo == 3)
        {
            storyScreen2.SetActive(false);
            storyScreen3.SetActive(true);
        }
        else if (buttonNo == 4)
        {
            storyScreen3.SetActive(false);
            canvas_UI.SetActive(true);
                       
            storyRed = true;
            freshStart = false;

            SceneManager.LoadScene(1);   // ilk level'a başlar
        }
    }


    //MAIN MENU BUTTONS
    public void PlayGameButton()
    {
        if(freshStart == true && !storyRed)   //henüz oyuna başlamamış ve story'i izlememişsek ilk slayt açılsın. next ile story'de ilerlemek "StorySheetChangeButtons" da yapılacak
        {
            storyScreenBook.SetActive(true);

            canvas_UI.SetActive(false);
        }
        else 
        {
            SceneManager.LoadScene(activeScene);  //hafızadaki sahneye yönlendirir
        }
    }


    public void OpenSettingsPanelButton() 
    {
        canvas_Settings.SetActive(true);
    }
    public void CloseSettingsPanelButton()  
    {
        canvas_Settings.SetActive(false);
    }

    public void ResetGameButton()   
    {
        // tüm kayıtları sildireceğiz, firstRed vs sıfırlanacak. unutma.
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
