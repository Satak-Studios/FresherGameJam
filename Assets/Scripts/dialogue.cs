using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using NUnit.Framework.Internal;
public class dialogue : MonoBehaviour
{
    public TextMeshProUGUI text_box;
    public TextMeshProUGUI speaker_box;
    public float textSpeed;

    private string[] speakers;
    private string[] lines;
    private int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(index);
            if(text_box.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text_box.text = lines[index];
            }
        }
    }

    public void StartDialogue(string[] new_lines,string[] new_speakers)
    {
        text_box.text = string.Empty;
        speaker_box.text = string.Empty;
        speakers = new_speakers;
        lines = new_lines;
        index = 0;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {
        speaker_box.text = speakers[index];
        foreach(char c in lines[index].ToCharArray())
        {
            text_box.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            text_box.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else{
            gameObject.SetActive(false);
        }
    }
}
