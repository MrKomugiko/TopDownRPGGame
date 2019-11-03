using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {
    private Image content;
    private float currentFill;
    private float currentValue;
    [SerializeField]
    private float lerpSpeed;
    public float MyMaxValue { get; set; }
    public float MyCurrentValue {
        get {
            return currentValue;
        }
        set {
            if (value > MyMaxValue) {
                currentValue = MyMaxValue;
            } else if (value < 0) {
                currentValue = 0;
            } else currentValue = value;
            currentFill = currentValue / MyMaxValue;
        }
    }

    void Start() {
        content = GetComponent<Image>();
    }

    void Update() {
        if(currentFill != content.fillAmount) {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
        //content.fillAmount = currentFill;
    }

    public void Initialize(float currentValue, float maxValue) {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}

