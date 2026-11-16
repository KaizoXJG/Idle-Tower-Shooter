using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public int towerHealth = 100;
    public bool isGameOver = false;
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
