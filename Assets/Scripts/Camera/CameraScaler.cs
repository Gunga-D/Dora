using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    [SerializeField] Vector2 referenceResolution;

    private void Awake()
    {
        float xFactor = Screen.width / referenceResolution.y;
        float yFactor = Screen.height / referenceResolution.x;

        GetComponent<Camera>().rect = new Rect(0, 0, 1, xFactor / yFactor);
    }
}
