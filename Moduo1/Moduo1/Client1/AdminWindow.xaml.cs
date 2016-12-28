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
using System.Windows.Shapes;
using Common;
using System.ServiceModel;

namespace Client1
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        User user = new User();

        public AdminWindow(User u)
        {
            InitializeComponent();

            user = u;

            textBox.Text = u.Username;          //personal info
            textBox_Copy.Text = u.Password;
            textBox_Copy1.Text = u.Email;

            roleComboBox.ItemsSource = Enum.GetNames(typeof(Roles));    //add employee

            foreach (User usr in MainWindow.proxy.GetAllEmployees())
            {
                listOfEmployees.Items.Add(usr.Username);
            }           
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)    
        {
            User u1 = new User();
            u1.Username = textBox3.Text;
            u1.Password = textBox3_Copy.Text;
            u1.Email = textBox3_Copy1.Text;
            u1.Role = (Roles)roleComboBox.SelectedIndex;

            MainWindow.proxy.AddUser(u1);   
        }

        private void editPersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            User userEdit = new User();

            userEdit.Username = textBox.Text;
            userEdit.Password = textBox_Copy.Text;
            userEdit.Email = textBox_Copy1.Text;

            MainWindow.proxy.EditUser(user, userEdit);
        }

        private void listOfEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User u = new User();
            u = MainWindow.proxy.GetUser(listOfEmployees.SelectedItem.ToString());
            textBox2.Text = u.Username;
            textBox2_Copy.Text = u.Password;
            textBox2_Copy1.Text = u.Email;
            textBox2_Copy2.Text = u.Role.ToString();
        }
  
    }
}