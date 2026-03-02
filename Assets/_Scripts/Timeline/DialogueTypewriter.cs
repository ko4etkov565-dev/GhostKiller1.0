using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueTyperwriter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private string fullText;
    private Coroutine typingCoroutine;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        // Запам'ятовуємо текст, який ти написав в інспекторі
        fullText = textMesh.text;
        // Очищуємо поле, щоб воно було порожнім до початку сигналу
        textMesh.text = "";
    }

    // Цей метод ми викличемо через Сигнал у Таймлайні
    public void StartTyping()
    {
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        textMesh.text = "";
        typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char c in fullText.ToCharArray())
        {
            textMesh.text += c;
            yield return new WaitForSeconds(0.05f); // Швидкість друку
        }
    }

    // Коли Таймлайн вимикає об'єкт, готуємо його до наступного разу
    void OnDisable()
    {
        if (textMesh != null) textMesh.text = "";
    }
}
