using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Transitionals.Transitions;

namespace QQLogin
{
	/// <summary>
	/// WinLogin.xaml 的交互逻辑
	/// </summary>
	public partial class WinLogin : Window
	{
		UCMain ucMain = new UCMain();
		UCSet ucSet = new UCSet();
		RotateTransition rtLeft;
		RotateTransition rtRight;

		#region 构造函数
		public WinLogin()
		{
			this.InitializeComponent();

			// 在此点之下插入创建对象所需的代码。

			if (GetRunningInstance() != null)
			{
				MessageBox.Show("程序已经运行");
				App.Current.Shutdown();
			}
		}
		#endregion

		#region 业务
		/// <summary>
		/// 检测是否已有实例在运行
		/// </summary>
		/// <returns></returns>
		static System.Diagnostics.Process GetRunningInstance()
		{
			var current = System.Diagnostics.Process.GetCurrentProcess();
			var processes = System.Diagnostics.Process.GetProcessesByName(current.ProcessName);
			foreach (var process in processes)
			{
				if (process.Id != current.Id)
					if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
						return process;
			}
			return null;
		}

		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//string user = tbUser.Text.Trim();
			//string pwd = MD5.GetPassword16(pb.Password);
			//if (bll.LoginSystem(user, pwd))
			//{
				//BeginEnterAnimation();
				BeginEnterHideAnimation(false);
			//}
			//else
			//{
			//    MessageBox.Show("用户名密码错误，或没有权限，请联系管理员。", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
			//}
			//tbUser.Focus();
		}

		/// <summary>
		/// 登录窗体逐渐缩小动画
		/// </summary>
		private void BeginEnterAnimation()
		{
			NameScope.SetNameScope(this, new NameScope());
			ScaleTransform st = this.RenderTransform as ScaleTransform;
			this.RegisterName("scale", st);


			Storyboard sb = new Storyboard();
			sb.Completed += (s, e) =>
			{
				this.Hide();
				new MainWindow().Show();
			};

			DoubleAnimation daX = new DoubleAnimation();
			daX.To = 0;
			daX.Duration = TimeSpan.FromSeconds(0.3);

			DoubleAnimation daY = new DoubleAnimation();
			daY.To = 0;
			daY.Duration = TimeSpan.FromSeconds(0.3);

			Storyboard.SetTargetName(daX, "scale");
			Storyboard.SetTargetProperty(daX, new PropertyPath(ScaleTransform.ScaleXProperty));
			Storyboard.SetTargetName(daY, "scale");
			Storyboard.SetTargetProperty(daY, new PropertyPath(ScaleTransform.ScaleYProperty));

			sb.Children.Add(daX);
			sb.Children.Add(daY);

			sb.Begin(this);

			//ST.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(1))));
			//ST.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(1))));
		}

		/// <summary>
		/// 仿QQ2013关闭窗体动画
		/// </summary>
		private void BeginEnterHideAnimation(bool isQuit)
		{
			Storyboard sb = this.FindResource("STHide") as Storyboard;

			if (isQuit)
			{
				sb.Completed += (s, e) =>
				{
					this.Close();
				};
			}
			else
			{
				sb.Completed += (s, e) =>
				{
					this.Hide();
					new MainWindow().Show();
				};
			}
			
			sb.Begin();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//this.Opacity = 0;
			//this.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(1, TimeSpan.FromSeconds(0.6)));
			this.transcMain.Content = ucMain;
			ucMain.GoSet += new Action(ucMain_GoSet);
			ucSet.GoMain += new Action(ucSet_GoMain);
			rtLeft = new RotateTransition();
			rtLeft.Direction = RotateDirection.Left;
			rtLeft.Angle = 0;
			rtLeft.FieldOfView = 20;
			rtLeft.Duration = TimeSpan.FromSeconds(0.5);
			rtRight = new RotateTransition();
			rtRight.Direction = RotateDirection.Right;
			rtRight.Angle = 0;
			rtRight.FieldOfView = 20;
			rtRight.Duration = TimeSpan.FromSeconds(0.5);
		}

		void ucSet_GoMain()
		{
			this.transcMain.Transition = rtLeft;
			this.transcMain.Content = ucMain;
		}

		void ucMain_GoSet()
		{
			this.transcMain.Transition = rtRight;
			this.transcMain.Content = ucSet;
		}

		private void Window_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				this.Close();
			}
		}

		

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}
		
		private void Window_MouseEnter(object sender, MouseEventArgs e)
		{
			//btnCl.Visibility = System.Windows.Visibility.Visible;
			//btnSt.Visibility = System.Windows.Visibility.Visible;
		}

		private void Window_MouseLeave(object sender, MouseEventArgs e)
		{
			//btnCl.Visibility = System.Windows.Visibility.Hidden;
			//btnSt.Visibility = System.Windows.Visibility.Hidden;
		}
		#endregion
	}
}