using System;
using Study_OOP_And_Design_Pattern.Structural.Decorator;
using Study.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoffeeDemo : MonoBehaviour
{
    ICoffee coffee = new Espresso();
    
    private void Start()
    {
        coffee.Price(); // 3000원
        coffee.Description(); // 에스프레소
            
        Debug.Log($"[Coffee] 가격 : {coffee.Price()}, {coffee.Description()}");
    }

    private void Update()
    {
        if (SimpleInput.GetKeyDown(Key.Digit1))
        {
            coffee = new Milk(coffee);
            Debug.Log($"[Coffee] 가격 : {coffee.Price()}, {coffee.Description()}");
        }
        
        if (SimpleInput.GetKeyDown(Key.Digit2))
        {
            coffee = new Shot(coffee);
            Debug.Log($"[Coffee] 가격 : {coffee.Price()}, {coffee.Description()}");
        }
        
        if (SimpleInput.GetKeyDown(Key.Digit3))
        {
            coffee = new Ice(coffee);
            Debug.Log($"[Coffee] 가격 : {coffee.Price()}, {coffee.Description()}");
        }
    }
}