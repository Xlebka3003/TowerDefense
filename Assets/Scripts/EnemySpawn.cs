using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy; //Ссылка на врага
    public GameObject Enemy2; //Ссылка на второго врага
    private float speed; //Начальная скорость спавна врага
    private float t; //Счетчик до спавна врага
    private int count; //Количество врагов
    void Start()
    {
        //Начальные значения
        speed = 0.5f;
        count = 50;
        t = speed;
        Enemy.transform.position = new Vector2(transform.position.x,transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        t-=Time.deltaTime;
        if (t<=0 && count > 0){
            count--;          
            t=Random.Range(speed,1.2f); //Скорость спавна врага
            Instantiate(Random.Range(0,4)>0?Enemy:Enemy2);
        }
    }
}
