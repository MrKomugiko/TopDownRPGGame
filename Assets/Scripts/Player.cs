using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected override void Start() {
        base.Start();
    }

   protected override void Update() {
        GetInput();
        base.Update();
    }

    private void GetInput() {
        direction = Vector2.zero;
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

