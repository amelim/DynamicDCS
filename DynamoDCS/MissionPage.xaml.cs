using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DynamoDCS
{
    public sealed partial class MissionPage : Page
    {
        bool mapClicked = false;
        PointerPoint mouseClickOrigin;
        public MissionPage()
        {
            this.InitializeComponent();
        }

        private void scrollViewer_MouseLeftButtonDown(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
            mapClicked = true;
            mouseClickOrigin = e.GetCurrentPoint(Map);
        }

        private void scrollViewer_MouseLeftButtonRelease(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
            mapClicked = false;
        }

        private void scrollViewer_MouseLost(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
            mapClicked = false;
        }

        private void scrollViewer_MouseMoved(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
            if (mapClicked)
            {
                PointerPoint mousePoint = e.GetCurrentPoint(Map);
                double curX = MapViewer.HorizontalOffset;
                double curY = MapViewer.VerticalOffset;

                MapViewer.ChangeView(
                    curX - (mousePoint.Position.X - mouseClickOrigin.Position.X),
                    curY - (mousePoint.Position.Y - mouseClickOrigin.Position.Y),
                    MapViewer.ZoomFactor);
            }
        }

        private void scrollViewer_MouseWheel(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
