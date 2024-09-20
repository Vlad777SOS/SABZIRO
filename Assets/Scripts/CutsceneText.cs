using UnityEngine;
using TMPro; // ���� ����������� TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneText : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    private int currentLine = 0;
    private bool isTyping = false;
    public float typingSpeed = 0.05f;

    void Start()
    {
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // �������� �� ������� ������
        {
            if (isTyping)
            {
                // ���� ����� ��� ����������, �������� ����� ���� �����
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLine];
                isTyping = false;
            }
            else
            {
                // ��������� � ��������� ������
                currentLine++;
                if (currentLine < dialogueLines.Length)
                {
                    StartCoroutine(TypeLine());
                }
                else
                {
                    // �������� ��������, ������� � LevelMapScene ��������
                    Debug.Log("������� � LevelMapScene.");
                    SceneManager.LoadScene("LevelMapScene");
                }
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char c in dialogueLines[currentLine])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}
