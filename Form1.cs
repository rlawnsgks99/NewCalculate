using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCalculate
{
    public partial class Form1 : Form
    {
        string currentInput = "";
        public Form1()
        {
            InitializeComponent();
        }

        // 버튼 클릭 이벤트
        private void Button_Clik(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
            currentInput += button.Text;
        }

        // 특수 기능 버튼 클릭 이벤트
        private void SpecialButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            switch (buttonText)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    // '+' '-' '*' '/' 연산자 버튼을 클릭했을 때의 처리
                    textBox1.Text += buttonText;
                    currentInput += buttonText;
                    break;
                case ".":
                    // '.' 버튼을 클릭했을 때의 처리
                    textBox1.Text += buttonText;
                    currentInput += buttonText;
                    break;
                case "%":
                    // '%' 버튼을 클릭했을 때의 처리
                    double value = double.Parse(currentInput) / 100.0;
                    textBox1.Text = value.ToString();
                    currentInput = value.ToString();
                    break;
                case "1/x":
                    // '1/x' 버튼을 클릭했을 때의 처리
                    double reciprocal = 1.0 / double.Parse(currentInput);
                    textBox1.Text = reciprocal.ToString();
                    currentInput = reciprocal.ToString();
                    break;
                case "x^2":
                    // 'x^2' 버튼을 클릭했을 때의 처리
                    double square = Math.Pow(double.Parse(currentInput), 2);
                    textBox1.Text = square.ToString();
                    currentInput = square.ToString();
                    break;
                case "√":
                    // '루트' 버튼을 클릭했을 때의 처리
                    double sqrt = Math.Sqrt(double.Parse(currentInput));
                    textBox1.Text = sqrt.ToString();
                    currentInput = sqrt.ToString();
                    break;
                // 기타 특수 기능 추가 가능
                case "CE":
                    currentInput = "";
                    textBox1.Text = "";
                    break;
                case "C":
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                    break;
                case "DEL":
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                    break;
            }
        }

        // '=' 버튼 클릭 이벤트
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var result = dt.Compute(currentInput, "");
            textBox1.Text = result.ToString();
            currentInput = result.ToString();
        }

    }
}
