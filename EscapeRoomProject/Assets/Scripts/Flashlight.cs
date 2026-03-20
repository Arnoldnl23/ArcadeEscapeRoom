using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Flashlight : MonoBehaviour
{
    private XRBaseInteractable interactable;
    private bool hasBeenPickedUp;
    public GameObject spotLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasBeenPickedUp = false;

        interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(BeenGrabbed);
            interactable.selectExited.AddListener(AfterGrabbed);
        }
    }

    public void BeenGrabbed(BaseInteractionEventArgs select)
    {
        spotLight.SetActive(true);
        if (!hasBeenPickedUp)
        {
            hasBeenPickedUp = true;
            FindFirstObjectByType<GameManager>().updateTickets(-10);
        }
    }

    public void AfterGrabbed(BaseInteractionEventArgs select)
    {
        spotLight.SetActive(false);
        hasBeenPickedUp = true;
    }

}
