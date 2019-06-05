using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_script : MonoBehaviour
{

    public int hitsToBreake;
    public Sprite hitSprite;
    public void BreakBrick () {

        hitsToBreake --;
        GetComponent<SpriteRenderer>().sprite = hitSprite;


    }
}
