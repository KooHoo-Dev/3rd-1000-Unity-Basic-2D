using System;
using System.Collections.Generic;
using DG.Tweening;
using Study_OOP_And_Design_Pattern.Structural.Decorator;
using Study.MiniDefence;
using Study.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;
using Jay;

public class RailFollower : MonoBehaviour
{
    public MapData data;
    private List<Vector3> routePoints = new List<Vector3>();
    private int currentIndex = 0;

    public float speed;
    
    private void Start()
    {
        routePoints = data.GetWorldRoutePoints();
    }

    private void Update()
    {
        if (transform.IsSamePosition(routePoints[currentIndex], 0.1f))
        {
            currentIndex++;
            if(currentIndex >= routePoints.Count) currentIndex = 0; 
        }

        if (SimpleInput.GetKeyDown(Key.Space))
        {
            transform.DOMove(routePoints[currentIndex], 0.5f);
        }
        
    }
    
    
}