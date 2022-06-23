using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    public GameObject TextMoney; //Вывод на экран
    public int MP; //Деньги
    public int End; //Жизни игры
    void Start() {
        //Начальные значения
        MP = 100;
        End = 4;
    }
    void Update() {
        TextMoney.GetComponent<Text>().text = MP.ToString();
        if (End < 1){
            //Закрытие игры
            Application.Quit();
            Debug.Log("End");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
