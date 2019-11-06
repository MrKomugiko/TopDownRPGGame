using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //private GameObject enemy;
    //protected Vector2 direction;
    //private Transform target;
    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime; // długość życia -> kiedy znika
    public float Damage = 0.4f;
    private Vector2 kierunekLotu;
    public Vector2 Direction { get {
            return kierunekLotu;
        } set {
            kierunekLotu = value; } }
    [SerializeField]
    private float ManaCost;
    private bool hitTarget;

    public float getManaCost() {
        return ManaCost;
    }
    public void SetManaCost(float value) {
        ManaCost = value;
    }
    public float GetDurrationTime() {
        return lifeTime;
    }
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
       // target = GameObject.Find("Target").transform;
    }
    void Update()
    {
        Vector2 direction = transform.position;
    }
    private void FixedUpdate() {
        Vector2 direction = kierunekLotu;
        myRigidBody.velocity = direction.normalized * speed;

        if (!hitTarget) {
            Destroy(myRigidBody.gameObject, lifeTime);
        }
        //
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("enemy")) {
            hitTarget = true;
            Destroy(myRigidBody.gameObject);
        }
    }
}
