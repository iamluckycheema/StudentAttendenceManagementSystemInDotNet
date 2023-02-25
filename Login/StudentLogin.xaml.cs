﻿using SQLite;
using Student_Attendence_Management_System.Database;
using Student_Attendence_Management_System.Views;
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

namespace Student_Attendence_Management_System.Login
{
    public partial class StudentLogin : Window
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        //focus on textbox
        private void textStudentID_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtStudentID.Focus();
        }

        private void txtStudentID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStudentID.Text) && txtStudentID.Text.Length > 0)
            {
                textStudentID.Visibility = Visibility.Collapsed;
            }
            else
            {
                textStudentID.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void StudentSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && !string.IsNullOrEmpty(txtStudentID.Text))
            {
                using (var conn = new SQLiteConnection(App.DatabasePath))
                {
                    var student = conn.Table<Student>().FirstOrDefault(s => s.RollNumber == txtStudentID.Text);

                    if (student != null && student.Password == txtPassword.Password)
                    {
                        StudentView view = new StudentView(student);
                        view.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password or Student ID is incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill the Details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
