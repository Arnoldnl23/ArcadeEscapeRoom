using UnityEngine;
using System.Collections;

public class BirdTarget : MonoBehaviour
{
    [SerializeField] private GameObject birdObject;   // the normal bird
    [SerializeField] private GameObject hitObject;    // the hit animation/effect
    [SerializeField] private GameObject numberObject;
    [SerializeField] private GameObject fallObject;
    [SerializeField] private float respawnTime = 2.5f;
    [SerializeField] private float respawnBirdTime = 2f;
    private Vector3 fallStartPosition;

    void Start()
    {
        if (fallObject != null)
        {
            fallStartPosition = fallObject.transform.position;
        }
    }

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

        // Wait for hit animation (1 second)
        yield return new WaitForSeconds(1f);

        // Hit effect disappears
        hitObject.SetActive(false);

        // Falling bird + number appear at same time
        fallObject.transform.position = fallStartPosition;
        fallObject.SetActive(true);
        numberObject.SetActive(true);

        // Wait for fall + number display
        yield return new WaitForSeconds(respawnTime);

        // Hide fall + number
        fallObject.SetActive(false);
        fallObject.transform.position = fallStartPosition;
        numberObject.SetActive(false);

        // Respawn delay
        yield return new WaitForSeconds(respawnBirdTime);

        // Bird comes back
        birdObject.SetActive(true);
    }

}