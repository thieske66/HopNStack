using CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public List<Block> Blocks = new List<Block>();
    public float Height
    {
        get
        {
            float totalHeight = 0f;
            Blocks.ForEach(block => totalHeight += block.Dimensions.y);
            return totalHeight;
        }
    }

    public float SpawnDistance = 5f;

    [Button("SpawnNewBlock")]
    public bool DoSpawn = false;


    public void SpawnNewBlock()
    {
        if (Blocks.Count > 0)
        {
            // stop current block
        }

        // Spawn block
        GameObject blockObject = new GameObject();
        Block block = blockObject.AddComponent<Block>();
        block.SetDimensions(GetDimensions());

        // Set position
        Vector2 spawnDirection = GetRandomDirection() * SpawnDistance;
        blockObject.transform.localPosition = new Vector3(spawnDirection.x, Height, spawnDirection.y);
        blockObject.transform.localRotation = Quaternion.LookRotation(new Vector3(spawnDirection.x, 0f, spawnDirection.y) * -1f, Vector3.up);

        // Set velocity


        Blocks.Add(block);
    }


    public Vector2 GetRandomDirection()
    {
        int random = Random.Range(1, 5);
        switch (random)
        {
            case 1: return Vector2.left;
            case 2: return Vector2.right;
            case 3: return Vector2.up;
            case 4: return Vector3.down;
            default: throw new System.Exception("Unhandled direction");
        }
    }

    public Vector3 GetDimensions()
    {
        int stackCount = Blocks.Count;
        int maxStackScale = 20;

        float startWidth = 3f;
        float minWidth = 1f;
        float width = Mathf.Max(startWidth - (2 * (float)stackCount / (float)maxStackScale), minWidth);

        float startLength = 3f;
        float minLength = 1f;
        float length = Mathf.Max(startLength - (2 * (float)stackCount / (float)maxStackScale), minLength);

        Vector2 heightRange = new Vector2(0.5f, 1f);
        float height = Random.Range(heightRange.x, heightRange.y);

        return new Vector3(width, height, length);
    }



}
