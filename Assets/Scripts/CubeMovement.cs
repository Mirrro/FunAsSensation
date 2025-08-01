using DG.Tweening;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private Ease ease;
    private Vector3 endValue;

    private float scaleFactor;
    // Update is called once per frame

    private void Start()
    {
        Jump();
        scaleFactor = Random.Range(.5f, 1.5f);
        transform.localScale = Vector3.one * scaleFactor; 
    }

    private void Jump()
    {
        float random = Random.Range(0.5f, 1);
        endValue = transform.position + Vector3.forward * random * 2;
        transform.DOJump(endValue, random * 1 / scaleFactor, 1, random * 1).OnComplete(Jump).SetEase(ease);
        transform.DORotate(new Vector3(90,0,0), random * 1, RotateMode.LocalAxisAdd);
    }
}
