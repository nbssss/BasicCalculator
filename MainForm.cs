namespace calc
{
    public partial class MainForm : Form
    {
        private double firstTemp = 0;
        private double secondTemp = 0;
        private double result = 0;
        private string currentOperator;
        private bool isOperatorClicked = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox_input.Text += btn.Text;
            isOperatorClicked = false;
        }

        private void button_operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (isOperatorClicked == false)
            {
                isOperatorClicked = true;
                firstTemp = Convert.ToDouble(textBox_input.Text);
                currentOperator = btn.Text;
                textBox_input.Clear();
            }
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            secondTemp = Convert.ToDouble(textBox_input.Text);
            isOperatorClicked = false;

            switch(currentOperator)
            {
                case "+":
                    {
                        result = firstTemp + secondTemp;
                        textBox_input.Text = Convert.ToString(result);
                        break;
                    }
                case "-":
                    {
                        result = firstTemp - secondTemp;
                        textBox_input.Text = Convert.ToString(result);
                        break;
                    }
                case "x":
                    {
                        result = firstTemp * secondTemp;
                        textBox_input.Text = Convert.ToString(result);
                        break;
                    }
                case "/":
                    {
                        if (secondTemp != 0)
                        {
                            result = firstTemp / secondTemp;
                            textBox_input.Text = Convert.ToString(result);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Can not divide by zero. Insert different value.");
                            textBox_input.Clear();
                            break;
                        }
                    }
            }
        }
    }
}