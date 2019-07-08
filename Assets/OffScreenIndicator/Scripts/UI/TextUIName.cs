using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUIName : MonoBehaviour {
    [SerializeField]
    private Text name;
    //[SerializeField]
    //private Text Distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetName(GameObject tgt)
    {
        //name = this.
        name.text = tgt.name;
    }
}
