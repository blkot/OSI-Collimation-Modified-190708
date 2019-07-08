using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUIDistance : MonoBehaviour {
    [SerializeField]
    private Text distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateDistanceUI(float dis)
    {
        distance.text = dis.ToString();
    }
}
