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
using ContactApp.Model;
using SQLite;

namespace ContactApp
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			ReadDatabase();
		}

		private void OpenNewContact_OnClick(object sender, RoutedEventArgs e)
		{
			var newContact = new NewContactWindow();

			newContact.ShowDialog();

			ReadDatabase();
		}

		void ReadDatabase()
		{
			List<Contact> contacts = null;

			using (var connection = new SQLiteConnection(App.databasePath))
			{
				contacts = connection.Table<Contact>().ToList();
			}

			if (contacts != null)
			{
				contactListView.ItemsSource = contacts;

				/*foreach (var c in contacts)
				{
					contactListView.Items.Add(new ListViewItem()
					{
						Content = c
					});
				}*/
			}
		}
	}
}
