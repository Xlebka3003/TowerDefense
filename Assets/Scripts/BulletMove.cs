using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed; //Скорость снаряда
    private Vector2 Target; //Координаты врага
    private float Lifespan; //Время жизни снаряда
    private float start; //Отчет времени
    private float x; //Расстояние до врага
    public GameObject Enemy; //Ссылка на врага
    public Vector3 Tower; //Координаты башни, которая создала снаряд

    void Start()
    {
        //Начальные значения
        speed = 16f;
        Lifespan = 4f;

        Enemy.GetComponent<EnemyMove>().hits++;
        switch(Enemy.GetComponent<EnemyMove>().direction){
            case 1:{
                Target = new Vector2(Enemy.transform.position.x+0.4f,Enemy.transform.position.y);
                break;
                }
            case 2:{
                Target = new Vector2(Enemy.transform.position.x-0.4f,Enemy.transform.position.y);
                break;
                }
            case 3:{
                Target = new Vector2(Enemy.transform.position.x,Enemy.transform.position.y+0.4f);
                break;
                }
            case 4:{
                Target = new Vector2(Enemy.transform.position.x,Enemy.transform.position.y-0.4f);
                break;
                }
            default:{
                Target = Enemy.transform.position;
                break;
                }
        }
        x = Vector2.Distance(transform.position,Target);
        start = Time.time;
    }

    void Update(){
        transform.position=Vector2.Lerp(transform.position,Target,(Time.time-start)*speed/x);
        Lifespan -= Time.deltaTime;
        if (Lifespan < 0 || new Vector2(transform.position.x,transform.position.y) == Target){
            Destroy(gameObject);
            Enemy.GetComponent<EnemyMove>().health--;
        }
    }
}
