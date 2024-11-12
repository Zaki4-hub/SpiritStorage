using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Не забудьте добавить эту строку для работы с UI элементами

public class TrashTrigger : MonoBehaviour
{
    public int trashcount = 0;
    private const int maxtrashcount = 1;
    public Text trashtext; // Измените 'text' на 'Text' (с заглавной буквы)

    // Start is called before the first frame update
    void Start()
    {
        trashtextupdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Исправлено имя метода
    private void OnTriggerEnter(Collider other) // Добавьте 'void' перед методом
    {
        if (other.CompareTag("Trash"))
        {
            trashcount++;
            Destroy(other.gameObject); // Исправлено на 'Destroy(other.gameObject)'
            trashtextupdate();
        }
    }

    void trashtextupdate()
    {
        trashtext.text = $"Винести Мусор: {trashcount}/{maxtrashcount} ";

        if (trashcount >= maxtrashcount)
        {
            trashtext.color = Color.green;
        }
    }
}
