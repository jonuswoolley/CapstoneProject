using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour
{
    public GameObject BlackBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;

    // Start is called before the first frame update
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('*'));
        }
        theText.enabled = false;
        BlackBox.SetActive(false);
    }

    public void DisplayText(int textIndex)
    {
        theText.enabled = true;
        BlackBox.SetActive(true);
        theText.text = textLines[textIndex];
    }

    public void DisableText()
    {
        theText.enabled = false;
        BlackBox.SetActive(false);
    }

    public IEnumerator DisplayTextTimed(int textIndex, int waitTime)
    {
        theText.enabled = true;
        BlackBox.SetActive(true);
        theText.text = textLines[textIndex];

        yield return new WaitForSeconds(waitTime);

        theText.enabled = false;
        BlackBox.SetActive(false);
        theText.text = textLines[textIndex];
    }
}
