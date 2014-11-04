using UnityEngine;
using System.Collections;

public class Player_Data : MonoBehaviour {


    public float maxHealth = 100.0f;
    public float health = 50.0f;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void GetDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, health);
    }


    public void Heal(float heal)
    {
        health = Mathf.Clamp(health + heal, heal, maxHealth);
    }


}
