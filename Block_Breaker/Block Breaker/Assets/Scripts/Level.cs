using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        ++breakableBlocks;
    }

    public void OnBlockBroken()
    {
        --breakableBlocks;
        if (breakableBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
