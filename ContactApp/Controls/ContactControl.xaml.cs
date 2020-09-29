﻿using System;
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

namespace ContactApp.Controls
{
	/// <summary>
	/// ContactControl.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class ContactControl : UserControl
	{


		public Contact Contact
		{
			get { return (Contact)GetValue(ContactProperty); }
			set { SetValue(ContactProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ContactProperty =
			DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(null, SetText));

		private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ContactControl control)
			{
				control.txtName.Text = (e.NewValue as Contact)?.Name;
				control.txtEmail.Text = (e.NewValue as Contact)?.Email;
				control.txtPhone.Text = (e.NewValue as Contact)?.Phone;
			}

		}


		/*private Contact contact;

		public Contact Contact
		{
			get => contact;
			set
			{
				contact = value;
				txtName.Text = contact.Name;
				txtEmail.Text = contact.Email;
				txtPhone.Text = contact.Phone;
			}
		}*/

		public ContactControl()
		{
			InitializeComponent();
		}
	}
}
