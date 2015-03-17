using UnityEngine;
using System.Collections;

public class dieScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "killYou")
			Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
