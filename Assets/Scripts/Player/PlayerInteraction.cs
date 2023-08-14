using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject uiInteraction;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 2;
    [SerializeField] private LayerMask interactableLayer;

    private readonly Collider[] colliders = new Collider[5];
    private int numFound;

    private void Update()
    {
        InteractionWithObject();
    }

    private void InteractionWithObject()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, 
                interactionPointRadius, 
                colliders, 
            interactableLayer);

        if (numFound > 0)
        {
            uiInteraction.SetActive(true);

            var interactable = colliders[0].GetComponent<IPlayerInteraction>();

            if (interactable != null && Input.GetKeyDown(KeyCode.F))
            {
                interactable.Interact(player, this);
            }
        }
        else
        {
            uiInteraction.SetActive(false);
        }
    }
}