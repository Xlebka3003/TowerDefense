using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Rigidbody2D rb; //Свойство башни
    public GameObject Bullet; //Ссылка для создания снаряда
    private float speed; //Скорость создания снаряда
    private float t; //Отсчет до спавна снаряда
    public GameObject [] Enemy; //Массив врагов на карте
    private float radius; //Расстояние для спавна снаряда
    private GameObject NBullet; //Ссылка на созданный снаряд
    void Start()
    {
        //Начальные значения
        speed = 0.8f;
        t = speed;
        radius = 3f;
        
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        t-=Time.deltaTime;
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        int i = 0;
        if (Enemy.Length>0){

            //Найти ближайшего врага
            for (; i < Enemy.Length-1;i++){
                if (Vector2.Distance(transform.position,Enemy[i].transform.position) <= radius){

                    //Проверка жизней                   
                    if (Enemy[i].GetComponent<EnemyMove>().hits == Enemy[i].GetComponent<EnemyMove>().HP){
                        continue;
                    }

                    //Поворот башни
                    Vector2 Target = Enemy[i].transform.position - transform.position;
                    //transform.rotation = Quaternion.Euler(0f,0f,(Mathf.Atan2(Target.y,Target.x) * Mathf.Rad2Deg)-90f);
                    rb.rotation = (Mathf.Atan2(Target.y,Target.x) * Mathf.Rad2Deg)-90f;

                    //Спавн снаряда
                    if (t<=0){
                        t=speed;
                        NBullet = Instantiate(Bullet);
                        NBullet.GetComponent<BulletMove>().Tower = transform.position;
                        NBullet.GetComponent<BulletMove>().transform.position = new Vector2(transform.position.x,transform.position.y);
                        NBullet.GetComponent<BulletMove>().Enemy = Enemy[i];
                    }
                    break;
                }
            }
        }
    }
}
