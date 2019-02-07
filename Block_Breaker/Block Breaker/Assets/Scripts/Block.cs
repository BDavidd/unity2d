﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private int maxHits;

    // cached reference
    private Level level;
    private GameSession gameSession;

    [SerializeField] private int timesHit = 0;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();

        if (tag == "BreakableBlock")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "BreakableBlock")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        ++timesHit;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        TriggerSparklesVFX();

        gameSession.AddToScore();
        level.OnBlockDestroyed();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1);
    }
}
