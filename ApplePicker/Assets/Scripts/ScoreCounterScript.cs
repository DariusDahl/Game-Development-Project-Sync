using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI; // THis line enables use of uGUI classes like text
using TMPro;

public class ScoreCounterScript : MonoBehaviour
{

    [Header("Dynamic")]
    public int score = 0;
    private TextMeshProUGUI uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0");
    }
}
