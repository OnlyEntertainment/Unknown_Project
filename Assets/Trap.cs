using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{

    public float Damage = 0.0f;
    public Collider[] triggered


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay(Collider otherCollider)
    {
        Player_Data player_Data = otherCollider.GetComponent<Player_Data>();
        if (player_Data != null)
        {
            player_Data.GetDamage(10);
        }

    }

}
