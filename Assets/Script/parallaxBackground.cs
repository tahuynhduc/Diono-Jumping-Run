using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour
{
    public float speedView;

    private Renderer renderer;

   
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Repeat(Time.time* speedView, 1);
        Vector2 savedOffset = new Vector2(x,0);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
