using UnityEngine;

public class ChessTriggerZone : MonoBehaviour
{
    public GameObject promptText;       // "INTERACT WITH ME"
    public GameObject finalMoveText3D;  // "MAKE THE FINAL MOVE"
    public AudioClip enterSound;

    private AudioSource audioSource;
    private bool playerInside = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (promptText != null)
            promptText.SetActive(true);

        if (finalMoveText3D != null)
            finalMoveText3D.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            // 🛑 Don't show anything if player already won
            if (FindObjectOfType<MoveTracker>().HasPlayerWon())
                return;

            if (promptText != null)
                promptText.SetActive(false);

            if (finalMoveText3D != null)
                finalMoveText3D.SetActive(true);

            if (enterSound != null && audioSource != null)
                audioSource.PlayOneShot(enterSound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            // 🛑 Don't show anything if player already won
            if (FindObjectOfType<MoveTracker>().HasPlayerWon())
                return;

            if (finalMoveText3D != null)
                finalMoveText3D.SetActive(false);

            if (promptText != null)
                promptText.SetActive(true);
        }
    }

    public bool IsPlayerInside()
    {
        return playerInside;
    }
}
