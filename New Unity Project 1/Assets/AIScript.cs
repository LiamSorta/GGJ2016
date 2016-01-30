using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

    
    private SpriteRenderer rend;
    public Transform target;
    
    private int rotationSpeed;

    private float dmg = 3;    
    private float moveSpeed = 3;
    private float health = 100;
    private Color Colour;
    private float attackSpeed = 0.5f;

    public float dmgMod;
    public float attackSpeedMod;
    public float armourMod;
    public float moveSpeedMod;

    float distance;
    float a;
    float Z;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;

        rend = GetComponent<SpriteRenderer>();
        rend.enabled = true;
 
    }	

	void Update () 
    {
        //SetStats();
        
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > 3)
        {

            rend.enabled = false;
            
            a += Time.deltaTime;

            if (a > 3)
            {
                Vector2 move;
                int X = Random.Range(1, 5);

                switch (X)
                {
                    case 1:
                        move = new Vector2(1, 0);
                        break;
                    case 2:
                        move = new Vector2(0, 1);
                        break;
                    case 3:
                        move = new Vector2(-1, 0);
                        break;
                    case 4:
                        move = new Vector2(0, -1);
                        break;
                    default:
                        move = new Vector2(0, 0);
                        break;

                }

                transform.Translate(move);
                a = 0; 
            }
            
        }
        else
        {
            
            rend.enabled = true;
            Quaternion Enemyrot = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
            transform.rotation = Enemyrot;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
            transform.position = Vector2.MoveTowards(transform.position, target.position,(moveSpeed * moveSpeedMod)*Time.deltaTime);
            //transform.position += (target.position - transform.position).normalized * (moveSpeed*moveSpeedMod) * Time.deltaTime;           
        }

	}

    public void TakeDamage(float damage)
    {
        health = health - (damage * armourMod); 
    }
    
    public void SetStats(float idmgMod, float iattackSpeedMod, float iarmourMod, float imoveSpeedMod, Color icolour)    
    {
        dmgMod =  idmgMod;
        attackSpeedMod = iattackSpeedMod;
        armourMod = iarmourMod;
        moveSpeedMod =  imoveSpeedMod;
        Colour = icolour; 
    }

    void OnTriggerStay2D(Collider2D Elemental) 
    {
        if (Elemental.gameObject.tag == "Player")
        {
            
            Z += Time.deltaTime;            
            if (Z > attackSpeed*attackSpeedMod)
            {
                GetComponent<PlayerScript>().TakeDamage(dmg * dmgMod);
            }
        }
    }
}
