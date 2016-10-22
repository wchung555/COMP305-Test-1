using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    private GameController _controller;

	// Use this for initialization
	void Start () {
        this._controller = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            this._controller.DamageHull();
        }
    }
}
