using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MazeButtons : MonoBehaviour
{
    private Transform movingPart;
    private Vector3 pressDirection = Vector3.down;
    private float pressDistance = 0.2f;
    private Vector3 startPosition;

    private Transform mazePlayer;
    public Vector3 moveDirection;

    private XRBaseInteractable interactable;
    
    void Start()
    {
        movingPart = GetComponent<Transform>();
        startPosition = transform.position;

        mazePlayer = GameObject.Find("MazePlayer").GetComponent<Transform>();

        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntered);
            interactable.selectExited.AddListener(OnSelectExited);
        }
    }

    // This method is called when an interactor starts hovering or selecting
    void OnSelectEntered(SelectEnterEventArgs args)
    {

        Debug.Log("Button Pressed!");
        movingPart.localPosition = startPosition + (pressDirection * pressDistance);
        
        // Trigger movement based on which button it is
        mazePlayer.Translate(moveDirection * Time.deltaTime);
    }

    // This method is called when the interactor stops selecting
    void OnSelectExited(SelectExitEventArgs args)
    {
        // Return button to original position
        movingPart.localPosition = startPosition;
    }
}
