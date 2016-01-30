using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextStuff : MonoBehaviour
{
    public string textToType;
    public float lettersPerSecond;
    // Use this for initialization
    void Start()
    {
        _previousLPS = lettersPerSecond;
    }

    // Update is called once per frame

    public float _previousLPS = 0;
    char _charToAdd;
    public float timeSinceLastLetter = 0;
    void Update()
    {
        if (timeSinceLastLetter > (1.0 / lettersPerSecond))
        {
            if (textToType.Length > 0)
            {
                if (_charToAdd == '.')
                {
                    lettersPerSecond = _previousLPS / 2;
                    _charToAdd = textToType.ToCharArray()[0];
                    textToType = textToType.Remove(0, 1);
                    GetComponent<Text>().text += _charToAdd.ToString();
                }
                else
                {
                    lettersPerSecond = _previousLPS;
                    _charToAdd = textToType.ToCharArray()[0];
                    textToType = textToType.Remove(0, 1);
                    GetComponent<Text>().text += _charToAdd.ToString();
                }
            }
            /*
            if (Input.GetKeyDown (KeyCode.Z)) {
                GetComponent<Text> ().text += textToType;
                textToType = "";
            }
*/
            timeSinceLastLetter = 0;
        }

        if (textToType != "")
        {
            timeSinceLastLetter += Time.deltaTime;
        }

        // At random, signal our text's material to "jitter" the text.
        GetComponent<Text>().materialForRendering.SetFloat("_JitterX", Random.Range(0.0f, 1.0f));
        GetComponent<Text>().materialForRendering.SetFloat("_JitterY", Random.Range(0.0f, 1.0f));

    }

    void OnEnable()
    {
        textToType = GetComponent<Text>().text;
        GetComponent<Text>().text = "";
        timeSinceLastLetter = 0;
    }

    void OnDisable()
    {
        GetComponent<Text>().text += textToType;
    }
}
