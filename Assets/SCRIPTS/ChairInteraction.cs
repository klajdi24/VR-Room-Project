using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class ChairInteraction : MonoBehaviour
{
    public Transform seatPosition; 
    public Color hoverColor = new Color(0.5f, 0.8f, 1f); 
    private Color originalColor;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.GetColor("_BaseColor");

        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (rend != null)
            rend.material.SetColor("_BaseColor", hoverColor);
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        if (rend != null)
            rend.material.SetColor("_BaseColor", originalColor);
    }

    private void OnSelect(SelectEnterEventArgs args)
{
    GameObject player = GameObject.FindWithTag("Player");
    
    if (player != null && seatPosition != null)
    {
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;

        Debug.Log(" Player rig teleported exactly to seat position (no head offset correction)!");
        
        
        TypingEffect typer = FindObjectOfType<TypingEffect>();
        if (typer != null)
        {
            typer.StartTyping();
        }
    }
}



}

