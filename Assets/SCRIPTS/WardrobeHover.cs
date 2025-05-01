using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeHover : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            
            originalColor = rend.material.GetColor("_BaseColor");
        }
    }

    public void Hovered()
    {
        Debug.Log("hovered");
        if (rend != null)
        {
            rend.material.SetColor("_BaseColor", new Color(0.5f, 0.8f, 1f)); // Light blue color
        }
    }

    public void Unhovered()
    {
        Debug.Log("unhovered");
        if (rend != null)
        {
            rend.material.SetColor("_BaseColor", originalColor); // Return to original color
        }
    }
}
