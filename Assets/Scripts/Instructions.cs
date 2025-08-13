using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [SerializeField] private Text instructionText;

    private void Start(){
        Curtain.OnDisplayInstruction += DisplayInstruction;
        Faucet.OnDisplayInstruction += DisplayInstruction;
        Soap.OnDisplayInstruction += DisplayInstruction;
    }

    private void DisplayInstruction(string text){
        instructionText.text = text;
    }
}
