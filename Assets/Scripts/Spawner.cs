using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemyList;
    
    public Vector2 spawnPos = Vector2.zero;
    public Vector2 towerPos = Vector2.zero;
    public float safeRadius = 1f;
    public GameObject tower;
    TowerStats tStats;
    public float spawnDelay = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tStats = tower.GetComponent<TowerStats>();
        InvokeRepeating("SpawnEnemy",0f,spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
    public void SpawnEnemy()
    {
        if (!tStats.isGameOver)
        {
            int spawnIndex = Random.Range(0, enemyList.Length);
            do
            {
                spawnPos = new Vector2(Random.Range(-10f, 10f), Random.Range(-6f, 6f));
            } while (Vector2.Distance(spawnPos, towerPos) < safeRadius);
            GameObject enemy = Instantiate(enemyList[spawnIndex], spawnPos, enemyList[spawnIndex].GetComponent<EnemyInfo>().spawnRotation);
            enemy.GetComponent<EnemyMovementBasic>().tower = tower;
        }
        


    }
}
