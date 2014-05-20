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
using Transitionals;
using System.Reflection;
using System.Collections.ObjectModel;
using Transitionals.Transitions;

namespace Transitionals_Demo
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		UserControl1 w1 = new UserControl1();
		UserControl2 w2 = new UserControl2();
		private ObservableCollection<Type> transitionTypes = new ObservableCollection<Type>();

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadTransitions(Assembly.GetAssembly(typeof(Transition)));
			mainp.Content = w1;
		}

		public void LoadTransitions(Assembly assembly)
		{

			foreach (Type type in assembly.GetTypes())
			{
				// Must not already exist
				if (transitionTypes.Contains(type)) { continue; }

				// Must not be abstract.
				if ((typeof(Transition).IsAssignableFrom(type)) && (!type.IsAbstract))
				{
					transitionTypes.Add(type);
				}
			}
		}

		void tmp()
		{
			//所有的变换
			//Transitionals.Transitions.StarTransition        //星
			//Transitionals.Transitions.RotateTransition      //3d旋转
			//Transitionals.Transitions.VerticalWipeTransition//下拉
			//Transitionals.Transitions.PageTransition        //翻页
			//Transitionals.Transitions.RollTransition        //旋转出
			//Transitionals.Transitions.DiamondsTransition    //棋盒棱形
			//Transitionals.Transitions.VerticalBlindsTransition //垂直百叶窗
			//Transitionals.Transitions.HorizontalWipeTransition //左拉
			//Transitionals.Transitions.FadeAndBlurTransition    //淡入
			//Transitionals.Transitions.ExplosionTransition      //球形散开
			//Transitionals.Transitions.CheckerboardTransition   //棋盒方形
			//Transitionals.Transitions.TranslateTransition      //飞入
			//Transitionals.Transitions.RotateWipeTransition     //旋转擦除
			//Transitionals.Transitions.MeltTransition           //柱状
			//Transitionals.Transitions.DiagonalWipeTransition   //柱状
			//Transitionals.Transitions.FlipTransition           //单面翻书
			//Transitionals.Transitions.DotsTransition           //球状棋盒
			//Transitionals.Transitions.FadeAndGrowTransition    //淡入
			//Transitionals.Transitions.DoubleRotateWipeTransition //双线擦除
			//Transitionals.Transitions.DoorTransition             //门状
			//Transitionals.Transitions.HorizontalBlindsTransition //水平百叶窗
			//Transitionals.Transitions.FadeTransition             //溶解

			// Transition t;
			Transitionals.Transitions.RotateTransition t = new Transitionals.Transitions.RotateTransition();

			mainp.Transition = t;
		}

		void selTrans()
		{
			int m_nIndex = 0;
			m_nIndex = new Random().Next(0, transitionTypes.Count);

			Type transitionType = transitionTypes[m_nIndex];

			Transition t = (Transition)Activator.CreateInstance(transitionType);

			mainp.Transition = t;
		}

		private void ChangeContent()
		{
			UserControl uc = mainp.Content as UserControl;
			if (uc != null)
			{
				if (uc.GetType() == typeof(UserControl1))
				{
					mainp.Content = w2;
				}
				else
				{
					mainp.Content = w1;
				}
			}
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new StarTransition();//星
			ChangeContent();
		}

		private void button2_Click(object sender, RoutedEventArgs e)
		{
			RotateTransition t = new RotateTransition();
			t.Angle = 0;
			t.FieldOfView = 10;
			mainp.Transition = t;//3d旋转
			ChangeContent();
		}

		private void button3_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new VerticalWipeTransition();//下拉
			ChangeContent();
		}

		private void button4_Click(object sender, RoutedEventArgs e)
		{
			PageTransition p = new PageTransition();
			p.Duration = TimeSpan.FromSeconds(0.5);
			mainp.Transition = p;//软翻页
			ChangeContent();
		}

		private void button5_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new RollTransition();//旋转出
			ChangeContent();
		}

		private void button6_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new DiamondsTransition();//棋盒棱形
			ChangeContent();
		}

		private void button7_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new VerticalBlindsTransition();//垂直百叶窗
			ChangeContent();
		}

		private void button8_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new HorizontalWipeTransition();//右拉
			ChangeContent();
		}

		private void button9_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new FadeAndBlurTransition();//屏内淡入
			ChangeContent();
		}

		private void button10_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new ExplosionTransition();//球形散开
			ChangeContent();
		}

		private void button11_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new CheckerboardTransition();//棋盒方形
			ChangeContent();
		}

		private void button12_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new TranslateTransition();//飞入
			ChangeContent();
		}

		private void button13_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new RotateWipeTransition();//旋转擦除
			ChangeContent();
		}

		private void button14_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new MeltTransition();//柱状
			ChangeContent();
		}

		private void button15_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new DiagonalWipeTransition();//斜拉
			ChangeContent();
		}

		private void button16_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new FlipTransition();//硬翻页
			ChangeContent();
		}

		private void button17_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new DotsTransition();//球状棋盒
			ChangeContent();
		}

		private void button18_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new FadeAndGrowTransition();//屏外淡入
			ChangeContent();
		}

		private void button19_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new DoubleRotateWipeTransition();//双线擦除
			ChangeContent();
		}

		private void button20_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new DoorTransition();//门状
			ChangeContent();
		}

		private void button21_Click(object sender, RoutedEventArgs e)
		{
			mainp.Transition = new HorizontalBlindsTransition();//水平百叶窗
			ChangeContent();
		}

		private void button22_Click(object sender, RoutedEventArgs e)
		{
			FadeTransition f = new FadeTransition();
			f.Duration = TimeSpan.FromSeconds(0.5);
			mainp.Transition = f;//溶解
			ChangeContent();
		}
	}
}
