using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroSequence : MonoBehaviour
{
    public GameObject intro_text1;
    public GameObject intro_text2;
    public GameObject intro_text3;
    public GameObject intro_text4;

    IEnumerator Start()
    {
        GameObject[] textObjects = new GameObject[]
        {
            intro_text1,
            intro_text2,
            intro_text3,
            intro_text4
        };

        GameObject lastTextObject = null;
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        foreach (GameObject textObject in textObjects)
        {
            TextMeshProUGUI textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                yield return StartCoroutine(FadeTextAlpha(textMeshPro, 1f, 1f)); // Step 1
                yield return new WaitForSeconds(5f); // Wait for 3 seconds

                yield return StartCoroutine(FadeTextAlpha(textMeshPro, 0f, 1f)); // Step 2
                lastTextObject = textObject; // Update the last text object
                yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
            }
            else
            {
                Debug.LogError("TextMeshPro component not found on the GameObject.");
            }
        }

        // After the last object's alpha reaches 0, execute the debug log
        if (lastTextObject != null)
        {
            yield return StartCoroutine(WaitForAlphaZero(lastTextObject.GetComponent<TextMeshProUGUI>())); // Wait for alpha to reach 0

            //this is where you change the scene
            SceneManager.LoadScene("Inside");


            Debug.Log("hi!");
        }
    }

    IEnumerator FadeTextAlpha(TextMeshProUGUI textMeshPro, float targetAlpha, float duration)
    {
        float startAlpha = textMeshPro.color.a;
        float timer = 0f;

        while (timer < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / duration);
            Color newColor = textMeshPro.color;
            newColor.a = alpha;
            textMeshPro.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha reaches exactly the target value
        Color finalColor = textMeshPro.color;
        finalColor.a = targetAlpha;
        textMeshPro.color = finalColor;
    }

    IEnumerator WaitForAlphaZero(TextMeshProUGUI textMeshPro)
    {
        while (textMeshPro.color.a > 0)
        {
            yield return null;
        }
    }
}
