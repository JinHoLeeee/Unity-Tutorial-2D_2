using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters; // 몬스터 종류가 이미 정해진 상태

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
}