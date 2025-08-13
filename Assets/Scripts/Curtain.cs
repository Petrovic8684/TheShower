using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class Curtain : MonoBehaviour
{
    public static bool isOver = true;
    [SerializeField] private AudioSource sound;
    private Animator animator;

    public static event Action<string> OnDisplayInstruction;

    [SerializeField] private Alternate alternate;
    public AudioSource staticSound;
    [SerializeField] private Image redness;

    private void Awake(){
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start(){
        MenuManager.OnWin += ResetAll;
        MenuManager.OnLose += ResetAll;
    }

    private void OnMouseEnter() {
        OnDisplayInstruction?.Invoke("[move curtain]");
    }

    private void OnMouseExit() {
        OnDisplayInstruction?.Invoke("");
    }

    private void OnMouseDown() {
        if(Alternate.isInside){
            return;
        }

       animator.SetBool("Toggle", !animator.GetBool("Toggle"));
       if(isOver && !Alternate.isInside){
            staticSound.volume = 0f;
            DisableRedness();
            Progress.danger = 0f;
       }
       isOver = !isOver;
       Sound.Play(sound);
       OnDisplayInstruction?.Invoke("");
    }

    private void OnMouseUp(){
        OnMouseEnter();
    }

    public void Open(){
        animator.SetBool("Toggle", false);
        isOver = false;
    }

    public void DisableRedness(){
        redness.color = new Color(redness.color.r, redness.color.g, redness.color.b, 0f);
    }

    private void ResetAll(){
        if(!isOver){
            isOver = true;
            animator.Rebind();
            animator.Update(0f);
        }
    }
}
