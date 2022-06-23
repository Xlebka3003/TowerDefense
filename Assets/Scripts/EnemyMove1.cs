using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove1 : EnemyMove
{
    private void Start()
    {
        ForStart();
        //Начальные значения
        HP = 2;
        health = HP;
        treasure = 10;
    }
    private void Update()
    {
        ForUpdate();
    }
}
