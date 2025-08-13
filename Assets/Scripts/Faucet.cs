using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Faucet : MonoBehaviour
{
    public static bool isOn = false;
    private Animator animator;

    public static event Action<string> OnDisplayInstruction;
    public static event Action OnToggleFaucet;

    private void Awake(){
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start(){
        MenuManager.OnWin += ResetAll;
        MenuManager.OnLose += ResetAll;
    }

    private void OnMouseEnter() {
        OnDisplayInstruction?.Invoke("[use faucet]");
    }

    private void OnMouseExit() {
        OnDisplayInstruction?.Invoke("");
    }

    private void OnMouseDown() {
       animator.SetBool("Toggle", !animator.GetBool("Toggle"));
       isOn = !isOn;
       OnToggleFaucet?.Invoke();
       OnDisplayInstruction?.Invoke("");
    }

    private void OnMouseUp(){
        OnMouseEnter();
    }

    private void ResetAll(){
        if(isOn){
            isOn = false;
            animator.Rebind();
            animator.Update(0f);
        }
    }
}
