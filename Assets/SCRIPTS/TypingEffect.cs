using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string fullText = "Welcome to your computer!";
    public float typingSpeed = 0.05f;

    private void Start()
    {
        textComponent.text = "";
    }

    public void StartTyping()
    {
        StartCoroutine(TypeText());
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
