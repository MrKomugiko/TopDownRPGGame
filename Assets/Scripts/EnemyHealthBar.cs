using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]
    GameObject enemyObject;
    Enemy enemy;
    Vector3 localScale;
    void Start()
    {
        enemy = enemyObject.GetComponent<Enemy>();
        
        localScale = transform.localScale;
    }
    void Update()
    {
        localScale.x = enemy.HealthAmout;
        transform.localScale = localScale;
    }
}
