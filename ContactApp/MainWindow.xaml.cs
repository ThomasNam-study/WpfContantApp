using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		List<Contact> contacts = null;

		public MainWindow()
		{
			InitializeComponent();

			contacts = new List<Contact> ();

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
			using (var connection = new SQLiteConnection(App.databasePath))
			{
				connection.CreateTable<Contact>();

				contacts = (connection.Table<Contact>().ToList()).OrderBy ((c) => c.Name).ToList ();


			}

			if (contacts != null)
			{
				contactListView.ItemsSource = contacts;
			}
		}

		private void TxtSearch_OnTextChanged (object sender, TextChangedEventArgs e)
		{
			var searchText = txtSearch.Text.ToLower();

			var filteredList = contacts.Where ((c) => c.Name.ToLower().Contains (searchText));

			contactListView.ItemsSource = filteredList;
		}

		private void ContactListView_OnSelectionChanged (object sender, SelectionChangedEventArgs e)
		{
			if (contactListView.SelectedItem is Contact contact)
			{
				var updateWindows = new ContactDetailsWindow (contact);

				updateWindows.ShowDialog();

				ReadDatabase ();
			}
			
		}
	}
}
