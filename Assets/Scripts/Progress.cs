using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public static float danger = 0f;
    [SerializeField] private float speed;
    [SerializeField] private Slider bar;
    [SerializeField] private AudioSource staticSound;

    [SerializeField] private Alternate alternate;
    [SerializeField] private Image redness;
    private Coroutine AlternateCoroutine;

    private void Start(){
        MenuManager.OnWin += ResetAll;
        MenuManager.OnLose += ResetAll;
    }

    private void LateUpdate(){
        if(MenuManager.isGameRunning){
            if(Curtain.isOver && Faucet.isOn){
                if(!Alternate.isInside){
                    danger += Time.deltaTime / speed;
                    if(!Soap.needsSoap){
                        bar.value += Time.deltaTime / speed;
                    }
                }

                staticSound.volume = danger/0.25f;
                redness.color = Color.Lerp(redness.color, new Color(redness.color.r, redness.color.g, redness.color.b, 0.314f), Time.deltaTime / speed * 4f);

                if(danger > 0.25f && Door.isOpen && Alternate.shouldEnter){
                    AlternateCoroutine = StartCoroutine(alternate.Enter());
                    Alternate.shouldEnter = false;
                }

                if(bar.value == 1f){
                    MenuManager.OnWin?.Invoke();
                    DisableRedness();
                    staticSound.volume = 0f;
                }
            }
        }
    }

    private void DisableRedness(){
        redness.color = new Color(redness.color.r, redness.color.g, redness.color.b, 0f);
    }

    public void ResetAll(){
        if(AlternateCoroutine != null){
            StopCoroutine(AlternateCoroutine);
        }
        danger = 0f;
        bar.value = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        MenuManager.isGameRunning = false;
    }
}
