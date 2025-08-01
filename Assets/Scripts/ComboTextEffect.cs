using DG.Tweening;
using UnityEngine;

public class ComboTextEffect : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOPunchScale(Vector3.one, 1f, vibrato: 2);
    }
}
