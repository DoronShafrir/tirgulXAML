using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
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

namespace Chater13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            entries = new ObservableCollection<string>();
            InitializeComponent();
           
             
        }
        private ObservableCollection<string> entries;

        public ObservableCollection<string> Entries
            { 
             get{ return entries; }
             set{entries = value; }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Entries.Add(textEntry.Text);
            textEntry.Clear();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //string SelectedItem = (string)lvEntries.SelectedItem;
            //Entries.Remove(SelectedItem);

            var items = lvEntries.SelectedItems;
            var result = MessageBox.Show($"Are yousure you wnat to delete {items.Count} items", "SELECT", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var array = new ArrayList(items);
                foreach (var item in array)
                    //lvEntries.Items.Remove(item);                    
                    Entries.Remove((string)item);
            }
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Entries.Clear();
        }
    }
}
