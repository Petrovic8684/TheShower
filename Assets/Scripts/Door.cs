using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool isOpen = false;
    [SerializeField] private AudioSource sound;
    [SerializeField] private Vector3 openPosition;

    private void Start(){
        MenuManager.OnWin += ResetAll;
        MenuManager.OnLose += ResetAll;
        StartCoroutine(Open());
    }

    public IEnumerator Open(){
        yield return new WaitForSeconds(Random.Range(10f, 12f));
        if(!isOpen) {
            Sound.Play(sound);
        }
        isOpen = true;
        transform.position = new Vector3(openPosition.x, openPosition.y, openPosition.z);
        transform.eulerAngles = new Vector3(0f, -90f, 0f);
        yield return new WaitForEndOfFrame();
    }

    private void ResetAll(){
        if(isOpen){
            isOpen = false;
            transform.position = new Vector3(-0.083f, 0.62f, 2f);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
