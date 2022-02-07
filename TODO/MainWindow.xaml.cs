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

namespace TODO
{
    public partial class MainWindow : Window
    {
        TODOEntities db = new TODOEntities();
        public static DataGrid dataGrid;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        // load and display data
        private void Load() 
        {
            taskGrid.ItemsSource = db.TaskLists.ToList();
            dataGrid = taskGrid;
        }

        // load the edit page with task and id 
        private void btnEditTask_Click(object sender, RoutedEventArgs e)
        {
            int Id = (dataGrid.SelectedItem as TaskList).id;
            string text = (taskGrid.SelectedItem as TaskList).task;
            EditPage Epage = new EditPage(Id,text);
            Epage.ShowDialog();
        }

        // delte row
        private void btnDoneTask_Click(object sender, RoutedEventArgs e)
        {
            int Id = (taskGrid.SelectedItem as TaskList).id;
            var deleteTask = db.TaskLists.Where(t=> t.id == Id).Single();
            db.TaskLists.Remove(deleteTask);
            db.SaveChanges();
            taskGrid.ItemsSource = db.TaskLists.ToList();
        }

        // opens add task pasge
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            AddPage Apage = new AddPage();
            Apage.ShowDialog();
        }
    }
}
