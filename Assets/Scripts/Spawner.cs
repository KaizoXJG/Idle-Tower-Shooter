using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemyList;
    
    public Vector2 spawnPos = Vector2.zero;
    public Vector2 towerPos = Vector2.zero;
    public float safeRadius = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, enemyList.Length);
        do
        {
            spawnPos = new Vector2(Random.Range(-5f, 5f), Random.Range(-4f, 4f));
        } while (Vector2.Distance(spawnPos, towerPos) < safeRadius);
        Instantiate(enemyList[spawnIndex], spawnPos, enemyList[spawnIndex].GetComponent<EnemyInfo>().spawnRotation);



    }
}
