using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {


    [Header("Variables")]
    public float speed;
	public float velocity;
    public bool isDisabled;

    [Header("Acteurs")]
    public GameObject boulders;
    public GameObject shipRotation;
	public GameObject fixedRot;
    public Transform t;
	public GameObject ps;

	public Vector3 startPos;

    private void Awake()
    {
        shipRotation = GameObject.FindWithTag("Player");
    }

    private void Start()
	{
		startPos = transform.position;
		transform.localScale *= Random.Range(1, 3);
		speed = Random.Range(-1, 1);
	}

	private void Update()
	{

		if (gameObject.tag == "Asteroid")
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward * shipRotation.transform.rotation.eulerAngles.z),1);
			t.localRotation *= Quaternion.Euler(Vector2.left + Vector2.up * speed);
			transform.Translate(-Vector3.forward * velocity * Time.deltaTime);
		}

		if(gameObject.tag == "Boulder")
		{
			speed = -1;
			transform.localRotation *= Quaternion.Euler(Vector2.left + Vector2.up * speed * 10);
			transform.Translate(Vector2.down * (velocity*10) * Time.deltaTime);
			Destroy(gameObject, 20);
		}

		if (fixedRot == null) return;
		fixedRot.transform.rotation = Quaternion.Euler(Vector3.zero);
	}

	private void OnDestroy()
	{

		if (gameObject.tag == "Boulder") return;

		else
        {
			Instantiate(boulders, transform.position, Quaternion.Euler(new Vector3(10, 90, 130))).transform.localScale = new Vector3(2, 2, 2);
            Instantiate(boulders, transform.position, Quaternion.Euler(new Vector3(20, 80, 100))).transform.localScale = new Vector3(1, 1, 1);
            Instantiate(boulders, transform.position, Quaternion.Euler(new Vector3(30, 70, 200))).transform.localScale = new Vector3(3, 3, 3);
            Instantiate(boulders, transform.position, Quaternion.Euler(new Vector3(40, 60, 300))).transform.localScale = new Vector3(3, 3, 3);
            Instantiate(boulders, transform.position, Quaternion.Euler(new Vector3(50, 50, 10))).transform.localScale = new Vector3(4, 4, 4);
            Instantiate(boulders, transform.position, Quaternion.Euler(new Vector3(60, 40, 20))).transform.localScale = new Vector3(1, 1, 1);
            Instantiate(boulders, transform.position, Quaternion.Euler(new Vector3(70, 30, 30))).transform.localScale = new Vector3(1, 1, 1);
            Instantiate(boulders, transform.position, Quaternion.Euler(new Vector3(80, 50, 55))).transform.localScale = new Vector3(2, 2, 2);
        }
           
		
		
	}

}
