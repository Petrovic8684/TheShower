using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public Material Mat;
 
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Mat);
    }
}