using UnityEngine;
using System.Collections;

public class LaunchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.name != "Platform") {
			if(gameObject.name != c.gameObject.name) {
				if(c.gameObject.rigidbody.velocity.magnitude < gameObject.rigidbody.velocity.magnitude) {
					c.gameObject.name = gameObject.name;
					c.gameObject.renderer.material = gameObject.renderer.material;

					Vector3 centerOfExplosion =
						(c.gameObject.transform.position + gameObject.transform.position) / 2;

					c.gameObject.rigidbody.AddExplosionForce(100,centerOfExplosion,100);
					gameObject.rigidbody.AddExplosionForce(100,centerOfExplosion,100);
				}
			} else if(gameObject.name == c.gameObject.name) {
				Vector3 centerOfExplosion =
					(c.gameObject.transform.position + gameObject.transform.position) / 2;
				
				c.gameObject.rigidbody.AddExplosionForce(200,centerOfExplosion,100);
				gameObject.rigidbody.AddExplosionForce(200,centerOfExplosion,100);
			}
		}
	}
}
