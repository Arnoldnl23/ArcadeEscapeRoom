using UnityEngine;
using UnityEngine.Events;
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

    public float angleThreshold = 45;

    private bool freeze;

    private GameObject mazePlayerObject;
    private Transform mazePlayerTransform;
    public Vector3 moveDirection;
    public RuntimeAnimatorController playerDirection;
    private Vector3 lastMoveDirection;

    private XRBaseInteractable interactable;
    private bool isFollowing = false;


    void Start()
    {
        initialPos = visualTarget.localPosition;
        mazePlayerObject = GameObject.Find("MazePlayer");
        mazePlayerTransform = mazePlayerObject.GetComponent<Transform>();
        

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

    private void Update()
    {
        if (freeze)
        {
            if (mazePlayerObject.GetComponent<Player>().isColliding == false)
            {
                mazePlayerTransform.Translate(moveDirection * Time.deltaTime);
                mazePlayerObject.GetComponent<Animator>().runtimeAnimatorController = playerDirection;
                mazePlayerObject.GetComponent<Player>().lastMoveDirection = moveDirection;
            }
            else
            {
                mazePlayerTransform.Translate(mazePlayerObject.GetComponent<Player>().lastMoveDirection * -3 * Time.deltaTime);
            }
            return;
        }

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
    }


}
