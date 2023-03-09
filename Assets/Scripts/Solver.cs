using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class Solver {
    
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
        Debug.Log("1/2:"+CollapseToFraction("1/2*1"));
        if (_xTerms.Count != 0) {
            _shortened.AddRange(ShortenXTerms(_xTerms));
            Debug.Log(_xTerms);
        }

        if (!string.IsNullOrEmpty(_temp)) {
        // Vi tjekker om den første Char i stringen er et +, for hvis det er kan den ikke køre matematikken.
            if (_temp[0] == '+') {
                _temp = _temp.Substring(1, _temp.Length-1);
            }

            ExpressionEvaluator.Evaluate(_temp, out float _result);
            // Tjekker om tallet er et heltal
            if (_result % 1 == 0) {
                _temp = _result.ToString();
            } else if (_temp.Contains('/')) {
                _temp = CollapseToFraction(_temp);
            }

            if (_result != 0) {
                if (_result > 0 && _xTerms.Count != 0) {
                    _temp = "+" + _temp;
                }
                _shortened.Add(_temp);
            }
        }

        return _shortened;
    }

    public List<string> ShortenXTerms(List<string> _xTerms) {
        string _temp = string.Join("",_xTerms).Replace("x", "1");

        if (_temp[0] == '*' || _temp[0] == '+') {
            _temp = _temp.Substring(1, _temp.Length-1);
        }

        if (_temp.Contains('/')) {
            _temp = CollapseToFraction(_temp);
            Debug.Log(CollapseToFraction(_temp));
        }
        ExpressionEvaluator.Evaluate(_temp, out float _result);

        _xTerms.Clear();

        if (_result == 1) {
            _temp = "x";
        } else if (_result != 0) {
            if (_result % 1 == 0) {
                _temp = _result.ToString();
            }
            _temp += "*x";
        }
        if (_result != 0) {
            _xTerms.Add(_temp);
        }
        return _xTerms;
    }

    public string CollapseToFraction(string _term) {
        int _index = _term.IndexOf('/');
        string _numerator = _term.Substring(0,_index);
        string _denominator = "";
        string _fraction = _term;

        //at what index the denominator ends.
        int _denomIndex = _index;
        while (true) {
            _denomIndex += 1;
            if (_denomIndex == _term.Length || _term[_denomIndex] == '-' || _term[_denomIndex] == '+' || _term[_denomIndex] == '*') {
                _denomIndex -= 1;
                break;
            }
            _denominator += _term[_denomIndex];
        }

        if (_denomIndex+1 < _term.Length-1) {    
            string _temp = _term.Substring(_denomIndex+1, _term.Length - (_denomIndex+1));
            if (_temp[0] == '+')
                _temp = _temp.Substring(1, _temp.Length-1);
            
            if (_temp.Contains("*")) {
                _numerator = _numerator+_temp;
            } else {
                _numerator = _denominator + "* (" + _temp + ")" + "+" +_numerator;
            }

            Debug.Log("hej"+ExpressionEvaluator.Evaluate(_numerator, out float _result));

            _fraction = _result + "/" + _denominator;
        }

        return _fraction;
    }
}