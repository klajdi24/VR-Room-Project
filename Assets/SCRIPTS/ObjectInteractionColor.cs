using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class ObjectInteractionColor : MonoBehaviour
{
    public Renderer objectRenderer;
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.yellow;

    public Renderer wallRendererToChange;
    public Material newWallMaterial;

    private Material originalWallMaterial;
    private bool isToggled = false;
    private XRGrabInteractable interactable;

    public AudioSource ufoAudioSource; 

    void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        objectRenderer.material.color = defaultColor;

        if (wallRendererToChange != null)
        {
            originalWallMaterial = wallRendererToChange.material;
        }

        interactable.hoverEntered.AddListener(args => OnHoverEnter());
        interactable.hoverExited.AddListener(args => OnHoverExit());
        interactable.selectEntered.AddListener(args => OnSelect(args));
    }

    private void OnHoverEnter()
    {
        objectRenderer.material.color = hoverColor;
    }

    private void OnHoverExit()
    {
        objectRenderer.material.color = defaultColor;
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        if (wallRendererToChange == null || newWallMaterial == null || originalWallMaterial == null)
        {
            Debug.LogWarning("Wall or materials are not properly assigned.");
            return;
        }

        if (!isToggled)
        {
            wallRendererToChange.material = newWallMaterial;
            Debug.Log("Wall changed to galaxy material.");

            if (ufoAudioSource && !ufoAudioSource.isPlaying)
                ufoAudioSource.Play();
        }
        else
        {
            wallRendererToChange.material = originalWallMaterial;
            Debug.Log("Wall reverted to original material.");

            if (ufoAudioSource && ufoAudioSource.isPlaying)
                ufoAudioSource.Stop();
        }

        isToggled = !isToggled;
    }
}
