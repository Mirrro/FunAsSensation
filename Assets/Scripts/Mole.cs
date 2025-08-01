using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Mole : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private Animator animator;
    public UnityEvent<Mole> OnHit = new UnityEvent<Mole>();
    public UnityEvent<Mole> OnHide = new UnityEvent<Mole>();
    public UnityEvent<Mole> OnAppear = new UnityEvent<Mole>();
    private static readonly int IsHit = Animator.StringToHash("IsHit");
    private static readonly int IsSpawn = Animator.StringToHash("IsSpawn");
    private static readonly int IsHiding = Animator.StringToHash("IsHiding");

    private Coroutine hidingCoroutine;

    private void Start()
    {
        StartCoroutine(ShowUpDelay());
    }

    private void OnMouseDown()
    {
        StopAllCoroutines();
        collider.enabled = false;
        animator.SetTrigger(IsHit);
        OnHit?.Invoke(this);
        StartCoroutine(ShowUpDelay());
    }

    public void ShowUp()
    {
        StopAllCoroutines();
        collider.enabled = true;
        OnAppear?.Invoke(this);
        animator.ResetTrigger(IsHit);
        animator.ResetTrigger(IsHiding);
        animator.SetTrigger(IsSpawn);
        StartCoroutine(nameof(HidingDelay));
    }

    private IEnumerator ShowUpDelay()
    {
        yield return new WaitForSeconds(Random.Range(2f,4f));
        ShowUp();
    }

    private IEnumerator HidingDelay()
    {
        yield return new WaitForSeconds(Random.Range(2f,4f));
        collider.enabled = false;
        animator.SetTrigger(IsHiding);
        OnHide?.Invoke(this);
        StartCoroutine(ShowUpDelay());
    }
}
