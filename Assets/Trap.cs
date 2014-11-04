using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trap : MonoBehaviour
{

    public float damage = 0.0f;
    public float cooldown = 0.0f;
    public float resetTimer = 0.0f;



    public Dictionary<Collider, float> triggeredCollider = new Dictionary<Collider, float>();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (resetTimer > 0.0f) resetTimer -= (1 * Time.deltaTime);

    //    List<Collider> toDelete = new List<Collider>();
    //    foreach (Collider otherCollider in triggeredCollider.Keys)
    //    {
    //        triggeredCollider[otherCollider] -= 1.0f * Time.deltaTime;
    //        //if (triggeredCollider[otherCollider] <= 0) toDelete.Add(otherCollider);// triggeredCollider.Remove(otherCollider);
    //    }

        //foreach (Collider otherCollider in toDelete)
        //{
        //    triggeredCollider.Remove(otherCollider);
        //}

    }


    //void OnTriggerStay(Collider otherCollider)//
    void OnCollisionStay(Collision otherCollision)
    {
        Collider otherCollider = otherCollision.collider;
        Player_Data player_Data = otherCollider.GetComponent<Player_Data>();

        if (player_Data != null)
        {
            if (resetTimer <= 0.0f)
            {
                Animation animation = GetComponent<Animation>();
                //animation.wrapMode = WrapMode.Once;
                animation.Play();
                
                if (!triggeredCollider.ContainsKey(otherCollider)) triggeredCollider.Add(otherCollider, cooldown);
                else triggeredCollider[otherCollider] = cooldown;
                player_Data.GetDamage(damage);
                resetTimer = cooldown;
            }


        }

        if (!triggeredCollider.ContainsKey(otherCollider) || triggeredCollider[otherCollider] <= 0.0f)
        {

        }

    }

}
