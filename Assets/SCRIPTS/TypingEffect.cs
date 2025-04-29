using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string fullText = "Welcome to your computer! Type Password";
    public float typingSpeed = 0.05f;

    private void Start()
    {
        textComponent.text = "";
    }

    public void StartTyping()
{
    StartCoroutine(DelayedTypeText());
}

private IEnumerator DelayedTypeText()
{
    yield return new WaitForSeconds(2f); // ⏳ Wait 2 seconds first
    StartCoroutine(TypeText()); // ➡️ Then start the typing animation
}


    IEnumerator TypeText()
    {
        textComponent.text = "";

        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
