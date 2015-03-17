using UnityEngine;
using System.Collections;

/**************************************************
 * Pour que le script fonctionne il faut cree deux 
 * ground, associer ce script a chacun et les mettre 
 * un a la suite de l'autre
 **************************************************/

public class groundRepeater : MonoBehaviour {

	private Transform cameraTransform;
	private float spriteWidth;
	private Vector3 newPos;
	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;

		spriteWidth = GetComponent <BoxCollider2D>().size.x;
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		if ((transform.position.x+ + spriteWidth) < cameraTransform.position.x-10.5) {
			
			newPos = transform.position;
			newPos.x += 2.0f*spriteWidth;
			transform.position = newPos;
		}
	}
}
