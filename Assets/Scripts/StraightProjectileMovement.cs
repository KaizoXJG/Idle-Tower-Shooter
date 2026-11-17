using System;
using UnityEngine;

public class StraightProjectileMovement : MonoBehaviour
{
    //public GameObject tower;
    public TowerAttack towerAtk;
    public float speed = 10f;
    Vector2 enemyPos,movementDirection;
    private EnemyInfo enemy;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //towerAtk = tower.GetComponent<TowerAttack>();
        if (towerAtk.currentTarget != null)
        {
            enemy = towerAtk.currentTarget;
            //enemy = towerAtk.enemyList[towerAtk.CurrentTargetIndexFunction(towerAtk.enemyList)];   it was using delegates

            enemyPos = enemy.transform.position;
            movementDirection = enemyPos.normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveInStraightLine();
    }

    void MoveInStraightLine()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }
}
