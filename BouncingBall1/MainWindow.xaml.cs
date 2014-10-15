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

namespace BouncingBall1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Vector ballPosition = new Vector();

        private double Velocity = 30;
        private double Time = 30;
        private double Gravity = 0.8;

        private double DEC_FACTOR = 0.8;
        private double CANVAS_HEIGHT = 461;
        private double ABOVE_FLOOR = 3;

        public MainWindow()
        {
            InitializeComponent();            
            CompositionTarget.Rendering += Bounce;
        }

        void Bounce(object sender, EventArgs e)
        {
            if (this.Velocity < 0.01)
            {
                //stop all movement
                return;
            }

            //System.Threading.Thread.Sleep(20);
            // get the position of the ball
            this.ballPosition.X = (Double)(this.myBall.GetValue(Canvas.LeftProperty));
            this.ballPosition.Y = CANVAS_HEIGHT - CalculateY();

            // test top and bottom
            if (this.ballPosition.Y > CANVAS_HEIGHT)
            {
                this.Velocity *= DEC_FACTOR;
                Time = 0;
            }

            // update the ball position using the speed
            Canvas.SetLeft(this.myBall, ballPosition.X);
            Canvas.SetTop(this.myBall, ballPosition.Y - (this.myBall.Height + ABOVE_FLOOR));
            Time++;
        }

        double CalculateY()
        {
            //V * T - ((GT*T)/2)
            double result = 
                Velocity * Time - ((Gravity * Time * Time) / 2);
            return result;
        }
    }
}
