using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using lab33.Models;

namespace lab33.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        string _mainText = "";
        RomanNumberExtend n1;
        bool _error;

        private bool Error
        {
            get => _error;
            set {
                if (value) SetInvalidExpression();
                else if(!value&&_error) MainText = "";
                _error = value;
            }
        }
        char op;
        public string MainText
        {
            get
            {
                return _mainText;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _mainText, value);
            }
        }

        public void WriteChar(string x)
        {
            Error = false;
            MainText += x;
        }
        public void CalcAnswer()
        {
            var x = new RomanNumberExtend(MainText);
            try
            {
                if (op == '+')
                    MainText = (x + n1).ToString();
                else if (op == '-')
                    MainText = (n1 - x).ToString();
                else if (op == '/')
                    MainText = (n1 / x).ToString();
                else if (op == '*')
                    MainText = (n1 * x).ToString();
            } catch(RomanNumberException ex)
            {
                Error = true;
            }

        }
        public void Clear()
        {
            MainText = "";
            n1 = null;

        }
        private void SetInvalidExpression() => MainText = "ERROR";
        public void DoOperator(char op) {
            try
            {
                n1 = new RomanNumberExtend(MainText);
                this.op = op;
            } catch(RomanNumberException ex)
            {
                Error = true;
            }
            if(!Error) MainText = "";
        }
    }
}
