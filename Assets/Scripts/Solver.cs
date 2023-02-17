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
        
        ExpressionEvaluator.Evaluate(_temp, out int _result);

        _shortened.Add(_result.ToString());
        _shortened.AddRange(_xTerms);

        return _shortened;
    }
    
    public List<string> SeperateTerms(string equation) {
        return new List<string>();
    }
}
