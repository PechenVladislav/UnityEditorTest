using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSpriteTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            rend.FadeSprite(this, 3f, (SpriteRenderer r) => { Destroy(r.gameObject); });
        }
	}
}
