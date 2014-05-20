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
using System.Windows.Media.Animation;

namespace QQLogin
{
	/// <summary>
	/// 作者：xxh 
	/// 时间：2014-05-20 10:25:04
	/// 版本：V1.0.0 	 
	/// </summary>
	public partial class UCMain : UserControl
	{
		public event Action GoSet;
		public void OnGoSet()
		{
			if (GoSet != null)
			{
				GoSet.Invoke();
			}
		}

		public UCMain()
		{
			InitializeComponent();
		}

		private void tbUser_GotFocus(object sender, RoutedEventArgs e)
		{
			//tbUser.SelectionStart = tbUser.Text.Length;
		}

		private void pb_GotFocus(object sender, RoutedEventArgs e)
		{
			//pb.SelectAll();
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			BeginEnterHideAnimation(true);
		}

		private void btnSet_Click(object sender, RoutedEventArgs e)
		{
			//new WinSet().ShowDialog();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//BeginEnterHideAnimation(false);
			OnGoSet();
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
					//this.Close();
				};
			}
			else
			{
				sb.Completed += (s, e) =>
				{
					//this.Hide();
					new MainWindow().Show();
				};
			}

			sb.Begin();
		}
	}
}
