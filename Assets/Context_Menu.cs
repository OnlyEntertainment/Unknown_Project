using UnityEngine;
using System.Collections;

public class Context_Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void DeactivateMe()
    {
        this.gameObject.SetActive(false);
    }
}
