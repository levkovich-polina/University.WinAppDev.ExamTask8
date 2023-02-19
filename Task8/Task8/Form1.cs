namespace Task8
{
    public partial class Form1 : Form
    {
        public class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
            public PasswordNumber Number { get; set; }
            public Circle(Point point, int radius, PasswordNumber number)
            {
                Center = point;
                Radius = radius;
                Number = number;
            }
        }
        Circle[] _circle = new Circle[9];
        List<int> _givenPassword = new List<int>();
        List<int> _enteredPassword = new List<int>();
        PasswordMode _mode = PasswordMode.Enter;

        public enum PasswordNumber
        {
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine
        }
        public enum PasswordMode
        {
            Enter,
            Set
        }

        public Form1()
        {
            InitializeComponent();
            MakingCircles();
            string[] lines = File.ReadAllLines("password.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                _givenPassword.Add( Convert.ToInt32(lines[i]));
            }
            
            for (int i = 0; i < _givenPassword.Count; i++)
            {
                PasswordLabel.Text += _givenPassword[i] + 1;
                PasswordLabel.Text += " ";
            }
        }

        private void MakingCircles()
        {
            int width = Panel.ClientSize.Width;
            int height = Panel.ClientSize.Height;
            var shiftX = width / 4;
            var shiftY = height / 4;

            var x1 = 1 * shiftX;
            var x2 = 2 * shiftX;
            var x3 = 3 * shiftX;

            var y1 = 1 * shiftY;
            var y2 = 2 * shiftY;
            var y3 = 3 * shiftY;
            var radius = 40;
            _circle = new[]
            {
            new Circle(new Point(x1, y1), radius, PasswordNumber.One),
            new Circle(new Point(x2, y1), radius, PasswordNumber.Two),
            new Circle(new Point(x3, y1), radius, PasswordNumber.Three),

            new Circle(new Point(x1, y2), radius, PasswordNumber.Four),
            new Circle(new Point(x2, y2), radius, PasswordNumber.Five),
            new Circle(new Point(x3, y2), radius, PasswordNumber.Six),

            new Circle(new Point(x1, y3), radius, PasswordNumber.Seven),
            new Circle(new Point(x2, y3), radius, PasswordNumber.Eight),
            new Circle(new Point(x3, y3), radius, PasswordNumber.Nine),
            };
        }


        private void Draw()
        {
            Panel.CreateGraphics().Clear(Color.White);
            Graphics g = Panel.CreateGraphics();
            for (int i = 0; i < 9; i++)
            {
                g.FillEllipse(Brushes.Blue, _circle[i].Center.X - (_circle[i].Radius / 2), _circle[i].Center.Y - (_circle[i].Radius / 2), _circle[i].Radius, _circle[i].Radius);
            }

            if (_enteredPassword.Count >= 2)
            {
                for (int i = 1; i < _enteredPassword.Count; i++)
                {
                    g.DrawLine(new Pen(Color.Blue, 10), _circle[_enteredPassword[i - 1]].Center, _circle[_enteredPassword[i]].Center);
                }
            }
            if (_givenPassword.Count >= 2 && _mode == PasswordMode.Set)
            {
                for (int i = 1; i < _givenPassword.Count; i++)
                {
                    g.DrawLine(new Pen(Color.Red, 10), _circle[_givenPassword[i - 1]].Center, _circle[_givenPassword[i]].Center);
                }
            }

        }
        private void NewPasswordButton_Click(object sender, EventArgs e)
        {
            _givenPassword.Clear();
            _enteredPassword.Clear();
            Draw();
            _mode = PasswordMode.Set;
            PasswordLabel.Text = null;
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            Panel.Capture = false;
            _enteredPassword.Clear();
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Panel.Capture == true && _mode == PasswordMode.Enter)
            {
                int xCoordinate = e.X;
                int yCoordinate = e.Y;
                for (int i = 0; i < 9; i++)
                {
                    int dx = _circle[i].Center.X - xCoordinate;
                    int dy = _circle[i].Center.Y - yCoordinate;
                    int radius = _circle[i].Radius;
                    if (dx * dx + dy * dy <= radius * radius)
                    {
                        if (!_enteredPassword.Contains(i))
                        {
                            DoExtraSelection(0, 1, 2, i);
                            DoExtraSelection(3, 4, 5, i);
                            DoExtraSelection(6, 7, 8, i);
                            DoExtraSelection(0, 4, 8, i);
                            DoExtraSelection(2, 4, 6, i);
                            _enteredPassword.Add(i);
                            Draw();
                            SetLabel.Text = null;
                            for (int j = 0; j < _enteredPassword.Count; j++)
                            {
                                SetLabel.Text += _enteredPassword[j] + 1;
                                SetLabel.Text += " ";
                            }
                            if (_enteredPassword.Count == _givenPassword.Count)
                            {
                                var isPasswordCorrect = IsPasswordCorrect();
                                if (isPasswordCorrect)
                                {
                                    MessageBox.Show("Пароль верный!");
                                    _enteredPassword.Clear();
                                    Draw();
                                    SetLabel.Text = null;
                                }
                                else
                                {
                                    MessageBox.Show("Пароль неверный!");
                                    _enteredPassword.Clear();
                                    Draw();
                                    SetLabel.Text = null;
                                }
                            }
                        }
                    }
                }
            }
            else if (Panel.Capture == true && _mode == PasswordMode.Set)
            {
                int xCoordinate = e.X;
                int yCoordinate = e.Y;
                for (int i = 0; i < 9; i++)
                {
                    int dx = _circle[i].Center.X - xCoordinate;
                    int dy = _circle[i].Center.Y - yCoordinate;
                    int radius = _circle[i].Radius;
                    if (dx * dx + dy * dy <= radius * radius)
                    {
                        if (!_givenPassword.Contains(i))
                        {
                            DoExtraSelection(0, 1, 2, i);
                            DoExtraSelection(3, 4, 5, i);
                            DoExtraSelection(6, 7, 8, i);
                            DoExtraSelection(0, 4, 8, i);
                            DoExtraSelection(2, 4, 6, i);
                            _givenPassword.Add(i);
                            Draw();
                            PasswordLabel.Text = null;
                            for (int j = 0; j < _givenPassword.Count; j++)
                            {
                                PasswordLabel.Text += _givenPassword[j] + 1;
                                PasswordLabel.Text += " ";
                            }
                            if (_givenPassword.Count == 5)
                            {
                                MessageBox.Show("Новый пароль введён!");
                                _mode = PasswordMode.Enter;
                                Panel.CreateGraphics().Clear(Color.White);
                                Draw();
                            }
                        }
                    }
                }
            }
        }

        private void DoExtraSelection(int leftNumber, int extraNumber, int rightNumber, int currentNumber)
        {
            if (_enteredPassword.Count == 0 || _enteredPassword.Contains(extraNumber))
                return;

            if (_enteredPassword[^1] == leftNumber && currentNumber == rightNumber
              || _enteredPassword[^1] == rightNumber && currentNumber == leftNumber)
            {
                _enteredPassword.Add(extraNumber);
            }
        }

        private bool IsPasswordCorrect()
        {
            for (int k = 0; k < 5; k++)
            {
                if (_enteredPassword[k] != _givenPassword[k])
                    return false;
            }
            return true;
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _enteredPassword.Clear();
                Panel.Capture = true;
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllLines("password.txt", _givenPassword.ConvertAll(x => x.ToString()));
        }
    }
}