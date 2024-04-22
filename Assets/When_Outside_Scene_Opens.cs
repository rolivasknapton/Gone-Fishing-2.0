using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class When_Outside_Scene_Opens : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Image blackScreenColor = Black_Screen_Fade.Instance.GetComponent<Image>();
        Color color = blackScreenColor.color;

        float fadeDuration = 1f; // Duration of the fade in seconds
        float timer = 0f;

        // Gradually increase alpha to 0 over fadeDuration seconds
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            blackScreenColor.color = color;
            yield return null;
        }

        // Ensure alpha is exactly 0 at the end of the loop
        color.a = 0f;
        blackScreenColor.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
