using System.Collections;
using TMPro;
using UnityEngine;

public class TypeEffect : MonoBehaviour
{
    public TextMeshProUGUI tmpText; // For Canvas UI
    public TextMeshPro tmpText3D;   // For 3D world text (optional)
    [TextArea] public string fullText;
    public float typingSpeed = 0.05f;

    private void Start()
    {
        if (tmpText != null)
            StartCoroutine(TypeText(tmpText));
        else if (tmpText3D != null)
            StartCoroutine(TypeText3D(tmpText3D));
    }

    IEnumerator TypeText(TextMeshProUGUI textComponent)
    {
        textComponent.text = "";
        foreach (char letter in fullText)
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator TypeText3D(TextMeshPro textComponent)
    {
        textComponent.text = "";
        foreach (char letter in fullText)
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
