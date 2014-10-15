using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElipseOrbit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double a = 200;
        private double b = 120;
        private double X = -200; //start at the most left point
        private double Y;
        private Vector Center = new Vector(400, 300);
        private Vector Focus = new Vector(100, 0);
        private double CANVAS_HEIGHT = 0;
        private int DIRECTION = 1;
        private double FACTOR = 20;

        private bool SIMULATE_ORBIT = false;

        public MainWindow()
        {
            InitializeComponent();
            CompositionTarget.Rendering += Orbit;
        }

        void Orbit(object sender, EventArgs e)
        {
            if (CANVAS_HEIGHT == 0)
            {
                CANVAS_HEIGHT = this.layoutRoot.ActualHeight;
                if (CANVAS_HEIGHT == 0)
                {
                    //Draw initial position
                    Canvas.SetLeft(this.myBall, 0);
                    Canvas.SetTop(this.myBall, 0);
                    return;
                }
            }

            Y = F(X);
            //calculate center offset
            var drawX = X + Center.X;
            var drawY = (CANVAS_HEIGHT - (Y + Center.Y));

            // update the ball position
            Canvas.SetLeft(this.myBall, drawX);
            Canvas.SetTop(this.myBall, drawY);

            if (SIMULATE_ORBIT)
                X += (FACTOR / Math.Abs(X - Focus.X)) * DIRECTION;
            else
                X += DIRECTION;
            if (X > a || X < -a)
            {
                X = a * DIRECTION;
                DIRECTION *= -1;
                if (SIMULATE_ORBIT)
                    X += (FACTOR / Math.Abs(X - Focus.X)) * DIRECTION;
                else
                    X += DIRECTION;
            }
        }

        double F(double x)
        {
            //y2 = b2 - b2x2/a2
            double result = (b * b) * (1 - ((x * x) / (a * a)));
            result = Math.Sqrt(result);
            return result * DIRECTION;
        }

    }
}
