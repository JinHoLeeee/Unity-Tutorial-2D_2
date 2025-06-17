using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public void Grab()
    {
        Debug.Log("총을 주웠다.");
    }

    public void Use()
    {
        Debug.Log("총을 발사한다.");
    }

    public void Drop()
    {
        Debug.Log("총을 버렸다.");
    }
}