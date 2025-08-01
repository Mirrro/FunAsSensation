using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private Mole mole;
    [SerializeField] private Transform head;
    private bool isLooking;
    private Quaternion initialRot;

    // Start is called before the first frame update
    void Awake()
    {
        initialRot = head.rotation;
    }

    private void OnEnable()
    {
        mole.OnHit.AddListener(StopUpdating);
        mole.OnAppear.AddListener(StartUpdating);
        StartUpdating(null);
    }

    private void OnDisable()
    {
        mole.OnHit.RemoveListener(StopUpdating);
        mole.OnAppear.RemoveListener(StartUpdating);
        StopUpdating(null);
        head.rotation = initialRot;
    }

    private void StopUpdating(Mole _)
    {
        isLooking = false;
    }

    private void StartUpdating(Mole _)
    {
        isLooking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLooking)
        {
            return;
        }
        Vector3 temp = new Vector3(Camera.main.nearClipPlane + 15, Mathf.Lerp(-5, 35, Input.mousePosition.y / Screen.height),
            Mathf.Lerp(-37, 34, Input.mousePosition.x / Screen.width));
        head.LookAt(temp);
    }
}
