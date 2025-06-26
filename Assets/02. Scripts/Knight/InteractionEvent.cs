using System;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public enum InteractionType { SIGN, DOOR, NPC }
    public InteractionType type;

    public GameObject signPopup;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interaction(other.transform);
        }
    }

    void Interaction(Transform player)
    {
        switch (type)
        {
            case InteractionType.SIGN:
                signPopup.SetActive(true);
                break;
            case InteractionType.DOOR:
                
                break;
            case InteractionType.NPC:
                
                break;
        }
    }
}