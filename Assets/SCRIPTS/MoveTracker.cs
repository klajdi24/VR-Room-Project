using UnityEngine;

public class MoveTracker : MonoBehaviour
{
    public Transform winningSquare;
    public Transform winningAnchor;

    public GameObject winText;
    public GameObject wrongText;
    public GameObject initialText;       
    public GameObject finalMoveText3D;   

    public ParticleSystem winParticles;

    public AudioClip winSound;
    public AudioClip wrongSound;

    public ChessTriggerZone triggerZone;

    private AudioSource audioSource;
    private bool hasWon = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (finalMoveText3D != null)
            finalMoveText3D.SetActive(false);

        if (winText != null)
            winText.SetActive(false);

        if (wrongText != null)
            wrongText.SetActive(false);
    }

    public void CheckMove(Transform piece)
    {
        if (hasWon) return;

        bool isWinningMove =
            piece.CompareTag("Queen") &&
            Vector3.Distance(piece.position, winningAnchor.position) < 0.05f;

        if (isWinningMove)
        {
            ShowWin();
        }
        else
        {
            ShowWrong();
        }
    }

    public void ShowWin()
    {
        hasWon = true;

        if (winParticles != null)
            winParticles.Play();

        if (audioSource != null && winSound != null)
            audioSource.PlayOneShot(winSound);

        if (winText != null) winText.SetActive(true);
        if (wrongText != null) wrongText.SetActive(false);
        if (finalMoveText3D != null) finalMoveText3D.SetActive(false);
        if (initialText != null) initialText.SetActive(false);
    }

    public void ShowWrong()
    {
        if (hasWon) return; 

        if (audioSource != null && wrongSound != null)
            audioSource.PlayOneShot(wrongSound);

        if (finalMoveText3D != null)
            finalMoveText3D.SetActive(false);

        if (wrongText != null)
            wrongText.SetActive(true);

        Invoke(nameof(HideWrong), 2f);
    }

    private void HideWrong()
    {
        if (hasWon) return;

        if (wrongText != null)
            wrongText.SetActive(false);

        if (triggerZone != null && triggerZone.IsPlayerInside())
        {
            if (finalMoveText3D != null)
                finalMoveText3D.SetActive(true);
        }
    }

    public bool HasPlayerWon()
    {
        return hasWon;
    }
}
