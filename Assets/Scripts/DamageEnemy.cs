using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public TowerAttack towerAtk;
    public EnemyInfo enemy;
    private EnemyInfo enemyCollided;
    private AttackInfo unitStats ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = towerAtk.currentTarget;
        unitStats = this.gameObject.GetComponent<AttackInfo>();
        Destroy(this.gameObject, unitStats.attackLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        enemyCollided = collision.gameObject.GetComponent<EnemyInfo>();
        
        if (enemyCollided.unitHP >0)
        {
            enemyCollided.unitHP -= unitStats.attackDamage;

        }
        EnemyInfo enemy = collision.gameObject.GetComponent<EnemyInfo>();
        if (enemy.unitHP <= 0)
        {
            towerAtk.enemyList.Remove(enemy); //it is destroyed here cause sometimes Destroy() doesn't remove the object during same frame rather it is marked for deconstruction for next frame , this can cause null exception as we are trying to access a element which might not exist
            Destroy(enemy.gameObject);
            if(enemy = towerAtk.currentTarget)
            {
                towerAtk.currentTarget = null;
            }
        }
        
        Destroy(gameObject);


    }
}
