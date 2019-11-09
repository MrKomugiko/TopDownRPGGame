using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Spell spell;
    private float spellDamage;
    [SerializeField]
    private float expPoints;
    private Player attacker;
    public float HealthAmout { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        expPoints = 50f;
        HealthAmout = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Attack")) {
            spell = collision.GetComponent<Spell>();
            attacker = spell.Caster;
            HealthAmout -= spell.Damage;

            if (HealthAmout <= 0) {
                Destroy(gameObject);
                attacker.ExpDistribution(expPoints);
            }
            Debug.Log("Otrzymano " + spell.Damage + " obrazen");
        }
    }



}
