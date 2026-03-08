using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Random = UnityEngine.Random;

public class LockManager : MonoBehaviour
{
    [SerializeField] private Dial[] dials;
    [SerializeField] private string solution;

    public GameObject lockParent;

    public void CheckCombination ()
    {
        for (int i = 0; i < dials.Length; i++)
        {
            int combinationNumber = int.Parse(solution[i].ToString());
            if (combinationNumber != dials[i].currentIndex)
            {
                return;
            }
        }

        Destroy(lockParent);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
