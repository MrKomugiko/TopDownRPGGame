using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;
    protected Vector2 direction;

    protected virtual void Start(){     // virtual pozwala na bycie przez siebie modyfikowanym przez klasy ją dziedzicaca?
        animator = GetComponent<Animator>();    // przypisanie animajci do zmiennej
    }

    protected virtual void Update(){
        Move(); // poruszanie sie 
    }

    public void Move() {    // poruszanie sie 
        transform.Translate(direction * speed * Time.deltaTime); // przesuniecie sie obiektu(gracza/postaci/czegokolwiek) w wybranym kierunku i z okreslona szybnkoscia
        if(direction.x !=0 || direction.y != 0) { // jezeli sie poruszy , wtedy wartwa z animacjami IDLE zostaje ukryta 
        AnimateMovement(direction);
        } else {
            animator.SetLayerWeight(1, 0);
        }
    }

    public void AnimateMovement(Vector2 direction) {    // przełaczanie się miedzy animacja biegu a stanem idle

        animator.SetLayerWeight(1, 1);      // (index, weight) domyslnie warstwa 0 jest wyswietlana ( idle animacje ), 
                                            //      a podczas wykonania ruchu wartwie 1 ( gdzie sa animacje) przypisana zostaje weight 1,
                                            //      czyli wyswietla sie nad animacja idle (widac ja )


        // Animacje mają ustawione 2 zmienne float X i Y odpowiadające kierunkowi poruszania sie w osi X(-1,0,1) i Y(-1,0,1)
        animator.SetFloat("x", direction.x);    // do zmiennej zostaje przypisana ta wartosc, nastepnie w unity logika przejscia miedzy animacjami sprawdza
        animator.SetFloat("y", direction.y);    // czy x jest wieksze od 1, czy mniejsze, itp i ktora animacje ma wysiwtlic w ktorym momecie, bazujac na wartowsciach XiY
    }





}
