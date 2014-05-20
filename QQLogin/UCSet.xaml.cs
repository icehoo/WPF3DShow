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

namespace QQLogin
{
	/// <summary>
	/// 作者：xxh 
	/// 时间：2014-05-20 10:25:23
	/// 版本：V1.0.0 	 
	/// </summary>
	public partial class UCSet : UserControl
	{
		public event Action GoMain;
		public void OnGoMain()
		{
			if (GoMain != null)
			{
				GoMain.Invoke();
			}
		}

		public UCSet()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OnGoMain();
		}
	}
}
