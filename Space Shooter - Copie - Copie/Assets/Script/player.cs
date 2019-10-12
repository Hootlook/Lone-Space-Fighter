using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
/*
	Rigidbody2D rb;
	public float h;
	public float v;
    [Range(0, 20)]
    public float speed = 10;
    private float padding = 1.2f;
    public GameObject go;

    void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            Instantiate(go);
        }

		h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
		v = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        float xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
		float xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

		float yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
		float yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

       //var x = Mathf.Clamp(transform.position.x + h, xMin, xMax);
       //var y = Mathf.Clamp(transform.position.y + v, yMin, yMax);
       
        // Rigidbody based movement
        
                        Vector2 move = new Vector2(speed * h, speed * v);

                        rb.AddForce(move);
        

        // Tranform affectation based movement


        transform.position += new Vector3(h * speed, v * speed);

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax));
	}

    */
}
