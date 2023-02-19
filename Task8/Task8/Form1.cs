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
        List<PasswordNumber> _givenPassword = new List<PasswordNumber>();
        List<PasswordNumber> _enteredPassword = new List<PasswordNumber>();
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
            _givenPassword.Add(PasswordNumber.One);
            _givenPassword.Add(PasswordNumber.Two);
            _givenPassword.Add(PasswordNumber.Three);
            _givenPassword.Add(PasswordNumber.Six);
            _givenPassword.Add(PasswordNumber.Nine);
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
            Graphics g = Panel.CreateGraphics();
            for (int i = 0; i < 9; i++)
            {
                g.FillEllipse(Brushes.Blue, _circle[i].Center.X - _circle[i].Radius, _circle[i].Center.Y - _circle[i].Radius, _circle[i].Radius, _circle[i].Radius);
            }
            for (int i = 0; i < _givenPassword.Count; i++)
            {
                PasswordLabel.Text += _givenPassword[i];
                PasswordLabel.Text += " ";
            }

        }
        private void NewPasswordButton_Click(object sender, EventArgs e)
        {

        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            Panel.Capture = false;
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

                        if (_enteredPassword.Count == 0 || _enteredPassword[_enteredPassword.Count - 1] != _circle[i].Number)
                        {
                            _enteredPassword.Add(_circle[i].Number);
                        }
                    }
                }
                for (int i = 0; i < _enteredPassword.Count; i++)
                {
                    SetLabel.Text += _enteredPassword[i];
                    SetLabel.Text += " ";
                }
            }

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
    }
}