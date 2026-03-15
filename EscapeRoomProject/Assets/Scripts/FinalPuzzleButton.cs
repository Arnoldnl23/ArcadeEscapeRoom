using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FinalPuzzleButton : MonoBehaviour
{
    public Transform visualTarget;
    private Transform pokeAttach;
    private Vector3 initialPos;
    private Vector3 offset;
    private Vector3 localAxis = new Vector3(0, -1, 0);

    private XRBaseInteractable interactable;
    private bool isFollowing = false;
    private bool freeze;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPos = visualTarget.localPosition;

        interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(Follow);
            interactable.selectEntered.AddListener(OnSelectEntered);
            interactable.hoverExited.AddListener(Reset);
        }
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;
            pokeAttach = interactor.attachTransform;
            offset = visualTarget.position - pokeAttach.position;
            freeze = false;
        }
    }

    public void Reset(BaseInteractionEventArgs select)
    {
        Debug.Log("Hover exited");
        if (select.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    void OnSelectEntered(BaseInteractionEventArgs args)
    {
        freeze = true;
        Debug.Log("Button Pressed!");
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze)
            return;

        if (isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttach.position + offset);
            Vector3 constrainedTargetPosition = Vector3.Project(localTargetPosition, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedTargetPosition);
        }
        else
        {
            visualTarget.localPosition = initialPos;
        }
    }
}
