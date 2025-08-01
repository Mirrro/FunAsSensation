using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Toggle soundManagerToggle;
    [SerializeField] private Toggle lookAtMouseToggle;
    [SerializeField] private Toggle screenShakeToggle;
    [SerializeField] private Toggle effectManagerToggle;
    [SerializeField] private Toggle comboManagerToggle;
    [SerializeField] private Toggle postProcessingToggle;
    [SerializeField] private Toggle counterEffectToggle;
    [SerializeField] private Toggle hitColorToggle;
    
    [SerializeField] private List<Mole> moles;
    [SerializeField] private AudioSource music;
    [SerializeField] private ScreenShake screenShake;
    [SerializeField] private MoleEffectManager effectManager;
    [SerializeField] private ComboManager comboManager;
    [SerializeField] private Volume postProcessingVolume;
    [SerializeField] private CounterEffect counterEffect;

    private bool isInitialized;
    
    private void OnEnable()
    {
        if (!isInitialized)
        {
            SetComboManager(false);
            SetCounterEffect(false);
            SetEffectManager(false);
            SetPostProcessing(false);
            SetScreenShake(false);
            SetSoundsManager(false);
            SetLookAtMouse(false);
            SetHitColor(false);
            isInitialized = true;
        }
        
        soundManagerToggle.onValueChanged.AddListener(SetSoundsManager);
        lookAtMouseToggle.onValueChanged.AddListener(SetLookAtMouse);
        screenShakeToggle.onValueChanged.AddListener(SetScreenShake);
        effectManagerToggle.onValueChanged.AddListener(SetEffectManager);
        comboManagerToggle.onValueChanged.AddListener(SetComboManager);
        postProcessingToggle.onValueChanged.AddListener(SetPostProcessing);
        counterEffectToggle.onValueChanged.AddListener(SetCounterEffect);
        hitColorToggle.onValueChanged.AddListener(SetHitColor);
    }

    private void SetHitColor(bool isActive)
    {
        foreach (var mole in moles)
        {
            mole.GetComponentInChildren<MoleColorEffect>().enabled = isActive;
        }
    }

    private void SetSoundsManager(bool isActive)
    {
        music.enabled = isActive;
        foreach (var mole in moles)
        {
            mole.GetComponent<SoundManager>().enabled = isActive;
        }
    }

    private void SetLookAtMouse(bool isActive)
    {
        foreach (var mole in moles)
        {
            mole.GetComponent<LookAtMouse>().enabled = isActive;
        }
    }

    private void SetScreenShake(bool isActive)
    {
        screenShake.enabled = isActive;
    }
    
    private void SetEffectManager(bool isActive)
    {
        effectManager.enabled = isActive;
    }

    private void SetComboManager(bool isActive)
    {
        comboManager.enabled = isActive;
    }

    private void SetPostProcessing(bool isActive)
    {
        postProcessingVolume.enabled = isActive;
    }

    private void SetCounterEffect(bool isActive)
    {
        counterEffect.enabled = isActive;
    }
}
