using System.CodeDom.Compiler;
using System.Collections;

namespace calc
{
    public partial class MainForm : Form
    {
        private double temp = 0;
        private double t = 0;

        private double secondTemp = 0;
        private double result = 0;
        private string currentOperator;
        private bool isOperatorClicked = false;

        Queue<double> tempQueue = new Queue<double>();
        Queue<string> operatorQueue = new Queue<string>();
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox_input.Text += btn.Text;
            isOperatorClicked = false;
            temp = Convert.ToDouble(textBox_input.Text);
        }

        private void button_operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (isOperatorClicked == false)
            {
                tempQueue.Enqueue(temp);
                isOperatorClicked = true;
                currentOperator = btn.Text;
                operatorQueue.Enqueue(currentOperator);
                textBox_input.Clear();
            }
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            if (isOperatorClicked == false)
            {
                tempQueue.Enqueue(temp);
            }

            while (operatorQueue.Count > 0)
            {
                double temp1 = tempQueue.Dequeue();
                double temp2;

                if (tempQueue.Count > 0)
                {
                    temp2 = tempQueue.Dequeue();
                }
                else
                {
                    temp2 = temp1;
                }

                string currentOperator = operatorQueue.Dequeue();

                switch (currentOperator)
                {
                    case "+":
                        result = temp1 + temp2;
                        break;
                    case "-":
                        result = temp1 - temp2;
                        break;
                    case "x":
                        result = temp1 * temp2;
                        break;
                    case "/":
                        if (temp2 != 0)
                        {
                            result = temp1 / temp2;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero.");
                        }
                        break;
                }
                tempQueue.Enqueue(result);
            }
            textBox_input.Text = result.ToString();
            temp = result; 
            tempQueue.Clear();
            operatorQueue.Clear();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_input.Clear();
        }
    }
}