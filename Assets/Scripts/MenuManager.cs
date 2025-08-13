using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static bool isGameRunning = false;

    [SerializeField] private GameObject game;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;

    [SerializeField] private GameObject playText;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private AudioSource squeakSound;
    private float duration = 2f;
    private Image fadeImage;
    [SerializeField] private Door door;
    [SerializeField] private Soap soap;

    public static Action OnWin;
    public static Action OnLose;

    private void Awake(){
        fadeImage = GameObject.Find("TransitionCanvas/TransitionPanel").GetComponent<Image>();
    }

    private void Start(){
        OnWin += ShowWin;
        OnLose += ShowLose;

        TogglePlayText(false);
        ShowMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ShowMenu(){
        FadeAnimation();
        game.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        settings.SetActive(false);
        instructions.SetActive(false);
        menu.SetActive(true);
    }

    public void ShowGame(){
        gameUI.SetActive(true);
        gameCamera.SetActive(true);
        isGameRunning = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        FadeAnimation();
        menu.SetActive(false);
        win.SetActive(false);
        instructions.SetActive(false);
        lose.SetActive(false);
        settings.SetActive(false);
        game.SetActive(true);
        StartCoroutine(door.Open());
        StartCoroutine(soap.RequestSoap());
    }

    public void ShowInstructions(){
        FadeAnimation();
        menu.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        game.SetActive(false);
        settings.SetActive(false);
        instructions.SetActive(true);
    }

    public void ShowSettings(){
        FadeAnimation();
        menu.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        instructions.SetActive(false);
        game.SetActive(false);
        settings.SetActive(true);
    }

    public void ShowWin(){
        FadeAnimation();
        menu.SetActive(false);
        lose.SetActive(false);
        instructions.SetActive(false);
        EndGame();
        Invoke("EndGameWithDelay", 0.1f);
        settings.SetActive(false);
        win.SetActive(true);
    }

    public void ShowLose(){
        FadeAnimation();
        menu.SetActive(false);
        instructions.SetActive(false);
        EndGame();
        Invoke("EndGameWithDelay", 0.1f);
        settings.SetActive(false);
        win.SetActive(false);
        lose.SetActive(true);
    }

    private void EndGame(){
        gameCamera.SetActive(false);
    }

    private void EndGameWithDelay(){
        game.SetActive(false);
    }

    public void Exit(){
        Application.Quit();
    }

    public void TogglePlayText(bool state){
        playText.SetActive(state);
    }

    public IEnumerator Fade(){
        Sound.PlayOneShot(squeakSound);
        float elapsedTime = 0f;

        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            fadeImage.color = new Color(0f, 0f, 0f, Mathf.Lerp(255f, 0f, elapsedTime / duration)/255f);
            yield return null;
        }
    }

    public void FadeAnimation(){
        StopAllCoroutines();
        StartCoroutine(Fade());
    }
}
