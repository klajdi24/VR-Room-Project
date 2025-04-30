using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class ObjectInteractionColor : MonoBehaviour
{
    public Renderer objectRenderer;          // The gem’s renderer
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.yellow;

    public Renderer wallRendererToChange;    // Wall to change (e.g., "cuarto")
    public Material newWallMaterial;         // Material to apply when toggled

    private Material originalWallMaterial;   // To store the original wall material
    private bool isToggled = false;          // Tracks toggle state
    private XRGrabInteractable interactable;

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
        interactable.selectEntered.AddListener(args => OnSelect(args)); // ✅ Fix here
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
            Debug.Log("Wall changed to new material.");
        }
        else
        {
            wallRendererToChange.material = originalWallMaterial;
            Debug.Log("Wall reverted to original material.");
        }

        isToggled = !isToggled;
    }
}
