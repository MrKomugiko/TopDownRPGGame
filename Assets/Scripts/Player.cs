using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Stat health;                // Polaczenie paska zycia 
    private float initHealth = 100;     // Na sztywno przypisanie maksymalnej wartosci zycia
    [SerializeField]
    private Stat mana;
    private float initMana = 200;

    [SerializeField]
    private GameObject[] spellPrefab;
    private Transform target;
    protected override void Start() {   // override -> nadpisanie funkcji od której sie dziedziczy (character)
        health.Initialize(initHealth, initHealth);  // przekazanie wartosci do klasy health ustawiajac ( aktualne zycie , maksymalne zycie )
        mana.Initialize(initMana, initMana);
        //for testing hardcode target
        //target = GameObject.Find("Target").transform;

        base.Start();                  //wywołanie elementow z funkcji start z klasy Character
  }
   protected override void Update() {   //
        GetInput();

        InLineOfSight();

        base.Update();
    }
    Vector2 lastDir;
    private void GetInput() {
        direction = Vector2.zero;

                    //SPRAWDZENIE CZY PASKI HP DZIALAJA POPRAWNIE
                    if (Input.GetKeyDown(KeyCode.I)) {
                        health.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 50;
                    }
                    if (Input.GetKeyDown(KeyCode.O)) {
                        health.MyCurrentValue += 10;
                        mana.MyCurrentValue += 50;
                    }

        if (Input.GetAxisRaw("Vertical") > 0) {
            direction += Vector2.up;
            lastDir = Vector2.up;
        }
        if (Input.GetAxisRaw("Vertical") < 0) {
            direction += Vector2.down;
            lastDir = Vector2.down;
        }
        if (Input.GetAxisRaw("Horizontal") > 0) {
            direction += Vector2.right;
            lastDir = Vector2.right;
        }
        if (Input.GetAxisRaw("Horizontal") < 0) {
            direction += Vector2.left;
            lastDir = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!isAttacking && !isMoving) { // jezeli nie atakujemy i nie ruszamy sie mozemy castowac zaklecie
                attackRoutine = StartCoroutine(Attack());
            }
        }
    }
    private IEnumerator Attack() {
        if(CheckIfSpellCanBeCasted(mana, 3)) {
            isAttacking = true;
            myAnimator.SetBool("attack", isAttacking);
            yield return new WaitForSeconds(0.1f); // hardcoded cast time for debugging purpose
            CastSpell(mana, 3);
            StopAttack();
        }
    }
    private GameObject spell;
    public bool CheckIfSpellCanBeCasted(Stat mana, int skillIndex) {
        spell = spellPrefab[skillIndex];
        Spell mySpell = spell.GetComponent<Spell>();
        if ((mana.MyCurrentValue - mySpell.getManaCost()) < 0) {
            return false;
        } else
            return true;
    }
    public void CastSpell(Stat mana, int skillIndex) {

        spell = Instantiate(spellPrefab[skillIndex], transform.position, Quaternion.identity);
        Spell mySpell = spell.GetComponent<Spell>();
        mySpell.Direction = lastDir;
       // ustawianie na sztywno many skilla - wszystkich skilów w tym przypadku
       // TODO: automat, i przypisanie wybrnaemu indeksowi skila basic manycostu
       // mySpell.SetManaCost(66.0f);
        mana.MyCurrentValue -= mySpell.getManaCost();
    }

    private bool InLineOfSight() {

      //  Vector3 targetDirection = (target.transform.position - transform.position).normalized;
      //  Debug.DrawRay(transform.position, targetDirection, Color.red);

        return false;
    }

}

