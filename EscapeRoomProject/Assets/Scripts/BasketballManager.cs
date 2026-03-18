using Mono.Cecil;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BasketballManager : MonoBehaviour
{
    private List<int> correctSeries = new List<int>{ 0, 1, 0, 0, 1 };
    private List<int> currentSeries = new List<int> {};

    private bool beenCompleted = false;

    private AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void checkResult(int value)
    {
        if (!beenCompleted)
        {
            currentSeries.Add(value);
            if (currentSeries.Count == 4)
            {
                for (int i = 0; i < currentSeries.Count; i++)
                {
                    if (currentSeries[i] != correctSeries[i])
                    {
                        currentSeries.Clear();
                        audioSource.resource = incorrectSound;
                        audioSource.Play();
                        return;
                    }
                }

                Instantiate(Resources.Load<GameObject>("Crowbar"), new Vector3(25.1299992f, 0.867999971f, -11.8599997f), new Quaternion(0, 0, 0, 0));
                audioSource.resource = correctSound;
                audioSource.Play();
                FindFirstObjectByType<GameManager>().updateTickets(10);
                GameManager.progressCount++;
                beenCompleted = true;
            }
        }
    }
}
