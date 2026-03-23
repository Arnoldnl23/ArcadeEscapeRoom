using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HintButton : MonoBehaviour
{
    public Transform visualTarget;
    private Transform pokeAttach;
    private Vector3 initialPos;
    private Vector3 offset;
    private Vector3 localAxis = new Vector3(0, -1, 0);

    public float angleThreshold = 45;
    private bool freeze;

    private XRBaseInteractable interactable;
    private bool isFollowing = false;

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

    void OnSelectEntered(BaseInteractionEventArgs args)
    {
        freeze = true;
        Debug.Log("Button Pressed!");
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;
            pokeAttach = interactor.attachTransform;
            offset = visualTarget.position - pokeAttach.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));

            if (pokeAngle > angleThreshold)
            {
                isFollowing = false;
                freeze = true;
            }
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