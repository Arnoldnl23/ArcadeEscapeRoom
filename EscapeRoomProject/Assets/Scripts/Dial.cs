using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Random = UnityEngine.Random;

public class Dial : MonoBehaviour
{
    public float currentIndex;
    private XRBaseInteractable interactable;
    private XRKnob knob;

    [SerializeField] private UnityEvent<Dial> onDialRotated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        interactable = GetComponent<XRBaseInteractable>();
        knob = GetComponent<XRKnob>();

        currentIndex = Random.Range(0, 10);
        knob.value = currentIndex / 10;

        if (interactable != null)
        {
            interactable.selectExited.AddListener(AfterRelease);
            interactable.selectEntered.AddListener(OnGrab);
        }
    }

    public void OnGrab(BaseInteractionEventArgs select)
    {
        Debug.Log("Grabbing " + gameObject.name);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void AfterRelease(BaseInteractionEventArgs select)
    {
        currentIndex = 9 - (int)(knob.value * 10); 

        if (currentIndex >= 10)
        {
            currentIndex -= 10;
        }
        if (currentIndex < 0)
        {
            currentIndex = 0;
        }
        Debug.Log(gameObject.name + " value: " + currentIndex);

        onDialRotated?.Invoke(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
