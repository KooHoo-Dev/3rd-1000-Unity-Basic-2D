using System;
using Study_OOP_And_Design_Pattern.Structural.Decorator;
using Study.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoffeeDemo : MonoBehaviour
{
    public Vector2 Origin;
    public float CellSize;

    public Vector2Int inputIndex;
    
    private void Update()
    {
        if (SimpleInput.GetKeyDown(Key.Space))
        {
            var result = CellToWorld(inputIndex);
            Debug.Log(result);
        }
    }

    public Vector3 CellToWorld(Vector2Int cellIndex)
    {
        // 0.5f = 월드 좌표 중앙 보정값
        float x = Origin.x + (cellIndex.x + 0.5f) * CellSize;
        float y = Origin.y + (cellIndex.y + 0.5f)* CellSize;
            
        return new Vector3(x, y, 0);
    }
}