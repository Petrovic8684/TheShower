using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternate : MonoBehaviour
{
    public static bool isInside = false;
    public static bool shouldEnter = true;
    [SerializeField] private Vector3 insidePosition;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource voice;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private Curtain curtain;
    [SerializeField] private Transform alternateHead;
    [SerializeField] private GameObject gameUI;

    private void Start(){
        MenuManager.OnWin += ResetAll;
        MenuManager.OnLose += ResetAll;
    }

    private void Update(){
        if(isInside){
            gameCamera.transform.LookAt(alternateHead, Vector3.up);
            gameCamera.GetComponent<Camera>().fieldOfView = 45f;
        }
    }

    public IEnumerator Enter(){
        curtain.staticSound.volume = 0f;
        curtain.Open();
        gameUI.SetActive(false);
        Sound.Stop(music);
        isInside = true;
        transform.position = new Vector3(insidePosition.x, insidePosition.y, insidePosition.z);
        Sound.Play(voice);
        yield return new WaitForSeconds(3f);
        MenuManager.OnLose?.Invoke();
        curtain.DisableRedness();
        yield return new WaitForEndOfFrame();
    }

    private void ResetAll(){
        transform.position = new Vector3(0f, 0.56f, 2.75f);
        Sound.Play(music);
        isInside = false;
        shouldEnter = true;
        gameCamera.GetComponent<Camera>().fieldOfView = 60f;
    }
}
