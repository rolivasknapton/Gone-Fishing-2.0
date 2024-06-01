using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(string sceneName)
    {
        StartCoroutine(FadeToScene(sceneName));
    }

    IEnumerator FadeToScene(string sceneName)
    {
        Image blackScreenColor = Black_Screen_Fade.Instance.GetComponent<Image>();
        Color color = blackScreenColor.color;

        float fadeDuration = 1f; // Duration of the fade in seconds
        float timer = 0f;

        // Gradually increase alpha to 1 over fadeDuration seconds
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            blackScreenColor.color = color;
            yield return null;
        }

        // Ensure alpha is exactly 1 at the end of the loop
        color.a = 1f;
        blackScreenColor.color = color;

        // Now that the screen is black, load the scene
        SceneManager.LoadScene(sceneName);
    }
}
