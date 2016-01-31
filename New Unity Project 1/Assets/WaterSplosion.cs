using UnityEngine;
using System.Collections;

public class WaterSplosion : MonoBehaviour {

    float life = 0f;
    float damage = 2.5f;
    public float damageModifier = 1f;
    Color colour = Color.blue;
    Collider2D collider;
    GameObject Player;

	// Use this for initialization
	void Start () {
        colour.a = 0;
        collider = GetComponent<Collider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = colour;
        colour.a =  life/3;
        life += Time.deltaTime;
        if (life >= 3)
        {
            if (collider.IsTouching(Player.GetComponent<Collider2D>())){
                Player.GetComponent<PlayerScript>().TakeDamage(damage * damageModifier);
            }
            Destroy(gameObject);
        }
	
	}
}
