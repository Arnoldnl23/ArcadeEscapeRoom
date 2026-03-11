using UnityEngine;
using System.Collections;

public class BirdTarget : MonoBehaviour
{
    [SerializeField] private GameObject birdObject;   // the normal bird
    [SerializeField] private GameObject hitObject;    // the hit animation/effect
    [SerializeField] private float respawnTime = 1f;

    public void Hit()
    {
        StartCoroutine(HitRoutine());
    }

    IEnumerator HitRoutine()
    {
        // Bird disappears
        birdObject.SetActive(false);

        // Hit effect appears
        hitObject.SetActive(true);

        // Wait
        yield return new WaitForSeconds(respawnTime);

        // Hit effect disappears
        hitObject.SetActive(false);

        // Bird comes back
        birdObject.SetActive(true);
    }
}