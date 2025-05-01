using System.Collections;
using TMPro;
using UnityEngine;

public class TypeEffect : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public TextMeshPro tmpText3D;
    [TextArea] public string fullText;
    public float typingSpeed = 0.05f;

    public AudioClip typingSound; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 

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

            if (typingSound && audioSource)
                audioSource.PlayOneShot(typingSound); 

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator TypeText3D(TextMeshPro textComponent)
    {
        textComponent.text = "";
        foreach (char letter in fullText)
        {
            textComponent.text += letter;

            if (typingSound && audioSource)
                audioSource.PlayOneShot(typingSound);

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
