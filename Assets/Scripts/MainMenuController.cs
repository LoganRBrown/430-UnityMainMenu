using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public RectTransform bttnsMain;
    public RectTransform bttnsLevels;
    

    public EventSystem events;

    public BasicButton bttnPrefab;
    public BasicButton backBttn;
    public BasicButton loadBttn;

    Levels levels;

    bool needsToAnimate = false;

    void Start()
    {
        levels = GetComponent<Levels>();
        backBttn.gameObject.SetActive(false);
        BuildSubMenu();
        bttnsLevels.gameObject.SetActive(false);

    }

    private void BuildSubMenu()
    {
        float y = 150;

        float x = -200;

        float i = 0;

        foreach (LevelInfo level in levels.levels)
        {
            BasicButton bttn = Instantiate(bttnPrefab, bttnsLevels);

            bttn.Init(level.nameOfLevel, level.imageForButton, () => {

                SceneManager.LoadScene(level.filenameOfScene);
            
            });

            bttn.textField.color = Color.white;

            RectTransform t = (bttn.transform as RectTransform);
            t.anchoredPosition = new Vector2(x, y);
            y -= 150;
            i++;
            if (i == 3)
            {
                x = 200;
                y = 150;
            }
        }
    }

    void Update()
    {
        Focus();

        
    }

    private void Focus()
    {
        if (events == null) return;
        if (events.currentSelectedGameObject != null) return;
        if (events.firstSelectedGameObject == null) return;

        if (events.currentSelectedGameObject == null) events.SetSelectedGameObject(events.firstSelectedGameObject);
    }

    public void AnimateMenu()
    {
        float x = 0;
        RectTransform t = (bttnsMain.transform as RectTransform);

        t.anchoredPosition = 

        for(int i = 0; i<=1210; i++){
            x = i;
            t.anchoredPosition = new Vector2(x, (float)-27.95);
        }

    }

    public void UnAnimateMenu()
    {
        float x = 0;
        RectTransform t = (bttnsMain.transform as RectTransform);

        for (int i = 1210; i >= 140; i--)
        {
            x = i;
            t.anchoredPosition = new Vector2(x, (float)-27.95);
        }

    }
    public void BttnLevelClicked()
    {

        AnimateMenu();
        loadBttn.gameObject.SetActive(false);
        backBttn.gameObject.SetActive(true);
        bttnsLevels.gameObject.SetActive(true);



    }

    public void BttnBackClicked()
    {
        UnAnimateMenu();

        backBttn.gameObject.SetActive(false);

        loadBttn.gameObject.SetActive(true);

        bttnsLevels.gameObject.SetActive(false);


    }

    public void BttnPlayClicked()
    {
        SceneManager.LoadScene("Scenes/Level01");
    }

    public void BttnExitClicked()
    {
        Application.Quit();
    }
}
