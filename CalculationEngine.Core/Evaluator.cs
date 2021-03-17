using System;

namespace CalculationEngine.Core
{
    public class Evaluator
    {
        private decimal _fac;
        private string _expression;
       
        private int _expressionPosition;

        public decimal Evaluate(string input)
        {
            _expression = input;
            _expressionPosition = 0;
            try
            {
                StartCalculations('\0');
            }
            catch
            {
                var apiResponse = ApiCall.GetExpressionResult(input);
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    _fac = Convert.ToDecimal(apiResponse);
                }
            }

            return _fac;
        }

        private void StartCalculations(char opr) {
            
            do
            {
                opr = Calculations(opr);
            }
            while (opr > 0);
        }

        private char Calculations(char opr)
        {
            switch (opr)
            {
                case '+':
                {
                    var curFac = _fac;
                    opr = GetValueAndNextOperator(opr);
                    _fac = Calculation.Addition(curFac, _fac); 
                    return opr;
                }
                case '-':
                {
                    var curFac = _fac;
                    opr = GetValueAndNextOperator(opr);
                    _fac = Calculation.Subtraction(curFac, _fac);
                        return opr;
                }
                case '*':
                {
                    var curFac = _fac;
                    opr = GetValueAndNextOperator(opr);
                    _fac = Calculation.Multiplication(curFac, _fac);
                        return opr;
                }
                case '/':
                {
                    var curFac = _fac;
                    opr = GetValueAndNextOperator(opr);
                    _fac = Calculation.Division(curFac, _fac);
                        return opr;
                }
                case '^':
                {
                   throw new NotImplementedException();
                }
                default:
                    return GetValueAndNextOperator(opr);
            }
        }

        private char NextOperator()
        {
            while (_expressionPosition < _expression.Length && Char.IsWhiteSpace(_expression[_expressionPosition]))
                _expressionPosition++;
            var opr = _expressionPosition < _expression.Length ? _expression[_expressionPosition++] : '\0';
            return opr;
        }

        private char GetValueAndNextOperator(char opr)
        {
            if (opr == ')')
                return '\0';

            // at this point we clear the fac as this level will hopefully find a new value for it
            _fac = 0;
            if (_expressionPosition >= _expression.Length)
                return '\0';

            while (_expressionPosition < _expression.Length && Char.IsWhiteSpace(_expression[_expressionPosition]))
                _expressionPosition++;

            // the current opr (symbol).
            opr = _expression[_expressionPosition];
            if (opr == '(')
            {
                _expressionPosition++;
                StartCalculations(_expression[_expressionPosition]);
            }
            else
            {
                var end = _expressionPosition;
                bool canNegate = true;
                while (end < _expression.Length
                       && (Char.IsDigit(_expression[end]) || (canNegate && _expression[end] == '-')))
                {
                    canNegate = false;
                    end++;
                }
                var sv = _expression.Substring(_expressionPosition, end - _expressionPosition);
                _expressionPosition = end;
                _fac = Decimal.Parse(sv);
            }

            return NextOperator();
        }

    }
}
