using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float _damageModifier = 5;
    private float _speedModifier = 100;
    private float _armourModifier = 100;
    private float _hpRegenModifier = 5;

    public bool freezeControls; //For Liam, cos he's weird

    private float _health;

    public float damageModifier { get { return _damageModifier; } set { _damageModifier = value; } }
    public float speedModifier { get { return _speedModifier; } set { _speedModifier = value; } }
    public float armourModifier { get { return _armourModifier; } set { _armourModifier = value; } }
    public float hpRegenModifier { get { return _hpRegenModifier; } set { _hpRegenModifier = value; } }

    public float health { get { return _health; } }

    Rigidbody2D rigidbody;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        HpRegen();
        Movement();
	}

    private void HpRegen()
    {
        _health += hpRegenModifier * Time.deltaTime;
    }

    private void Movement()
    {
        if (!freezeControls) //When freezeControls is true do not allow controls
        {
            rigidbody.velocity = Vector2.zero;
            Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal") * speedModifier * Time.deltaTime, Input.GetAxisRaw("Vertical") * speedModifier * Time.deltaTime);
            rigidbody.velocity = movement;
        }
    }


}
