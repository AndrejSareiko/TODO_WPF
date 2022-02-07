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

namespace TODO
{
    public partial class AddPage : Window
    {
        TODOEntities db = new TODOEntities();
        public AddPage()
        {
            InitializeComponent();
        }

        // Adds new task to db and reloads the list
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskList newTask = new TaskList()
            {
                task = newTaskText.Text
            };

            db.TaskLists.Add(newTask);
            db.SaveChanges();

            MainWindow.dataGrid.ItemsSource = db.TaskLists.ToList();
            this.Hide();
        }
    }
}
