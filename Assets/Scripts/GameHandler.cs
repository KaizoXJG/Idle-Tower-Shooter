using System;
using TMPro;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] TMP_Text towerHealthUI;
    public GameObject tower;
    public TowerStats tStats;
    public GameObject GameOverPanel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tStats = tower.GetComponent<TowerStats>();
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        towerHealthUI.text = "HP : " + tStats.towerHealth.ToString();
        if (tStats.isGameOver)
        {
            GameOverPanel.SetActive(true);
        }
    }
}
