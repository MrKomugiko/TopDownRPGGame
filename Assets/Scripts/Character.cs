using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;
    protected Animator myAnimator;
    protected bool isAttacking = false;
    protected Vector2 direction;
    protected Coroutine attackRoutine;
    private Rigidbody2D myRigidbody;
    public bool isMoving {
        get {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected virtual void Start(){     // virtual pozwala na bycie przez siebie modyfikowanym przez klasy ją dziedzicaca?
        myAnimator = GetComponent<Animator>();    // przypisanie animajci do zmiennej
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update(){ //  odsiwzanie zwiekszone wzgledem mocy procesora >50
        HandleLayers();
    }
    private void FixedUpdate() { // stała predkosc odswiezania ~50fps
        Move(); // poruszanie sie 
    }
    public void Move() {    // poruszanie sie 
        myRigidbody.velocity = direction.normalized * speed;
       // przesuniecie sie obiektu(gracza/postaci/czegokolwiek) w wybranym kierunku i z okreslona szybnkoscia
    }

    public void HandleLayers() {
        if (isMoving) { // jezeli sie poruszy , wtedy wartwa z animacjami IDLE zostaje ukryta 
            ActivateLayer("WalkLayer");     // (index, weight) domyslnie warstwa 0 jest wyswietlana ( idle animacje ), 
                                            //      a podczas wykonania ruchu wartwie 1 ( gdzie sa animacje) przypisana zostaje weight 1,
                                            //      czyli wyswietla sie nad animacja idle (widac ja )


            // Animacje mają ustawione 2 zmienne float X i Y odpowiadające kierunkowi poruszania sie w osi X(-1,0,1) i Y(-1,0,1)
            myAnimator.SetFloat("x", direction.x);    // do zmiennej zostaje przypisana ta wartosc, nastepnie w unity logika przejscia miedzy animacjami sprawdza
            myAnimator.SetFloat("y", direction.y);    // czy x jest wieksze od 1, czy mniejsze, itp i ktora animacje ma wysiwtlic w ktorym momecie, bazujac na wartowsciach XiY

            StopAttack();
        }
        else if (isAttacking) {
            ActivateLayer("AttackLayer");
        } else {
            ActivateLayer("IdleLayer");
        }
    }
    //żeby animacja byłą widoczna, nalezy wczesniej wyłączyć wczesniejsze warstwy ( idle,bieg,atak,itp) i włączyć wybraną
    public void ActivateLayer(string layerName) {
        for (int i = 0; i < myAnimator.layerCount; i++) {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
    }

    public void StopAttack() {
        if(attackRoutine != null) {
            StopCoroutine(attackRoutine);
            isAttacking = false;
            myAnimator.SetBool("attack", isAttacking)  ;
        }
    }



}
