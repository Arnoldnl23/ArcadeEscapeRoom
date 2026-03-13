using UnityEngine;
using UnityEngine.Events;

public class BasketballHoop : MonoBehaviour
{
    [SerializeField] private UnityEvent<BasketballHoop> onBallEnter;

    private void OnTriggerEnter(Collider other)
    {
        onBallEnter?.Invoke(this);
    }
}
