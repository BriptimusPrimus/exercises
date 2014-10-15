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

using System.Windows.Media.Animation;
using System.Threading;


namespace BouncingBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool started = false;

        private double LAPSE = 2;
        private double FLOOR;
        private double BOUNCE_DECREASE = 50;
        private bool Falling;

        public MainWindow()
        {
            InitializeComponent();
            FLOOR = myCanvas.Height - Wilson.Height;
        }

        private void Ellipse_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (!started)
            {
                //Only alow the event once
                started = true;
                //fall on first cycle 
                Falling = true;

                //define floor                
                double originalHeight = Canvas.GetTop(Wilson);                

                //while (true)
                {
                    //Thread.Sleep(TimeSpan.FromSeconds(LAPSE));                    
                    double currTop = originalHeight;

                    TranslateTransform trans = new TranslateTransform();
                    Wilson.RenderTransform = trans;
                    DoubleAnimation animation = new DoubleAnimation();

                    animation.From = currTop;
                    animation.To = FLOOR;
                    animation.Duration = new Duration(TimeSpan.FromSeconds(LAPSE));

                    animation.Completed += (o, s) =>
                    {
                        Falling = !Falling;
                        if (Falling)
                        {
                            animation.From = currTop;
                            animation.To = FLOOR;                                    
                        }
                        else
                        {
                            animation.From = FLOOR;
                            currTop = currTop + BOUNCE_DECREASE;
                            animation.To = currTop;
                        }
                        if (animation.From != animation.To)
                        {
                            trans.BeginAnimation(TranslateTransform.YProperty, animation);
                        }
                    };

                    trans.BeginAnimation(TranslateTransform.YProperty, animation);
                }

            }
        }


        public void MoveTo(Shape target, double from, double newY, double timeLapse)
        {

        } 
    }  

    
}
