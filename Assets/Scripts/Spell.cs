using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float speed;
    protected Vector2 direction;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        //for testing hardcode target
        target = GameObject.Find("Target").transform;
    }

    void Update()
    {
        Vector2 direction = transform.position;
    }

    private void FixedUpdate() {
        Vector2 direction = target.position - transform.position;
        myRigidBody.velocity = direction.normalized * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
