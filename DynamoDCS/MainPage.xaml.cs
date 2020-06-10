using Microsoft.Toolkit.Uwp.UI.Extensions;
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
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DynamoDCS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        bool mapClicked = false;
        PointerPoint mouseClickOrigin;
        public MainPage()
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
