using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MazeButtons : MonoBehaviour
{
    public Transform visualTarget;
    private Transform pokeAttach;
    private Vector3 initialPos;
    private Vector3 offset;
    private Vector3 localAxis = new Vector3(0,-1,0);

    private bool freeze;

    private Transform mazePlayer;
    public Vector3 moveDirection;

    private XRBaseInteractable interactable;
    private bool isFollowing = false;
    
    void Start()
    {
        initialPos = visualTarget.localPosition;
        mazePlayer = GameObject.Find("MazePlayer").GetComponent<Transform>();

        interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(Follow);
            interactable.selectEntered.AddListener(OnSelectEntered);
            interactable.hoverExited.AddListener(Reset);
        }
    }

    public void Follow (BaseInteractionEventArgs hover)
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

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    private void Update()
    {
        if (freeze)
            mazePlayer.Translate(moveDirection * Time.deltaTime);

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

    // This method is called when an interactor starts hovering or selecting
    void OnSelectEntered(BaseInteractionEventArgs args)
    {
        freeze = true;
        Debug.Log("Button Pressed!");
        
        // Trigger movement based on which button it is

    }


}
