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

        public Form1()
        {
            InitializeComponent();
            MakingCircles();
            Draw();

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
            var radius = 20;
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
                g.FillEllipse(Brushes.Blue, _circle[i].Center.X, _circle[i].Center.Y, _circle[i].Radius, _circle[i].Radius);
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

        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel.Capture = true;
        }
    }
}