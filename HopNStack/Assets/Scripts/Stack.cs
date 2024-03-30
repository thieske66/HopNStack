using CustomAttributes;
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
    public Vector2 SpeedRange = new Vector2(1f, 2f);

    [Button("SpawnNewBlock")]
    public bool DoSpawn = false;

    public GameObject BlockPrefab;
    public Vector2 HeightRange = new Vector2(0.2f, 0.5f);

    public void SpawnNewBlock()
    {
        if (Blocks.Count > 0)
        {
            Blocks[^1].Velocity = 0f;
        }

        // Spawn block
        GameObject blockObject = GameObject.Instantiate(BlockPrefab);
        Block block = blockObject.GetComponent<Block>();
        block.SetDimensions(GetDimensions());

        // Set position
        Vector2 spawnDirection = GetRandomDirection() * SpawnDistance;
        blockObject.transform.localPosition = new Vector3(spawnDirection.x, Height, spawnDirection.y);
        blockObject.transform.localRotation = Quaternion.LookRotation(new Vector3(spawnDirection.x, 0f, spawnDirection.y) * -1f, Vector3.up);

        // Set velocity
        block.Direction = new Vector3(spawnDirection.x, 0f, spawnDirection.y).normalized * -1f;
        block.Velocity = Random.Range(SpeedRange.x, SpeedRange.y);

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

        float height = Random.Range(HeightRange.x, HeightRange.y);

        return new Vector3(width, height, length);
    }



}
