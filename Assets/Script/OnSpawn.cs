using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelImporter;
using UnityEngine.Events;

public class OnSpawn : MonoBehaviour
{
    public VoxelObjectExplosion voe;
    public float duration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        voe.enabled = true;
        voe.ExplosionPlay(duration);
    }
}
