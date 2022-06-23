using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Rigidbody2D rb; //Свойство врага
    protected float speed; //Скорость врага
    public GameObject [] Points; //Массив точек для перемещения
    private int i; //Индекс точек перемещения
    public int direction; //Направление движения врага
    public int HP; //Максимальное здоровье врага
    public int health; //Здоровье врага
    public int hits; //Попаданий
    private GameObject MPManager; //Ссылка на деньги
    protected int treasure; //Награда за убийство врага
    protected void ForStart(){
        //Начальные значения
        speed = 16f;
        i = 0;
        direction = 1;
        HP = 2;
        health = HP;
        hits = 0;
        treasure = 10;

        MPManager = GameObject.Find("MoneyManager");
        Points = GameObject.FindGameObjectsWithTag("Point");
    }
    protected void ForUpdate()    
    {
        //Проверка на смерть
        if (health < 1){
            MPManager.GetComponent<Money>().MP += treasure;
            Destroy(gameObject);
        }
        //Проверка на последнию точку
        if (Points[Points.Length-1].transform.position.y-0.2f<transform.position.y && Points[Points.Length-1].transform.position.y+0.2f>transform.position.y && Points[Points.Length-1].transform.position.x-0.2f<transform.position.x && Points[Points.Length-1].transform.position.x+0.2f>transform.position.x){
            MPManager.GetComponent<Money>().End--;
            Destroy(gameObject);
        }

        //Движение по точкам
        if (Points[i].transform.position.y-0.2f<transform.position.y && Points[i].transform.position.y+0.2f>transform.position.y && Points[i].transform.position.x-0.2f<transform.position.x && Points[i].transform.position.x+0.2f>transform.position.x){
                rb.velocity = new Vector2(0f,0f);
                direction = 0;
                if (i<Points.Length-1){
                    i++;
                }
        }else
        if(Points[i].transform.position.x-0.1f<transform.position.x && Points[i].transform.position.x+0.1f>transform.position.x){
            if (Points[i].transform.position.y>transform.position.y-0.2f){
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                direction = 3;
                rb.velocity = new Vector2(0f,0.1f*speed);
            }else if (Points[i].transform.position.y<transform.position.y+0.2f){
                transform.rotation = Quaternion.Euler(0f,0f,270f);
                direction = 4;
                rb.velocity = new Vector2(0f,-0.1f*speed);
            } 
        }else
        if (Points[i].transform.position.x>transform.position.x){
            if (Points[i].transform.position.y>transform.position.y+0.1f){
                transform.rotation = Quaternion.Euler(0f,0f,45f);
                rb.velocity = new Vector2(0.1f*speed,0.1f*speed);
            }else if (Points[i].transform.position.y<transform.position.y-0.1f){
                transform.rotation = Quaternion.Euler(0f,0f,315f);
                rb.velocity = new Vector2(0.1f*speed,-0.1f*speed);
            }else if (Points[i].transform.position.y-0.05f<transform.position.y || Points[i].transform.position.y+0.05f>transform.position.y){
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                direction = 1;
                rb.velocity = new Vector2(0.1f*speed,0f);
            }
        }else if (Points[i].transform.position.x<transform.position.x){
            if (Points[i].transform.position.y>transform.position.y+0.1f){
                transform.rotation = Quaternion.Euler(0f,0f,135f);
                rb.velocity = new Vector2(-0.1f*speed,0.1f*speed);
            }else if (Points[i].transform.position.y<transform.position.y-0.1f){
                transform.rotation = Quaternion.Euler(0f,0f,225f);
                rb.velocity = new Vector2(-0.1f*speed,-0.1f*speed);
            }else if (Points[i].transform.position.y-0.05f<transform.position.y || Points[i].transform.position.y+0.05f>transform.position.y-0.1f){
                transform.rotation = Quaternion.Euler(0f,0f,180f);
                direction = 2;
                rb.velocity = new Vector2(-0.1f*speed,0f);
            }
        }  
    }
    void Start(){
        ForStart();
    }
    void Update(){
        ForUpdate();
    }

}
