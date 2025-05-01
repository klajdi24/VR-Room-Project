using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string fullText = "Welcome to your computer!";
    public float typingSpeed = 0.05f;

    public AudioClip typingSound;      
    private AudioSource audioSource;   

    private void Start()
    {
        textComponent.text = "";
        audioSource = GetComponent<AudioSource>(); 
    }

    public void StartTyping()
    {
        StartCoroutine(DelayedTypeText());
    }

    private IEnumerator DelayedTypeText()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";

        foreach (char c in fullText)
        {
            textComponent.text += c;

            
            if (typingSound && audioSource)
                audioSource.PlayOneShot(typingSound);

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
