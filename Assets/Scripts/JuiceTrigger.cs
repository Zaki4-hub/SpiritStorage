using UnityEngine;
using UnityEngine.UI;

public class JuiceTrigger : MonoBehaviour
{

    public Text juiceText; // Ссылка на компонент Text в UI
    private int juiceCount = 0; // Счетчик принесенного джуса
    private const int maxJuiceCount = 5; // Максимальное количество джуса
    public GameObject Tasksmenu;

    private void Start()
    {
        UpdateJuiceText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, есть ли у объекта тег "Juice"
        if (other.CompareTag("Juice"))
        {
            // Увеличиваем счетчик
            juiceCount++;
            
            // Удаляем объект
            Destroy(other.gameObject);
            
            // Обновляем текст
            UpdateJuiceText();
        }
    }

    private void UpdateJuiceText()
    {
        // Обновляем текст на экране
        juiceText.text = $"Поставити Сік На Полиці: {juiceCount}/{maxJuiceCount}";

        // Проверяем, достигли ли мы максимума
        if (juiceCount >= maxJuiceCount)
        {
            // Меняем цвет текста на зеленый
            juiceText.color = Color.green;
        }
    }

    public void TasksOpening()
    {
    	Tasksmenu.SetActive(true);
    }

    public void TasksmenuExit()
   {
   	 Tasksmenu.SetActive(false);
   }
}