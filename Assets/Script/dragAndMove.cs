
using UnityEngine;
using System.Collections;

public class dragAndMove : MonoBehaviour
{
    public bool XAxisIsActive;
    public bool YAxisIsActive;
    public SpringJoint2D springJoint;
    public AudioSource movingAudio;
    public AudioSource collisionAudio;

    private Vector3 blocDirection;
    private Vector3 currentPosition;
    private float magicIsActive;

    // Use this for initialization
    void Start()
    {
        XAxisIsActive = true;
        YAxisIsActive = true;
        magicIsActive = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().state;
    }

    // Update is called once per frame
    void Update()
    {
        magicIsActive = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().state;
    }


    // OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse (Since v1.0)
    public void OnMouseDrag()
    {
        //SI le pouvoir n'est pas activé ALORS, ne fait rien.
        if (magicIsActive != 3)
            return;


        if (currentPosition != transform.position && !movingAudio.isPlaying)
        {
            movingAudio.Play();
        }
 
        currentPosition = transform.position;

        //scale la souris à l'écran du jeux et crée un vecteur du bloc jusqu'a la souris
        blocDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        blocDirection -= currentPosition;

        //enleve l'axe des z qui aurait pu être produit par la souris.
        blocDirection.z = 0;

        //désactive le déplacement dans l'axe des x et/ou y.
        if(!XAxisIsActive) blocDirection.x = 0;
        if(!YAxisIsActive) blocDirection.y = 0;

        //déplace le joint du "springJoint" du bloc vers le vecteur voulue (position de la souris).
        //Cela aura pour effet de déplacer le bloc vers le joint juste à temp qu'ils soyent côte à côte.
        //Imaginé que le bloc soit accrocher à un resort et que la souris déplace l'autre extremité de resort.
        springJoint.connectedAnchor = currentPosition+blocDirection;
    }

    public void OnMouseUp()
    {
        movingAudio.Stop();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            return;

        collisionAudio.Play();
    }

    

}
