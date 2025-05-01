using UnityEngine;

public class ChessTriggerZone : MonoBehaviour
{
    public ChessGameManager gameManager; // Reference to the ChessGameManager
    public string finalMoveMessage = "Make the final move to win!";
    
    public AudioClip enterSound; // 🎵 Entry sound
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone!");
            gameManager.ShowMessage(finalMoveMessage, true);

            if (enterSound && audioSource)
                audioSource.PlayOneShot(enterSound); // 🔊 Play sound on entry
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone!");
            gameManager.HideMessage();
            // ❌ No sound here
        }
    }
}
