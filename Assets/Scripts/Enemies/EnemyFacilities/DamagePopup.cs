using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private float speed;
    private TextMeshPro _textMesh;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void Setup(string text)
    {
        _textMesh.SetText(text);
    }
}
