using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Soap : MonoBehaviour
{
    public static bool needsSoap = false;
    [SerializeField] private Text needsSoapText;
    [SerializeField] private AudioSource soapSound;

    public static event Action<string> OnDisplayInstruction;

    private void Start(){
        MenuManager.OnWin += ResetAll;
        MenuManager.OnLose += ResetAll;
    }

    private void Update(){
        if(MenuManager.isGameRunning){
            if(needsSoap){
                needsSoapText.text = "apply soap.";
            }else{
                needsSoapText.text = "";
            }
        }
    }

    public IEnumerator RequestSoap(){
        while(true){
            if(MenuManager.isGameRunning && !needsSoap && Curtain.isOver && Faucet.isOn){
                yield return new WaitForSeconds(UnityEngine.Random.Range(6f, 10f));
                if(MenuManager.isGameRunning && !needsSoap && Curtain.isOver && Faucet.isOn){
                    needsSoap = true;
                }
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnMouseEnter() {
        if(needsSoap){
            OnDisplayInstruction?.Invoke("[apply soap]");
        }
    }

    private void OnMouseExit() {
        if(needsSoap){
            OnDisplayInstruction?.Invoke("");
        }
    }

    private void OnMouseDown() {
        if(!needsSoap){
            return;
        }

       needsSoap = false;
       Sound.Play(soapSound);
       OnDisplayInstruction?.Invoke("");
    }

    private void ResetAll(){
        needsSoap = false;
    }
}
