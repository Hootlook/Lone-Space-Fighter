using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float health;
	public GameObject hasDamage;
   // public GameObject slider;

    private void Start()
    {
       // slider = GameObject.Find("Slider");
    }

    private void Update()
	{

			if (health <= 0)
			{
				if (gameObject.tag != "Player")
				{
				Destroy(gameObject);
				}
			}
	
      //  slider.GetComponent<Slider>().value = health;

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag != "Untagged")
		hasDamage.GetComponent<DamageIndicator>().hit = 0;
	}
}
