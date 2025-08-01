using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject panel;

    private bool isShow;

    private void Start()
    {
        panel.SetActive(isShow);
    }

    private void OnEnable()
    {
        
        button.onClick.AddListener(TogglePanel);
    }

    private void TogglePanel()
    {
        isShow = !isShow;
        panel.SetActive(isShow);
    }
}
