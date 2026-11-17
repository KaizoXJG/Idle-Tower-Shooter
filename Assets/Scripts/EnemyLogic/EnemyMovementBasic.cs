using System;
using UnityEngine;

public class EnemyMovementBasic : MonoBehaviour
{
    public GameObject tower;
    public float speed = 1f;
    //bool isOnTower = false;
    public float towerDangerZone = 1f;
    TowerStats tStats; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tStats = tower.GetComponent<TowerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tStats.isGameOver)
        {
            MoveEnemy();
            Detectbreech();
        }
        
        
    }
    void MoveEnemy()
    {/*   manual path Calculation
        Vector2 path = tower.transform.position - transform.position;
        //float angle = (float)Math.Atan((path.y / path.x));    // It doesnt give direction info correctly
        float angle = (float)Math.Atan2(path.y , path.x);
        transform.position += new Vector3((float)(speed * Time.deltaTime * Math.Cos(angle)), (float)(speed * Time.deltaTime * Math.Sin(angle)));
        */

        
        if (Vector2.Distance(transform.position,tower.transform.position) >= towerDangerZone)
        {   // using normalized
            Vector2 path = tower.transform.position - transform.position;
            Vector3 direction = path.normalized;  // a unit vector in the same direction as the given vector 'path'
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    void Detectbreech()
    {
        if (Vector2.Distance(transform.position, tower.transform.position)<= towerDangerZone  )
        {
            if(tStats.towerHealth > 0)
            {
                tStats.towerHealth -= gameObject.GetComponent<EnemyInfo>().unitDamage;
            }
           
            Destroy(gameObject);
        }
    }
}
