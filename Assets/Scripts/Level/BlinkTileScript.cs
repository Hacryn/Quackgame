using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlinkTileScript : TileScript
{
    [Header("Blinking Behavior")]
    [SerializeField] private GameObject blinker;
    [SerializeField] private float interval;
    private Tilemap render;
    private float time;
    private bool state;

    public override void Start()
    {
        base.Start();

        render = blinker.GetComponent<Tilemap>();

        time = interval;
        state = true;
    }
    
    public virtual void Update()
    {
        time -= Time.deltaTime;
        
        if(time <= 1) {
            render.color = Color.red;
        }
        
        if (time <= 0) {
            state = !state;
            render.color = Color.white;
            blinker.SetActive(state);
            time = interval;
        }
    }
}
