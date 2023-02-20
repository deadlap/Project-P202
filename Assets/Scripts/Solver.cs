using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Solver : MonoBehaviour {
    
    public List<string> Shorten(List<string> _part) {
        string _temp = "";
        List<string> _xTerms = new List<string>();
        List<string> _shortened = new List<string>();

        foreach (string _term in _part) {
            if (_term.Contains('x')) {
                _xTerms.Add(_term);
            } else {
                _temp += _term;
            }
        }

        // Vi tjekker om den første Char i stringen er et +, for hvis det er kan den ikke køre matematikken.
        if (_temp[0] == '+'){
            _temp = _temp.Substring(1, _temp.Length-1);
        }
        
        ExpressionEvaluator.Evaluate(_temp, out float _result);
        
        if (_result % 1 == 0) {
            _temp = _result.ToString();
        }

        _shortened.AddRange(_xTerms);

        if (_result != 0) {
            if (_result > 0) {
                _temp = "+" + _temp;
            }
            _shortened.Add(_temp);
        }

        return _shortened;
    }

    public List<string> SeperateTerms(string equation) {
        return new List<string>();
    }
}
