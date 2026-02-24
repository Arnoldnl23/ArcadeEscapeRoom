using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MazeButtons : MonoBehaviour
{
    public Transform movingPart;
    public Vector3 pressDirection = Vector3.down;
    public float pressDistance = 0.1f;
    private Vector3 startPosition;

    public GameObject mazePlayer;
    public Vector3 moveDirection;

    private XRBaseInteractable interactable;
    
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
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
    }

    // This method is called when the interactor stops selecting
    void OnSelectExited(SelectExitEventArgs args)
    {
        // Return button to original position
        movingPart.localPosition = startPosition;
    }
}
