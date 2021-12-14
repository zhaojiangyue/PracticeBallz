using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    
    [SerializeField]
    public Block blockPrefab;//test
    
    private int playWidth = 8;
    private float distanceBetweenBlock = 0.7f;
    private int rowsSpawned;

    private List<Block> blockSpawned = new List<Block>(); 


    private void OnEnable()
    {
        // for (int i = 0; i < 3; i++)
        // {
            SpawnRowOfBlocks();
        // }
    }

    public void SpawnRowOfBlocks()
    {
        foreach (var block in blockSpawned)
        {
            if (block!=null)
            {
                block.transform.position += Vector3.down * distanceBetweenBlock;
            }
        }
        
        for (int i = 0; i < playWidth; i++)
        {
            
            if (UnityEngine.Random.Range(0, 100) <= 70)
            {
                var block = Instantiate(blockPrefab, GetPosition(i), quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 3) + rowsSpawned;
                block.SetHits(hits);
                blockSpawned.Add(block);
            }
        }

        rowsSpawned++;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        
        position += Vector3.right * i * distanceBetweenBlock;
        return position;
    }
    
}
