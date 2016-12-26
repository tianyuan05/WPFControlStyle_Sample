using DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFControlStyle
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            data = StatusCollectionClass.Create();
            this.lsitBox.ItemsSource = data;
            seleStr = this.lsitBox.SelectedItem as string;
        }

        private ObservableCollection<string> data;

        public string seleStr;

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Button btn = e.OriginalSource as Button;
            //string str = btn.Tag as string;

            //data.Remove(str);
           NhibernateBase.Init();
        }


    }



    public class StatusCollectionClass
    {
        public static ObservableCollection<string> Create()
        {
            return new ObservableCollection<string>() {
                "在航", "锚泊", 
                "失控", "操作受限", 
                "吃水受限", "靠泊",
                "从事捕鱼", 
                "靠帆船提供动力",
                "预留1", "预留2" };
        }

    }



}
