using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    [SerializeField] private float lookSpeed = 3f;

    private float normalFOV = 60f;
    [SerializeField] private float zoomFOV;

    private void Start(){
        MenuManager.OnWin += ResetAll;
        MenuManager.OnLose += ResetAll;
    }

	private void Update () {
		Look();
        Zoom();
	}

    private void Look(){
        rotationY += lookSpeed * Input.GetAxis("Mouse X");
        rotationX -= lookSpeed * Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
    }

    private void Zoom(){
        if(Input.GetMouseButton(1)){
            gameObject.GetComponent<Camera>().fieldOfView = zoomFOV;
        }else{
            gameObject.GetComponent<Camera>().fieldOfView = normalFOV;
        }
    }

    private void ResetAll(){
        rotationX = 0.0f;
        rotationY = 0.0f;
    }
}
