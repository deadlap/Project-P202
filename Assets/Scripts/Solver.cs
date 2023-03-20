using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using UnityEditor;

public class Solver {
    
    public List<string> Shorten(List<string> part) {
        string _tempTerms = "";
        List<string> _xTerms = new List<string>();
        List<string> _shortened = new List<string>();

        foreach (string _term in part) {
            if (_term.Contains('x')) {
                _xTerms.Add(_term);
            } else {
                _tempTerms += _term;
            }
        }
        
        if (_xTerms.Count != 0) {
            _shortened.AddRange(ShortenXTerms(_xTerms));
        }

        if (!string.IsNullOrEmpty(_tempTerms)) {
        // Vi tjekker om den første Char i stringen er et +, for hvis det er kan den ikke køre matematikken.
            if (_tempTerms[0] == '+') {
                _tempTerms = _tempTerms.Substring(1, _tempTerms.Length-1);
            }

            Evaluate(_tempTerms, out float _result);
            // Tjekker om tallet er et heltal
            if (_result == 0.0f) {
                if (_xTerms.Count == 0) {
                    _shortened.Add("0");
                }
                return _shortened;
            }

            if (_result % 1 == 0) {
                _tempTerms = _result.ToString();
            } else {
                _tempTerms = ConvertToFraction(_result);
            }

            List<string> _split = new List<string>();

            if (_result > 0 && _shortened.Count != 0) {
                _tempTerms = "+" + _tempTerms;
                if (_tempTerms.Contains('+')) {
                    _split.AddRange(Regex.Split(_tempTerms, @"(?=[+])"));
                } else if (_tempTerms.Contains('-')) {
                    _split.AddRange(Regex.Split(_tempTerms, @"(?=[-])"));
                }
            } else {
                _split.Add(_tempTerms);
            }
            _shortened.AddRange(_split);
        }
        return _shortened;
    }

    public List<string> ShortenXTerms(List<string> _xTerms) {
        string _tempTerms = string.Join("",_xTerms).Replace("x", "1");

        if (_tempTerms[0] == '+') {
            _tempTerms = _tempTerms.Substring(1, _tempTerms.Length-1);
        }

        Evaluate(_tempTerms, out float _result);

        _xTerms.Clear();
        _tempTerms = "";
        if (_result == 1) {
            _xTerms.Add("x");
            return _xTerms;
        }
        if (_result == 0 )
            return new List<string>();

        if (_result % 1 == 0) {
            _xTerms.Add(_result.ToString());
            ApplyXToEachTerm(_xTerms);
        } else {
            _tempTerms = ConvertToFraction(_result);
            if (_tempTerms.Contains('+')) {
                _xTerms.AddRange(Regex.Split(_tempTerms, @"(?=[+])"));
                ApplyXToEachTerm(_xTerms);
            } else if (_tempTerms.Contains('-')) {
                _xTerms.AddRange(Regex.Split(_tempTerms, @"(?=[-])"));
                ApplyXToEachTerm(_xTerms);
            } else {
                _tempTerms += "*x";
                _xTerms.Add(_tempTerms);
            }
        }
        return _xTerms;
    }

    public void ApplyXToEachTerm(List<string> _terms){
        for (int i = 0; i < _terms.Count; i++) {
            if (_terms[i].Length == 1 && _terms[i][0] == '1') {
                _terms[i] = "x";
            } else {
                _terms[i] += "*x";
            }
        }
    }

    public string ConvertToFraction(float decimalNumber) {
        float tolerance = 0.00001f;
        int integerPart = (int)decimalNumber;
        float decimalPart = decimalNumber - integerPart;
        float numerator = 1.0f;
        float denominator = 1.0f;
        float approximation = numerator / denominator;

        while (Math.Abs(approximation - decimalPart) > tolerance) {
            if (approximation < decimalPart) {
                numerator += 1.0f;
            } else {
                denominator += 1.0f;
                numerator = (float)Math.Floor(decimalPart * denominator);
            }
            approximation = numerator / denominator;
        }
        string fraction = numerator + "/" + denominator;
        if (integerPart > 0) {
            fraction = integerPart + "+" + fraction;
        }
        return fraction;
    }
    
    public static bool Evaluate(String expression, out float result) {
        try {
            System.Data.DataTable table = new System.Data.DataTable();
            result = (float)Convert.ToDouble(table.Compute(expression, String.Empty));
            return true;
        } catch {
            return false;
        }
    }
}