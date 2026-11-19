using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public TowerStats tStats;

    public List<EnemyInfo> enemyList = new List<EnemyInfo>();
    public Vector2 towerPos;
    public delegate int targettingFunction(List<EnemyInfo> enemyList);
    public targettingFunction CurrentTargetIndexFunction;
    public EnemyInfo currentTarget = null;
    public List<GameObject> attacks = new List<GameObject>();



    void Start()
    {
        tStats = GetComponent<TowerStats>();
        InvokeRepeating("DamageCurrentEnemy", 0f, tStats.towerAttackSpeed);
        towerPos = tStats.transform.position;
        
    }
    void Update()
    {
        GetComponent<CircleCollider2D>().radius = tStats.towerRange;
        CurrentTargetIndexFunction = RandomEnemyIndex;
        if (enemyList.Count > 0 && currentTarget==null)
        {
            //currentTarget = enemyList[CurrentTargetIndexFunction(enemyList)];
            TargetCurrentEnemy();
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enemy!");
        enemyList.Add(other.gameObject.GetComponent<EnemyInfo>());

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyList.Remove(collision.gameObject.GetComponent<EnemyInfo>());
        //Debug.Log("Enemy Left!");
    }


    void DamageCurrentEnemy()
    {
        if (enemyList.Count > 0)
        {
            for (int i = 0; i < attacks.Count; i++)
            {
                GameObject attack = Instantiate(attacks[i], transform.position, attacks[i].GetComponent<AttackInfo>().spawnRotation);
                attack.GetComponent<StraightProjectileMovement>().towerAtk = this;
                attack.GetComponent<DamageEnemy>().towerAtk = this;
            }
            //Debug.Log("Attacking" + enemyList[0].name);
            //enemy.unitHP -= tStats.towerDamage;
            /*if (currentTarget.unitHP <= 0)
            {
                enemyList.Remove(currentTarget); //it is destroyed here cause sometimes Destroy() doesn't remove the object during same frame rather it is marked for deconstruction for next frame , this can cause null exception as we are trying to access a element which might not exist
                Destroy(currentTarget.gameObject);
            }*/
        }
        
    }
    public int ClosestEnemyIndex(List<EnemyInfo> enemyList)
    {
        int closestIndex = 0;
        float leastDist = 10000f;
        for (int i = 0; i < enemyList.Count; i++)
        {
           if( Vector2.Distance(towerPos, enemyList[i].transform.position) < leastDist)
           {
                closestIndex = i;
                leastDist = Vector2.Distance(towerPos,enemyList[i].transform.position);
           }
        }
        return closestIndex;
    }
    public int FarthestEnemyIndex(List<EnemyInfo> enemyList)
    {
        int farthestIndex = 0;
        float greatestDist = 0f;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (Vector2.Distance(towerPos, enemyList[i].transform.position) > greatestDist)
            {
                farthestIndex = i;
                greatestDist = Vector2.Distance(towerPos, enemyList[i].transform.position);
            }
        }
        return farthestIndex;
    }
    public int RandomEnemyIndex(List<EnemyInfo> enemyList)
    {
        return UnityEngine.Random.Range(0,(enemyList.Count));
    }
    void TargetCurrentEnemy()  //to pass a parameterless function to InvokeRepeating
    {
        if (enemyList.Count > 0 && currentTarget == null)
        {
            currentTarget =  enemyList[CurrentTargetIndexFunction(enemyList)];
        }
    }


}
