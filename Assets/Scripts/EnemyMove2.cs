using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : EnemyMove
{
    private void Start() {
        ForStart();
        //Начальные значения
        HP = 4;
        health = HP;
        treasure = 15;
    }
    private void Update() {
        ForUpdate();
    }
}
