using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawBerryPlant : MonoBehaviour
{

    public Sprite[] sprites;
    public float growthCycle;

    private SpriteRenderer spriteRender;
    private int curSprite;
    private bool isFullyGrown;

    // Use this for initialization
    void Start()
    {
        spriteRender = this.GetComponent<SpriteRenderer>();
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        curSprite = 0;
        isFullyGrown = false;
        while (true)
        {
            spriteRender.sprite = sprites[curSprite];
            curSprite++;
            if (curSprite >= sprites.Length)
                break;
            yield return new WaitForSeconds(growthCycle);
        }
        isFullyGrown = true;
    }

    public bool IsReadyForHarvest()
    {
        return isFullyGrown;
    }

    public bool Harvest(Player player)
    {
        if(player != null && IsReadyForHarvest())
        {
            player.GiveItem("Strawberry");
            return true;
        }
        return false;
    }
}
