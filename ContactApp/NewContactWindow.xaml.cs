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
using System.Windows.Shapes;
using ContactApp.Model;
using SQLite;

namespace ContactApp
{
	/// <summary>
	/// NewContactWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class NewContactWindow : Window
	{
		public NewContactWindow()
		{
			InitializeComponent();
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			var contact = new Contact()
			{
				Name = nameTextBox.Text,
				Email = emailTextBox.Text,
				Phone = phoneNumberTextBox.Text
			};

			using (var connection = new SQLiteConnection(App.databasePath))
			{
				connection.CreateTable<Contact>();
				connection.Insert(contact);
			}

			Close();
		}
	}
}
