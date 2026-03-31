using UnityEngine;

public class HintSystem : MonoBehaviour
{
    [Header("Game 1 Hints")]
    public GameObject hint1A;
    public GameObject hint1B;

    [Header("Game 2 Hints")]
    public GameObject hint2A;
    public GameObject hint2B;

    [Header("Game 3 Hints")]
    public GameObject hint3A;
    public GameObject hint3B;

    [Header("Game 4 Hints")]
    public GameObject hint4A;
    public GameObject hint4B;

    [Header("Game 5 Hint")]
    public GameObject hint5;

    [Header("Final Puzzle Hints")]
    public GameObject hint6A;
    public GameObject hint6B;
    public GameObject hint6C;

    // Tracks how many times player pressed hint button per stage
    private int hintStep = 0;
    private int lastProgress = -1;

    public void GiveHint()
    {
        int progress = GameManager.progressCount;

        // Reset hint step when player progresses
        if (progress != lastProgress)
        {
            hintStep = 0;
            lastProgress = progress;
        }

        Debug.Log("Progress: " + progress + " | Hint Step: " + hintStep);

        switch (progress)
        {
            case 0: ActivateHint(hint1A, hint1B); break;
            case 1: ActivateHint(hint2A, hint2B); break;
            case 2: ActivateHint(hint3A, hint3B); break;
            case 3: ActivateHint(hint4A, hint4B); break;
            case 4: ActivateSingle(hint5); break;
            case 5: ActivateFinalHints(); break;
        }
    }

    void ActivateHint(GameObject hintA, GameObject hintB)
    {
        if (hintStep == 0)
        {
            hintA.SetActive(true);
        }
        else if (hintStep == 1)
        {
            hintB.SetActive(true);
        }

        hintStep++;
    }

    void ActivateSingle(GameObject hint)
    {
        hint.SetActive(true);
    }

    void ActivateFinalHints()
    {
        switch (hintStep)
        {
            case 0: hint6A.SetActive(true); break;
            case 1: hint6B.SetActive(true); break;
            case 2: hint6C.SetActive(true); break;
        }

        hintStep++;
    }
}