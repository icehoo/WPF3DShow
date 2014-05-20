using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Simple3DAnimation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
        }

        private void buton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Media3D.RotateTransform3D my = new System.Windows.Media.Media3D.RotateTransform3D(new System.Windows.Media.Media3D.AxisAngleRotation3D(new System.Windows.Media.Media3D.Vector3D(0, 1, 0), 1));
            System.Windows.Media.Animation.Vector3DAnimation myve = new System.Windows.Media.Animation.Vector3DAnimation(new System.Windows.Media.Media3D.Vector3D(-1,-1,-1),new Duration(TimeSpan.FromSeconds(10)));
            myve.RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever;
            my.Rotation.BeginAnimation(System.Windows.Media.Media3D.AxisAngleRotation3D.AxisProperty,myve);
            
        }
    }
}
