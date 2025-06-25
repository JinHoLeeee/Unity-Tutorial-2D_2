using System;
using UnityEngine;

public class TriggerEvent2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
    }
}