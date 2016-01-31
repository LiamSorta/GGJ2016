using UnityEngine;
using System.Collections;

public class WaterBoss : MonoBehaviour {

    public GameObject waterSplosion;
    private float health = 50f;
    public float armourModifier = 1f;
    float i = 0;
    Vector3 center;
    float timer = -50f;
    float delay = .4f;
    public bool Play = false;
    bool setup = false;



    // Update is called once per frame
    void Update () {
        if (Play)
        {
            if (!setup)
            {
                center = transform.position;
                setup = true;
            }
            if (delay + timer < Time.time)
            {
                Vector3 pos = RandomCircle(center, 1.0f, i * 30f);
                Rigidbody2D Rock = Instantiate(waterSplosion, pos, Quaternion.identity) as Rigidbody2D;
                i++;
                timer = Time.time;
                Vector3 pos2 = new Vector2(Random.Range(-6 + transform.position.x, 6 + transform.position.x), Random.Range(-4 + transform.position.y, 4 + transform.position.y));
                Instantiate(waterSplosion, pos2, Quaternion.identity);
            }
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius, float a)
    {

        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    public void TakeDamage(float damage)
    {
        health -= damage * armourModifier;
    }
}
