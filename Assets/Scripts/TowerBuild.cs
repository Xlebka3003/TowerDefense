using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    public GameObject Platform; //Ссылка на фундамент башни
    public GameObject Tower; //Ссылка на башню
    private GameObject MPManager; //Ссылка на деньги
    public void Build(){
        MPManager = GameObject.Find("MoneyManager");
        if (MPManager.GetComponent<Money>().MP >= 100){
            MPManager.GetComponent<Money>().MP -= 100;
            GameObject Platforms = Instantiate(Platform);
            Platforms.transform.position = transform.position;
            GameObject Towers = Instantiate(Tower);
            Towers.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
