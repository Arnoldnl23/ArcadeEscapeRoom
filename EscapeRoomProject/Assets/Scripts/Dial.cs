using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Random = UnityEngine.Random;

public class Dial : MonoBehaviour
{
    public float currentIndex;
    private XRBaseInteractable interactable;

    [SerializeField] private UnityEvent<Dial> onDialRotated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = Random.Range(0, 10);
        transform.rotation = Quaternion.Euler(currentIndex * 36, 0, 90);

        interactable = GetComponent<XRBaseInteractable>();
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
        Debug.Log("Current rotation: " + transform.rotation.x);
        //snap downwards
        //if (transform.localRotation.x % 36 > 17)
        //{
        //    float rotationVal = transform.localRotation.x - (transform.localRotation.x % 36);
        //    transform.localRotation = Quaternion.Euler(rotationVal, 0, 90);
        //    currentIndex = Math.Abs(rotationVal / 36);
        //}
        //else //snap upwards
        //{
        //    float rotationVal = transform.localRotation.x + (36 - (transform.localRotation.x % 36));
        //    transform.localRotation = Quaternion.Euler(rotationVal, 0, 90);
        //    currentIndex = Math.Abs(rotationVal / 36);
        //}
        if (currentIndex >= 10)
        {
            currentIndex -= 10;
        }
        Debug.Log(gameObject.name + " value: " + currentIndex);

        onDialRotated?.Invoke(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
