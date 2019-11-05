using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float speed;
    protected Vector2 direction;
    private Transform target;
    [SerializeField]
    private float lifeTime; // długość życia -> kiedy znika
    public float Damage = 0.4f;

    public Vector2 Direction { get {
            return kierunekLotu;
        } set {
            kierunekLotu = value; } }
    private Vector2 kierunekLotu;
    // Start is called before the first frame update
    [SerializeField]
    private float ManaCost;

    public float getManaCost() {
       // Debug.Log("Pobranie wartosci getManaCost -> " + ManaCost);
        return ManaCost;
    }
    public void SetManaCost(float value) {
        ManaCost = value;
       // Debug.Log("Wykonanie SetManaCost -> zmiana wartosci ManaCost na " + value);
    }


    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        //for testing hardcode target
       // target = GameObject.Find("Target").transform;
    }

    void Update()
    {
        //DEBUG
       // Debug.Log("SKILL: aktualny koszt many to [" + ManaCost + "]");

        Vector2 direction = transform.position;
    }
    private bool hitTarget;
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
