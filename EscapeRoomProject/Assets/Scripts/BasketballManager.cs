using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BasketballManager : MonoBehaviour
{
    public List<int> correctSeries = new List<int>{ 0, 1, 1, 0 };
    private List<int> currentSeries = new List<int> { 0, 1, 1 };

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void checkResult(int value)
    {
        currentSeries.Add(value);
        if (currentSeries.Count == 4)
        {
            for (int i = 0; i < currentSeries.Count; i++) { 
                if (currentSeries[i] != correctSeries[i])
                {
                    currentSeries.Clear();
                    audioSource.Play();
                    return;
                }
            }

            Instantiate(Resources.Load<GameObject>("Crowbar"), new Vector3(25.1299992f, 0.867999971f, -11.8599997f), new Quaternion(0, 0, 0, 0));
            audioSource.Play();
            this.enabled = false;
        }
    }
}
