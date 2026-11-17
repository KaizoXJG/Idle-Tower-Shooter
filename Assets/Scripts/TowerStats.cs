using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public int towerHealth = 100;
    public bool isGameOver = false;
    public float towerRange = 3f;
    public float towerDamage = 10f;
    public float towerAttackSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (towerHealth <= 0)
        {
            isGameOver = true;
        }
    }
}
