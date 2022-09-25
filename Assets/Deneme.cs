using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{

    List<Weapon> weaponList = new List<Weapon>();

    List<int> intList;

    public Weapon deagle;

    private void Start()
    {
         // weaponList.Add(new Weapon());

           deagle = new Weapon("isim",10);


    }



  



}

[System.Serializable]
public class Weapon

{

    public string name;
    public int reloadSpeed;


  
    public Weapon(string name, int reloadSpeed)
    {
        this.name = name;

        this.reloadSpeed = reloadSpeed;

    }



}
