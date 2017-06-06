using UnityEngine;
using System.Collections;
using System;

public class MyMovement : MonoBehaviour {
    // my properties
    Vector3 endPosition = new Vector3();
    float speed = 0.5F;

    // Collider properties
    bool amColliding = false;
    GameObject collidingWith;

    // Use this for initialization
    void Start () {
        // set destination
        int x = UnityEngine.Random.Range(-10, 10);
        int y = 0;
        int z = UnityEngine.Random.Range(-10, 10);
        endPosition = new Vector3(x, y, z);

        Debug.Log(
            "My name is: " + gameObject.name  + 
            ". My starting position is: " + gameObject.transform.position + 
            ". My destination is: " + endPosition + 
            ". My radius is: " + gameObject.GetComponent<CapsuleCollider>().radius + 
            ". My speed is: " + speed);
    }

    // Update is called once per frame
    void Update () {
        // get movespeed from speed
        float moveSpeed = Time.deltaTime * speed;

        // if colliding orbit around the colliding object
        if (amColliding == true)
        {
            Vector3 relativePos = (collidingWith.transform.position + new Vector3(0, 0, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            Quaternion current = transform.localRotation;
            transform.localRotation = Quaternion.Slerp(current, rotation, moveSpeed);
            transform.Translate(0, 0, 3 * moveSpeed);
        }
        else
        {
            // go towards destination
            gameObject.transform.position = Vector3.Lerp(transform.position, endPosition, moveSpeed);
        }
    }

    //collision checker
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Contact is made!");
        amColliding = true;
        collidingWith = collision.gameObject;

        // set collision false
        StartCoroutine(SetCollidingFalse());
    }

    private IEnumerator SetCollidingFalse()
    {
        // yield for x seconds after collision
        yield return new WaitForSeconds(1);
        amColliding = false;
    }
}
