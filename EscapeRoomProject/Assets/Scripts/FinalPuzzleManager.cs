using System.Collections;
using TMPro;
using UnityEngine;

public class FinalPuzzleManager : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI textBox;
    private AudioSource speaker;

    public AudioClip correctSound;
    public AudioClip incorrectSound;

    private bool activated = false;

    private string solution = "\u2191 \u2191 \u2193 \u2193 \u2190\u2192\u2190\u2192B A ";
    private string input = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox.text = input;
        speaker = GetComponent<AudioSource>();
    }

    public void CheckResult(string value)
    {
        if (activated)
        {
            input += value;
            textBox.text = input;
            if (input.Length == solution.Length)
            {
                if (input == solution)
                {
                    FindFirstObjectByType<GameManager>().updateTickets(1000);
                    speaker.resource = correctSound;
                    StartCoroutine(playCorrectSound());
                    activated = false;
                }
                else
                {
                    speaker.resource = incorrectSound;
                    speaker.Play();
                    input = "";
                    textBox.text = input;
                }
            }
            if (input.Length > solution.Length)
            {
                speaker.resource = incorrectSound;
                speaker.Play();
                input = "";
                textBox.text = input;
            }
        }
    }

    IEnumerator playCorrectSound()
    {
        for (int i = 0; i < 5; i++)
        {
            speaker.Play();
            yield return new WaitForSeconds(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crowbar")
        {
            canvas.GetComponent<CanvasGroup>().alpha = 1.0f;
            activated = true;
            GameManager.progressCount++;
        }
    }
}
