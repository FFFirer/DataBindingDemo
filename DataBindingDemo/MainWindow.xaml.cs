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

namespace DataBindingDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public FriendList friends;
        public ChatList chats;
        public NoticeList notices;
        public MainWindow()
        {
            friends = new FriendList
            {
                new Friend{UserId = "1234", UserName="wang", IP="192.168.1.1", status=Status.Online},
                new Friend{UserId = "2345", UserName="ming", IP="192,168.1.2", status=Status.Online},
                new Friend{UserId = "3456", UserName="gao", IP="192.168.1.3", status=Status.Offline}

            };
            chats = new ChatList
            {
                new Chat{SenderId = "1234", ReceiverId = "1111", Content = "测试测试测试测试测试测试"},
                new Chat{SenderId = "2345", ReceiverId = "1111", Content = "测试测试测试测试测试"},
                new Chat{SenderId = "3456", ReceiverId = "1111", Content= "测试测试测试测试"}
            };
            notices = new NoticeList
            {
                new Notice{UserId = "5678"},
                new Notice{UserId = "4567"}
            };

            InitializeComponent();

            this.gChat.DataContext = chats;
            this.gFriend.DataContext = friends;
            this.gNotice.DataContext = notices;
        }

        #region 测试用按钮
        private void btnChatAddOne_Click(object sender, RoutedEventArgs e)
        {
            ellChat.Visibility = (ellChat.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Visible;
            chats.Add(new Chat { SenderId = "8888", ReceiverId = "6666", Content = "测试测试" });
        }

        private void btnChatDelOne_Click(object sender, RoutedEventArgs e)
        {
            chats.Remove(chats.Where(p => p.SenderId.Equals("8888")).FirstOrDefault());
        }

        private void btnFriendAddOne_Click(object sender, RoutedEventArgs e)
        {
            ellFriend.Visibility = (ellFriend.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Visible;
            friends.Add(new Friend { UserId = "8888", UserName = "测试", IP = "192.168.1.1", status = Status.Offline });
        }

        private void btnNoticeAddOne_Click(object sender, RoutedEventArgs e)
        {
            ellNotice.Visibility = (ellNotice.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Visible;
            notices.Add(new Notice { UserId="7777" });
        }

        private void btnFriendDelOne_Click(object sender, RoutedEventArgs e)
        {
            friends.Remove(friends.Where(p => p.UserId.Equals("8888")).FirstOrDefault());
        }

        private void btnNoticeDelOne_Click(object sender, RoutedEventArgs e)
        {
            notices.Remove(notices.Where(p => p.UserId.Equals("7777")).FirstOrDefault());
        }
        #endregion
    }

    //[ValueConversion(typeof(string), typeof(string))]
    //public class Id2Name : IValueConverter
    //{
    //    public object Convert(object value, Type TargetType)
    //    {
    //        if(TargetType != typeof(string)) { return null; }

    //    }
    //    public object ConvertBack(object value, Type targetType)
    //    {
    //        if(targetType != typeof(string)) { return null; }
    //    }
    //}
}
