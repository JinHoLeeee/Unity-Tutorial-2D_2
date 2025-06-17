using System;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private IDropItem currentItem;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); // x축 오른쪽/왼쪽
        float v = Input.GetAxis("Vertical"); // z축 앞쪽/뒤쪽
        
        Vector3 dir = new Vector3(h, 0, v).normalized;
        
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void Interaction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use(); // 아이템 사용
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop(); // 아이템 버리기
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDropItem>() != null)
        {
            var item = other.GetComponent<IDropItem>();
            currentItem = item;
            
            currentItem.Grab(); // 아이템 줍기
        }
    }
}