// COMP305-Test-1 completed by Winnie Chung (300833637)

using UnityEngine;
using System.Collections;

// controls the interaction of the player game object with the enemy game objects
public class PlayerCollider : MonoBehaviour {

    private GameController _controller;

	// Use this for initialization
	void Start () {
        this._controller = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // destory the enemy game object and decrement the hull points
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            this._controller.DamageHull();
        }
    }
}
