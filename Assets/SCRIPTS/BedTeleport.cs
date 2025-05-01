using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class BedTeleport : MonoBehaviour
{
    public Transform bedPosition; // The transform to teleport the player to
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

        if (player != null && bedPosition != null)
        {
            player.transform.position = bedPosition.position;
            player.transform.rotation = bedPosition.rotation;

            Debug.Log(" Player teleported to bed.");
        }
    }
}
