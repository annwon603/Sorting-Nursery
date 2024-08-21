using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIN : MonoBehaviour
{
    public Image fadeImage;       // The UI Image component for the fade effect
    public float fadeDuration = 3.0f; // Duration of the fade-in in seconds

    public GameObject Cecil;

    public GameObject SPLAT;

    public DialogueManager dialogueManager;

    public GameObject PlayerInput;

    private void Start()
    {
        // Start the fade-in effect when the scene starts
        StartCoroutine(FadeIn());

        StartCoroutine(TriggerFadeOutAfterDelay(5f));

        dialogueManager.endDialogueDelegate = PutName;
    }

    // Coroutine for fading in
    private IEnumerator FadeIn()
    {
        float timer = 0f;
        Color fadeColor = fadeImage.color;

        // Gradually reduce the alpha value of the image from 1 (black) to 0 (transparent)
        while (timer <= fadeDuration)
        {
            timer += Time.deltaTime;
            fadeColor.a = 1 - (timer / fadeDuration);  // Interpolates alpha from 1 to 0
            fadeImage.color = fadeColor;
            yield return null;
        }

        // Ensure the image is fully transparent at the end
        fadeColor.a = 0f;
        fadeImage.color = fadeColor;
    }

    public IEnumerator FadeOut()
    {
        float timer = 0f;
        Color fadeColor = fadeImage.color;

        while (timer <= fadeDuration)
        {
            timer += Time.deltaTime;
            fadeColor.a = timer / fadeDuration; // Fade from transparent to black
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 1f;
        fadeImage.color = fadeColor; // Ensure the image is fully black at the end
        SPLAT.SetActive(false);
        Cecil.SetActive(true);
        StartCoroutine(FadeIn());
        StartCoroutine(StartDialogue());

    }

    public void TriggerFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator TriggerFadeOutAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        TriggerFadeOut();
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(5.0f);
        dialogueManager.TextBox.SetActive(true);
        GameObject.Find("IntroDialougue").GetComponent<DialogueTrigger>().enabled = true;

    }

    public void PutName()
    {
        PlayerInput.SetActive(true);
    }
}
