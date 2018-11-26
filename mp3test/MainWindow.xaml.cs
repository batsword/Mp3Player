using mp3test.使用API播放音乐;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace mp3test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //SoundPlayer sound = new SoundPlayer("曼波左.mp3");
            //sound.Play();

            MP3Player mp3 = new MP3Player();
            //设置要播放的文件   
            mp3.FilePath = "曼波左.mp3";
            //播放   
            mp3.Play();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            MP3Player mp3 = new MP3Player();
            //设置要播放的文件   
            mp3.FilePath = "曼波右.mp3";
            //播放   
            mp3.Play();
        }
    }
}
