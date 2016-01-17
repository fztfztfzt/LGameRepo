using UnityEngine;
using System.Collections;

public class animtest : MonoBehaviour {

    private Animator anim = null;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.R))
        {
            anim.SetFloat("Speed", 0.02f);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetFloat("Speed", 0.0f);
        }
	}
}
