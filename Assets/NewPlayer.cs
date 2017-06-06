using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //add the players
        int playerAmount = 5;
        for (int i = 0; i < playerAmount; i++)
        {
            //create a player
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //randomize start point
            int x = Random.Range(-10, 10);
            int y = 0;
            int z = Random.Range(-10, 10);
            player.transform.position = new Vector3(x, y, z);
            //increase the collider
            player.GetComponent<CapsuleCollider>().radius = 1.5F;
            //add components and name to identify
            player.name = "player" + i;
            player.AddComponent<MyMovement>();
            player.AddComponent<Rigidbody>();
        }
	}
}
