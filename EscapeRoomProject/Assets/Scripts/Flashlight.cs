using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Flashlight : MonoBehaviour
{
    private XRBaseInteractable interactable;
    private bool hasBeenPickedUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasBeenPickedUp = false;

        interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(BeenGrabbed);
        }
    }

    public void BeenGrabbed(BaseInteractionEventArgs select)
    {
        if (!hasBeenPickedUp)
        {
            hasBeenPickedUp = true;
            GameManager.tickets -= 10;
        }
        Debug.Log("Total tickets: " + GameManager.tickets);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
