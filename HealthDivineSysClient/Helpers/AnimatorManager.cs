using System;
using System.Timers; 
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace HealthDivineSysClient.Helpers
{
    public static class AnimatorManager
    {
        public static void DownCortainAnimation(Border border, double height)
        {
            double initialHeight = border.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = initialHeight;
            heightAnimation.To = height;
            heightAnimation.Duration = TimeSpan.FromSeconds(.5);

            heightAnimation.Completed += (sender, e) =>
            {
                if (height != 0)
                {
                    //DownCortainAnimation(border, 0);
                }
            }; 

            border.BeginAnimation(Border.HeightProperty, heightAnimation);

        }

        public static void FadeIn(Grid grid, double durationInSeconds)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(durationInSeconds)
            };

            grid.BeginAnimation(UIElement.OpacityProperty, animation);
        }

    }
}
