using System;
using UnityEngine;

public class EnemyMovementBasic : MonoBehaviour
{
    public GameObject tower;
    public float speed = 1f;
    //bool isOnTower = false;
    public float towerDangerZone = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
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
}
