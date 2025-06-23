using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] turretPrefabs;
    
    void OnMouseDown()
    {
        Instantiate(turretPrefabs[SetTile.turretIndex], transform.position, Quaternion.identity);
    }
}