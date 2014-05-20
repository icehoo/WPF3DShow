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
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace V3ViewApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // 设置快捷键
            KeyBinding forwBind = new System.Windows.Input.KeyBinding();
            forwBind.Command = new ForwCommand();
            forwBind.CommandParameter = ar;
            forwBind.Key = System.Windows.Input.Key.Right;
            this.InputBindings.Add(forwBind);
            KeyBinding backBind = new System.Windows.Input.KeyBinding();
            backBind.Command = new BackCommand();
            backBind.CommandParameter = ar;
            backBind.Key = System.Windows.Input.Key.Left;
            this.InputBindings.Add(backBind);

            this.Loaded += (k, k2) =>
                {
                    MessageBox.Show("向右旋转请按右方向键，向左旋转请按左方向键。");
                };
        }
    }

    /// <summary>
    /// 向前移动
    /// </summary>
    public class ForwCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            AxisAngleRotation3D rot = parameter as AxisAngleRotation3D;
            DoubleAnimation d = new DoubleAnimation();
            d.Duration = new Duration(TimeSpan.FromMilliseconds(800));
            d.By = 90d;
            rot.BeginAnimation(AxisAngleRotation3D.AngleProperty, d, HandoffBehavior.Compose);
        }
    }
    /// <summary>
    /// 向后移动
    /// </summary>
    public class BackCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            AxisAngleRotation3D rot = parameter as AxisAngleRotation3D;
            DoubleAnimation d = new DoubleAnimation();
            d.By = -90d;
            d.Duration = new Duration(TimeSpan.FromMilliseconds(800));
            rot.BeginAnimation(AxisAngleRotation3D.AngleProperty, d, HandoffBehavior.Compose);
        }
    }


}
