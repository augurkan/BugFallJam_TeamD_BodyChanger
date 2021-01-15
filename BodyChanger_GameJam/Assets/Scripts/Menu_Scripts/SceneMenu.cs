using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneMenu : MonoBehaviour
{
    [Header("CHANGE CURSOR ARROW")]
    public Texture2D cursorArrow;

    [Header("CANVAS")]
    public GameObject gameSceneCanvas;   //oyun ekranındaki sabit UI'ları göstermek için (ayarlar ikonu, mini map, görevler vs.)
    public GameObject selectionCanvas;   //oyun içi ana menü
    public GameObject skillCanvas;   //yetenekler paneli
    public GameObject inventoryCanvas;   //tılsım, mektup gibi objeler
    public GameObject mapCanvas;         //haritada açtığımız, açmadığımız yerlerin genel görüntüsü
    public bool selectionCanvasIsOpen = false;
    public bool subCanvasIsOpen = false;


    void Start()
    {


        gameSceneCanvas.SetActive(true);
        selectionCanvas.SetActive(false);
        skillCanvas.SetActive(false);
        inventoryCanvas.SetActive(false);
        mapCanvas.SetActive(false);

    }
    
    void Update()
    {
        OpenSceneMenu();

    }

    public void OpenSceneMenu()
    {
        if (Input.GetKeyDown(KeyCode.I))   //klik de eklemeli mi?
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            gameSceneCanvas.SetActive(false);

            selectionCanvas.SetActive(true);
            selectionCanvasIsOpen = true;
        }
        //iki seçeneğimiz var; alt canvas'lara gitmek ya da sahne menüsünü kapatmak

        if(selectionCanvasIsOpen == true)
        {
            Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        CloseSceneMenu();
    }

    public void CloseSceneMenu()
    {
        if (subCanvasIsOpen == false && selectionCanvas == true && Input.GetKeyDown(KeyCode.Escape))   //klik de eklemeli mi?
        {
            gameSceneCanvas.SetActive(true);

            selectionCanvas.SetActive(false);
            selectionCanvasIsOpen = false;
        }

        else if(subCanvasIsOpen == true && selectionCanvas == true && Input.GetKeyDown(KeyCode.Escape))
        {
            skillCanvas.SetActive(false);
            inventoryCanvas.SetActive(false);
            mapCanvas.SetActive(false);

            subCanvasIsOpen = false;
        }
    }

   
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void SkillsButton()
    {        
        skillCanvas.SetActive(true);
        subCanvasIsOpen = true;
    }

    public void InventoryButton()
    {
        inventoryCanvas.SetActive(true);
        subCanvasIsOpen = true;
    }

    public void MapButton()
    {
        mapCanvas.SetActive(true);
        subCanvasIsOpen = true;

    }

    public void BackToTheGameButton()
    {
        selectionCanvas.SetActive(false);
        selectionCanvasIsOpen = false;

        gameSceneCanvas.SetActive(true);
    }

    public void BackToSelectionMenu()
    {
        skillCanvas.SetActive(false);
        inventoryCanvas.SetActive(false);
        mapCanvas.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
