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

namespace Wpf_OnRenderAni03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // vector to add 'speed' to the X,Y 
        //  component of the position of the ball
        //private Vector speed = new Vector(2, 3);
        private Vector speed = new Vector(0, 3);
        private Vector ballPosition = new Vector();

        public MainWindow()
        {
            InitializeComponent();

            // handle the motion and update the
            //  position of the ball here
            //CompositionTarget.Rendering += MoveBall;
            CompositionTarget.Rendering += Fall;
        }

        void MoveBall(object sender, EventArgs e)
        {
  
            // get the position of the ball
            this.ballPosition.X = (Double)(this.myBall.GetValue(Canvas.LeftProperty));
            this.ballPosition.Y = (Double)(this.myBall.GetValue(Canvas.TopProperty));
  
            // test to see if the ball has gone beyond the
            //  bounds of the application
            // as soon as it hits one of the edges, reverse
            //  the speed component to basically bounce the
            //  ball off the edges
            // NOTE: no test has been done if the ball hit
            //  any of the 4 corners where the ball is touching
            //  both the horizontal and vertical edges of the app
            // test left and right
            if (this.ballPosition.X <= 0 || this.ballPosition.X > 
                this.layoutRoot.ActualWidth - this.myBall.Width)
                this.speed.X *= -1;
            // test top and bottom
            if (this.ballPosition.Y <=0 || this.ballPosition.Y > 
                this.layoutRoot.ActualHeight - this.myBall.Height)
            {
                this.speed.Y *= -1;
            }
  
            // update the ball position using the speed
            Canvas.SetLeft(this.myBall, ballPosition.X + speed.X);
            Canvas.SetTop(this.myBall, ballPosition.Y + speed.Y);
        }

        void Fall(object sender, EventArgs e)
        {

            // get the position of the ball
            this.ballPosition.X = (Double)(this.myBall.GetValue(Canvas.LeftProperty));
            this.ballPosition.Y = (Double)(this.myBall.GetValue(Canvas.TopProperty));

            if (this.ballPosition.X <= 0 || this.ballPosition.X >
                this.layoutRoot.ActualWidth - this.myBall.Width)
                this.speed.X *= -1;
            // test top and bottom
            if (this.ballPosition.Y <= 0 || this.ballPosition.Y >
                this.layoutRoot.ActualHeight - this.myBall.Height)
            {
                this.speed.Y *= -1;
            }

            // update the ball position using the speed
            Canvas.SetLeft(this.myBall, ballPosition.X + speed.X);
            Canvas.SetTop(this.myBall, ballPosition.Y + speed.Y);
        }
    }

}
