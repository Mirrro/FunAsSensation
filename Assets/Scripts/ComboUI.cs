using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComboUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textfield;
    [SerializeField] private Material material;

    private Color[] colors = new[] {Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow};
    
    public void SetText(string text)
    {
        textfield.text = text;
    }

    private void OnEnable()
    {
        RandomColor();
    }

    public void RandomColor()
    {
        Debug.Log("RandomColor");
        textfield.outlineColor = colors[Random.Range(0, colors.Length)];
    }
}
