using Study_OOP_And_Design_Pattern.Structural.Decorator;
using UnityEngine;

public class StatBuffDemo : MonoBehaviour
{
    private void Start()
    {
        Stat baseStat = new Stat(10,100,1);
        DecoHandler handler = new DecoHandler(baseStat);
        
        handler.Add(new AttackBoost());
        handler.Add(new AttackBoost());
        IStat added = handler.GetAdded();
        Debug.Log($"[Added_1] {added.Attack},  {added.Hp}, {added.Speed}");
        //====================
        handler.Add(new HpBoost());
        handler.Add(new HpBoost());
        added = handler.GetAdded();
        Debug.Log($"[Added_2] {added.Attack},  {added.Hp}, {added.Speed}");
        //====================
        handler.Remove(typeof(AttackBoost)); // 10 -> 5로 감소
        added = handler.GetAdded();
        Debug.Log($"[Added_3] {added.Attack},  {added.Hp}, {added.Speed}");
        
        
        
        //====================
        IStat current = handler.GetCurrent();
        Debug.Log($"{current.Attack},  {current.Hp}, {current.Speed}");
    }
}