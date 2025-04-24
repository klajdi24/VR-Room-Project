using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChessTriggerZone : MonoBehaviour
{
    public Canvas messageCanvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageCanvas.gameObject.SetActive(true);
            messageCanvas.GetComponentInChildren<Text>().text = "Play the final move to win the game.";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageCanvas.gameObject.SetActive(false);
        }
    }
}

