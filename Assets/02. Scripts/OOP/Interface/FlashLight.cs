using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public void Grab()
    {
        Debug.Log("손전등을 주웠다.");
    }

    public void Use()
    {
        Debug.Log("손전등을 켠다.");
    }

    public void Drop()
    {
        Debug.Log("손전등을 버렸다.");
    }
}