namespace Task8
{
    public partial class Form1 : Form
    {
        public class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
            public Circle(Point point, int radius)
            {
                Center = point;
                Radius = radius;
            }
        }
        List<Circle> _circles = new List<Circle>();
        int _radius;
        List<Password> _givenPassword = new List<Password>();
        List<Password> _enteredPassword = new List<Password>();
        private enum Password
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
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            int width = Panel.ClientSize.Width;
            int height = Panel.ClientSize.Height;
            _radius = width / 8;
            for (int i = 40; i < width; i += width / 3)
            {
                for (int j = 40; j < height; j += height / 3)
                {
                    e.Graphics.FillEllipse(Brushes.Blue, i, j, _radius, _radius);
                    Circle circle = new Circle(new Point(i, j), _radius);
                    _circles.Add(circle);
                }
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