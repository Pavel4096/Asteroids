using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Calculator
    {
        private Dictionary<string, float> variables;
        private const string NoSuchVariable = "Нет переменной с именем '{0}'";
        private const string UnknownOperator = "Неизвестный оператор '{0}'";

        public Calculator()
        {
            variables = new Dictionary<string, float>();
            variables.Add("x", 0);
        }

        public float Compute(string expression)
        {
            int index = 0;
            int start = 0;
            string currentToken = String.Empty;
            var elements = new List<string>();
            float result;
            float secondOperand = 0.0f;
            string currentOperator = String.Empty;
            int inParentheses = 0;
            bool inMultiplicative = false;
            bool restoreMore = false;
            var stack = new Stack<OperandAndOperator>(8);
            OperandAndOperator savedOperandAndOperator;

            elements.Add("0");
            elements.Add("+");
            while (index < expression.Length)
            {
                if (expression[index].Equals(' '))
                {
                    if (start < index)
                    {
                        currentToken = expression.Substring(start, index - start);
                        elements.Add(currentToken);
                    }
                    while ((index < expression.Length) && expression[index].Equals(' '))
                        index++;
                    start = index;
                }
                else if (expression[index].Equals('+') || expression[index].Equals('-') || expression[index].Equals('*') || expression[index].Equals('/') || expression[index].Equals('(') || expression[index].Equals(')'))
                {
                    if (start < index)
                    {
                        currentToken = expression.Substring(start, index - start);
                        elements.Add(currentToken);
                    }
                    currentToken = expression.Substring(index, 1);
                    elements.Add(currentToken);
                    index++;
                    start = index;
                }
                else
                    index++;
            }
            if (start < index)
            {
                currentToken = expression.Substring(start, index - start);
                elements.Add(currentToken);
            }

            index = 0;
            result = ParseOperand(elements[index++]);
            while (index < elements.Count)
            {
                if (restoreMore)
                {
                    restoreMore = false;
                }
                else
                {
                    currentOperator = elements[index++];
                    if (currentOperator.Equals(")"))
                    {
                        inParentheses--;
                        savedOperandAndOperator = stack.Pop();
                        secondOperand = result;
                        (result, currentOperator, inMultiplicative) = savedOperandAndOperator;
                        if (inMultiplicative)
                            restoreMore = true;
                    }
                    else if (elements[index].Equals("("))
                    {
                        stack.Push(new OperandAndOperator(result, currentOperator, inMultiplicative, inMultiplicative, true));
                        inMultiplicative = false;
                        inParentheses++;
                        index++;
                        result = ParseOperand(elements[index++]);
                        continue;
                    }
                    else
                    {
                        secondOperand = ParseOperand(elements[index++]);
                        if ((index < (elements.Count - 1)) && !inMultiplicative && (elements[index].Equals("*") || elements[index].Equals("/")))
                        {
                            stack.Push(new OperandAndOperator(result, currentOperator, inMultiplicative, inMultiplicative, false));
                            result = secondOperand;
                            inMultiplicative = true;
                            continue;
                        }

                        if ((index < (elements.Count - 1)) && inMultiplicative && (elements[index].Equals("-") || elements[index].Equals("+")))
                        {
                            savedOperandAndOperator = stack.Pop();
                            secondOperand = result;
                            (result, currentOperator, inMultiplicative) = savedOperandAndOperator;
                        }
                    }
                }

                switch (currentOperator)
                {
                    case "+":
                        result += secondOperand;
                        break;
                    case "-":
                        result -= secondOperand;
                        break;
                    case "*":
                        result *= secondOperand;
                        break;
                    case "/":
                        result /= secondOperand;
                        break;
                    default:
                        throw new ArgumentException(String.Format(UnknownOperator, currentOperator));
                }
            }

            return result;
        }

        public float ParseOperand(string operand)
        {
            float result = 0f;

            if (!Single.TryParse(operand, out result))
            {
                if (!variables.ContainsKey(operand))
                    throw new ArgumentException(String.Format(NoSuchVariable, operand));
                result = variables[operand];
            }

            return result;
        }

        public void AddVariable(string name, float value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }

        private readonly struct OperandAndOperator
        {
            public readonly float operand;
            public readonly string operator2;
            public readonly bool inMultiplicative;
            public readonly bool restoreMore;
            public readonly bool isParentheses;

            public OperandAndOperator(float _operand, string _operator, bool _inMultiplicative, bool _restoreMore, bool _isParentheses)
            {
                operand = _operand;
                operator2 = _operator;
                inMultiplicative = _inMultiplicative;
                restoreMore = _restoreMore;
                isParentheses = _isParentheses;
            }

            public void Deconstruct(out float _operand, out string _operator, out bool _inMultiplicative)
            {
                _operand = operand;
                _operator = operator2;
                _inMultiplicative = inMultiplicative;
            }
        }
    }
}
