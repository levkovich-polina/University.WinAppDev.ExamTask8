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
        List<PasswordNumber> _givenPassword = new List<PasswordNumber>();
        List<PasswordNumber> _enteredPassword = new List<PasswordNumber>();
        private enum PasswordNumber
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
            MakingCircles();
            Draw();   
        }
        private void MakingCircles()
        {
            int width = Panel.ClientSize.Width;
            int height = Panel.ClientSize.Height;
            for (int i = 40; i < width; i += width / 3)
            {
                for (int j = 40; j < height; j += height / 3)
                {
                    Circle circle = new Circle(new Point(i, j), width / 8);
                    _circles.Add(circle);
                }
            }
        }
        private void Draw()
        {
            Graphics g = CreateGraphics();
            int width = Panel.ClientSize.Width;
            int height = Panel.ClientSize.Height;
            for (int i = 40; i < width; i += width / 3)
            {
                for (int j = 40; j < height; j += height / 3)
                {
                    g.FillEllipse(Brushes.Blue, i, j, width / 8, width / 8);
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