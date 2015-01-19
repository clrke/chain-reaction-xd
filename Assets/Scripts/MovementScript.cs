using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	private int fireStrength = 0;
	private int sphereCount = 0;

	public GameObject sphereCopy;
	public int playerNumber;
	public Material playerColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0));

		if (Input.GetButton ("Jump")) {
			fireStrength++;
		}
		if (Input.GetButtonUp ("Jump")) 
		{
			GameObject newSphere = (GameObject)Instantiate(sphereCopy, transform.position, transform.rotation);

			newSphere.name = "Player " + playerNumber;
			newSphere.renderer.material = playerColor;

			Rigidbody rigidbody = newSphere.GetComponent<Rigidbody>();
			rigidbody.isKinematic = false;
			rigidbody.AddForce (transform.forward * (fireStrength * sphereCount + 500));

			print (fireStrength);
			fireStrength = 0;
			sphereCount++;
		}					
	}

	void OnGUI() 
	{
		GUI.Label (new Rect (0, 0, 200, 20), "Fire Strength: " + fireStrength);
	}
}
