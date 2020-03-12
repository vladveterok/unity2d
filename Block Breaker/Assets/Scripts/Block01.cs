using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block01 : MonoBehaviour
{
  // Config parameters
  [SerializeField] AudioClip blockDestroingAudioClip;
  [SerializeField] GameObject blockSparklesVFX;
  [SerializeField] Sprite[] hitSprites;

  // Cached references
  Level level;
  GameStatus gameStatus;

  // State variables
  [SerializeField] int timesIsHit;  // Serialized for Debug
  [NonSerialized] public int maxHits;

    private void Start()
    {
        CountBreakable();
        gameStatus = FindObjectOfType<GameStatus>();
        maxHits = hitSprites.Length+1;
    }

    private void CountBreakable()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DoHit();
        }
    }

    private void DoHit()
    {
        timesIsHit++;
        if (timesIsHit >= maxHits)
        {
            DestroyBlock();
        } else ShowNextHitSprite();
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesIsHit-1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            } else Debug.LogError("Block sprite is missing from array of " + this /*can use gameObject.name insted of 'this'*/); //check if sprite assigned in array
    }

    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(blockDestroingAudioClip, Camera.main.transform.position, 0.7f);
        Destroy(gameObject);
        level.DeductIfDestroid();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
