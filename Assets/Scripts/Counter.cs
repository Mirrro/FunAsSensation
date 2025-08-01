using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(TMP_Text))]
public class Counter : MonoBehaviour
{
    [SerializeField] private Button button;
    private TMP_Text textfield;
    private int count;
    public UnityEvent OnTen = new UnityEvent();
    public UnityEvent OnCount = new UnityEvent();
    private void Awake()
    {
        textfield = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        textfield.text = count.ToString();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        count++;
        
        if (count % 10 == 0)
        {
            OnTen?.Invoke();
        }
        else
        {
            OnCount?.Invoke();
        }
        textfield.text = count.ToString();
    }
}
