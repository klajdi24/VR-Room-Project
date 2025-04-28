using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class ChairInteraction : MonoBehaviour
{
    public Transform seatPosition; // Empty GameObject where player should sit
    public Color hoverColor = new Color(0.5f, 0.8f, 1f); // Light blue on hover
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
        Vector3 seatPos = seatPosition.position;
        Quaternion seatRot = seatPosition.rotation;

        // Find the XR Rig's Camera (head)
        Camera headCamera = Camera.main; // Make sure your VR Camera is tagged as "MainCamera"
        if (headCamera != null)
        {
            Vector3 headOffset = headCamera.transform.position - player.transform.position;
            headOffset.y = 0f; // Ignore vertical height offset

            // Move player so that the head ends up at seat position
            player.transform.position = seatPos - headOffset;
            player.transform.rotation = seatRot;

            Debug.Log("✅ Player seated properly (head aligned)!");
        }
        else
        {
            Debug.LogWarning("⚠️ No Main Camera found for player head offset!");
        }

        // Start Typing Effect
        TypingEffect typer = FindObjectOfType<TypingEffect>();
        if (typer != null)
        {
            typer.StartTyping();
        }
    }
}}

