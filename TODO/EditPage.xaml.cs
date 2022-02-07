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
    public partial class EditPage : Window
    {
        TODOEntities db = new TODOEntities();
        int Id;
        public EditPage(int taskId, string taskText)
        {
            InitializeComponent();
            Id = taskId;
            editTaskText.Text = taskText;
        }

        // update selected task
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var r = from t in db.TaskLists
                    where t.id == Id
                    select t;

            TaskList obj = r.SingleOrDefault();
            if (obj != null)
            {
                obj.task = editTaskText.Text;
                db.SaveChanges();
            }

            MainWindow.dataGrid.ItemsSource = db.TaskLists.ToList();
            this.Hide();
        }
    }
}
