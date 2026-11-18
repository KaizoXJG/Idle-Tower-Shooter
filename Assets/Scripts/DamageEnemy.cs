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
        Destroy(gameObject);


    }
}
