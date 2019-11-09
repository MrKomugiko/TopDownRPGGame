using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

    private Image content;
    [SerializeField]
    private Text statValue;
    private float currentFill;
    private float currentValue;
    [SerializeField]
    private float lerpSpeed; // prędkość uzupełniania
    private string characterType; // player lub enemy
    public float MyMaxValue {
        get;
        set;
    }
    public float MyCurrentValue {       //zmienna MyCurrentValue, jezeli coś ma zostać do niej przypisane, zostaje najpierw przepuszczone przez SETter,
                                        //  w ktorym sprawdzane jest czy TA wartość (VALUE) jest mniejsza niż Maksymalna wartosc, 
                                        //  oraz czy nie jest od niej mniejsza i czy jest rowna aktualnej wartosci
                                        //  wówczas MyCurrentValue przypisze do zmiennej prywatnej current fill wartość...
        get {
            return currentValue;
        }
        set {
            if (value > MyMaxValue) {
                currentValue = MyMaxValue;
            } else if (value < 0) {
                currentValue = 0;
            } else currentValue = value;
            currentFill = currentValue / MyMaxValue;    // uzyskanie wartości uzupełnienia w przedziale (0.0;1.0)

            statValue.text = currentValue + " / " + MyMaxValue;

        }
    }
    void Start() {

            content = GetComponent<Image>(); // przypisanie obrazku do zmiennej conten
    }
    void Update() {
            if(currentFill != content.fillAmount) { // sprawdzenie czy zmienna currentFill różni się od poziomu napełnienia w obrazku
                content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);   // zmiana poziomu napelnienia w obrazku w czasie ( ładowanie sie paska zamiast natychmiastowego zaniku )
            }
    }
    public void Initialize(float currentValue, float maxValue) { // funkcja inicjalizująca przypisująca wartości aktualnego wypełnienia i maksymalnego mozliwego wypelnienia
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
      //  Debug.Log(content.name + " zaostał zainicjalizowany pomyślnie.");
    } 
}

