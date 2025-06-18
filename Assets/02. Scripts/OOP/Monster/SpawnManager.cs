using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;
    
    [SerializeField] private GameObject[] items;
    
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            
            var randomIndex = Random.Range(0, monsters.Length);
            var randomX = Random.Range(-8, 9);
            var randomY = Random.Range(-3, 5);

            var createPos = new Vector3(randomX, randomY, 0);
            
            Instantiate(monsters[randomIndex], createPos, Quaternion.identity);
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length); // 랜덤 인덱스 설정

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity); // 아이템 생성
        
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        
        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }
}