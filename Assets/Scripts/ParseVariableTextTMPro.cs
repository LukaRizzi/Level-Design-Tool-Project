using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ParseVariableTextTMPro : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private bool updateConstant = true;
    private IList<string> _quotes;
    private string unformattedText;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        unformattedText = text.text;

        _quotes = betweenQuotes(text.text);

        foreach (string _i in _quotes)
        {
            text.text = text.text.Replace("{{" + _i + "}}", VariableManager.GetVariable(_i).ToString());
        }
    }

    private void Update()
    {
        if (updateConstant)
        {
            foreach (string _i in _quotes)
            {
                text.text = unformattedText.Replace("{{" + _i + "}}", VariableManager.GetVariable(_i).ToString());
            }
        }
    }

    private static IList<string> betweenQuotes(string input)
    {
        var result = new List<string>();

        int leftQuote = input.IndexOf("{{");

        while (leftQuote > -1)
        {
            int rightQuote = input.IndexOf("}}", leftQuote);
            if (rightQuote > -1 && rightQuote > leftQuote)
            {
                result.Add(input.Substring(leftQuote + 2, (rightQuote - (leftQuote + 2))));
            }
            leftQuote = input.IndexOf("{{", rightQuote + 1);
        }

        return result;
    }
}