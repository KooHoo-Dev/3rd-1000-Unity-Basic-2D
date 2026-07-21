using Study_OOP_And_Design_Pattern.Structural.Bridge;
using UnityEngine;

public class WeaponBrideDemo : MonoBehaviour
{
    private Sword sword = new Sword();
    private Bow bow = new Bow(); 
        
    private void Start()
    {
        sword.SetEnchant(new FireEnchant());
        sword.Attack();
            
        sword.SetEnchant(new IceEnchant());
        sword.Attack();
            
        sword.SetEnchant(null);
        sword.Attack();
        
        bow.SetEnchant(new FireEnchant());
        bow.Attack();

        bow.SetEnchant(new IceEnchant());
        bow.Attack();
        
        bow.SetEnchant(null);
        bow.Attack();
    }
}