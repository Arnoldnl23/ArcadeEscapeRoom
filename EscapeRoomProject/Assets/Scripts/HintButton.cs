using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class HintButton : MonoBehaviour
{
    [Header("Movement Settings")]
    public float pressDepth = 0.1f;
    public float pressSpeed = 10f;

    [Header("Events")]
    public UnityEvent onPressed;

    private Vector3 startPosition;
    private bool isPressing = false;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Start()
    {
        startPosition = transform.localPosition;
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        if (!isPressing)
        {
            StartCoroutine(PressAnimation());
        }
    }

    IEnumerator PressAnimation()
    {
        isPressing = true;

        Vector3 downPos = startPosition + Vector3.down * pressDepth;

        // Move down
        while (Vector3.Distance(transform.localPosition, downPos) > 0.001f)
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                downPos,
                Time.deltaTime * pressSpeed
            );
            yield return null;
        }

        onPressed?.Invoke();

        yield return new WaitForSeconds(0.1f);

        // Move back up
        while (Vector3.Distance(transform.localPosition, startPosition) > 0.001f)
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                startPosition,
                Time.deltaTime * pressSpeed
            );
            yield return null;
        }

        transform.localPosition = startPosition;
        isPressing = false;
    }
}