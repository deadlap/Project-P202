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
        if (_xTerms.Count != 0) {
            _shortened.AddRange(ShortenXTerms(_xTerms));
        }

        if (!string.IsNullOrEmpty(_temp)) {
        // Vi tjekker om den første Char i stringen er et +, for hvis det er kan den ikke køre matematikken.
            if (_temp[0] == '+'){
                _temp = _temp.Substring(1, _temp.Length-1);
            }
            
            ExpressionEvaluator.Evaluate(_temp, out float _result);
            // Tjekker om tallet er et heltal
            if (_result % 1 == 0) {
                _temp = _result.ToString();
            }
            if (_result != 0) {
                if (_result > 0 && _xTerms.Count != 0) {
                    // if (_xTerms.Count != 0) {
                    _temp = "+" + _temp;
                    // }
                }
                _shortened.Add(_temp);
            }
        }
        return _shortened;
    }
    public List<string> ShortenXTerms(List<string> _xTerms) {
        string _temp = string.Join("",_xTerms).Replace("x", "1");
        ExpressionEvaluator.Evaluate(_temp, out float _result);
        _xTerms.Clear();
        if (_result == 1) {
            _temp = "x";
        } else if (_result != 0) {
            _temp = _result.ToString() + "*x";
        }
        if (_result != 0) {
            _xTerms.Add(_temp);
        }
        return _xTerms;
        // for (int i = 0; i < _xTerms.Count; i++) {
        //     if (_xTerms.Count == 1) {
        //         break;
        //     }
        //     _xTerms[i] = string.Join("", _xTerms[i].Split('x'));
        //     ExpressionEvaluator.Evaluate(_xTerms[i], out float _xResult);
        //     _xTerms[i] = _xResult.ToString();
        //     _xTerms[i] += "*x";
        // }
        // return _xTerms;
    }
}