using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class ObjectInteractionColor : MonoBehaviour
{
    public Renderer objectRenderer;         // The gem’s renderer
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.yellow;

    public Renderer wallRendererToChange;   // 🎯 Only one wall — like "cuarto"
    public Material newWallMaterial;        // The material to change it to

    private XRGrabInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        objectRenderer.material.color = defaultColor;

        interactable.hoverEntered.AddListener(args => OnHoverEnter());
        interactable.hoverExited.AddListener(args => OnHoverExit());
        interactable.selectEntered.AddListener(args => OnSelect());
    }

    private void OnHoverEnter()
    {
        objectRenderer.material.color = hoverColor;
    }

    private void OnHoverExit()
    {
        objectRenderer.material.color = defaultColor;
    }

    private void OnSelect()
    {
        if (wallRendererToChange != null && newWallMaterial != null)
        {
            wallRendererToChange.material = newWallMaterial;
            Debug.Log("Wall material changed on: " + wallRendererToChange.name);
        }
        else
        {
            Debug.LogWarning("Wall or material not assigned!");
        }
    }
}
