using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Random = UnityEngine.Random;

public class LockManager : MonoBehaviour
{
    [SerializeField] private Dial[] dials;
    private string solution = "8352";

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

        Instantiate(Resources.Load<GameObject>("Basketball"), new Vector3(23.2609997f, 1.51199996f, -9.69799995f), new Quaternion(0, 0, 0, 0));
        //Play correct sound effect
        Destroy(lockParent);
    }

}
