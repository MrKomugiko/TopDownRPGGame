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
    protected override void Start() {   // override -> nadpisanie funkcji od której sie dziedziczy (character)
        health.Initialize(initHealth, initHealth);  // przekazanie wartosci do klasy health ustawiajac ( aktualne zycie , maksymalne zycie )
        mana.Initialize(initMana, initMana);
        base.Start();                  //wywołanie elementow z funkcji start z klasy Character
    }
   protected override void Update() {   //
        GetInput();
        base.Update();
    }

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
        }
        if (Input.GetAxisRaw("Vertical") < 0) {
            direction += Vector2.down;
        }
        if (Input.GetAxisRaw("Horizontal") > 0) {
            direction += Vector2.right;
        }
        if (Input.GetAxisRaw("Horizontal") < 0) {
            direction += Vector2.left;
        }
    }
}

