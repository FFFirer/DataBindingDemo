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
        private string chating = null;
        public ChatViewModel model = null;
        public FriendList friends = null;
        public ChatList chats = null;
        public NoticeList notices = null;
        public MainWindow()
        {
            PerMsg p1 = new PerMsg("wang", "ceshi");
            PerMsg p2 = new PerMsg("wang", "ceshi");
            PerMsg p3 = new PerMsg("wang", "ceshi");
            MsgList m1 = new MsgList();
            m1.Add(p1);
            m1.Add(p2);
            m1.Add(p3);

            PerMsg p4 = new PerMsg("ming", "ceshi");
            PerMsg p5 = new PerMsg("ming", "ceshi");
            PerMsg p6 = new PerMsg("ming", "ceshi");
            MsgList m2 = new MsgList();
            m2.Add(p4);
            m2.Add(p5);
            m2.Add(p6);

            PerMsg p7 = new PerMsg("gao", "ceshi");
            PerMsg p8 = new PerMsg("gao", "ceshi");
            PerMsg p9 = new PerMsg("gao", "ceshi");
            MsgList m3 = new MsgList();
            m3.Add(p7);
            m3.Add(p8);
            m3.Add(p9);


            friends = new FriendList
            {
                new Friend{UserId = "1234", UserName="wang", IP="192.168.1.1", status=Status.Online},
                new Friend{UserId = "2345", UserName="ming", IP="192,168.1.2", status=Status.Online},
                new Friend{UserId = "3456", UserName="gao", IP="192.168.1.3", status=Status.Offline}

            };
            
            chats = new ChatList
            {
                //new Chat{SenderId = "1234", sName="wang", ReceiverId = "1111", Content = "测试测试测试测试测试测试", Msgs = m1, WaitReads = 3},
                //new Chat{SenderId = "2345", sName="ming", ReceiverId = "1111", Content = "测试测试测试测试测试", Msgs = m2,WaitReads = 3},
                //new Chat{SenderId = "3456", sName="gao", ReceiverId = "1111", Content= "测试测试测试测试", Msgs = m3,WaitReads = 3}
                new Chat("1234", "wang", "1111", "测试测试测试测试测试测试", m1, 0),
                new Chat("2345", "ming", "1111", "测试测试测试测试测试", m2, 0),
                new Chat("3456", "gao", "1111", "测试测试测试测试", m3, 0),

            };
            notices = new NoticeList
            {
                new Notice{UserId = "5678"},
                new Notice{UserId = "4567"}
            };
            model = new ChatViewModel { AllChatWaitReads = 0, AllFriendWaitReads = 0, AllNoticeWaitReads = 0 };

            InitializeComponent();
            this.tabMain.DataContext = model;
            this.gChat.DataContext = chats;
            this.gFriend.DataContext = friends;
            this.gNotice.DataContext = notices;

            this.listChat.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(listChat_MouseLeftButtonDown), true);
        }

        #region 测试用按钮
        private void btnChatAddOne_Click(object sender, RoutedEventArgs e)
        {

            PerMsg pt1 = new PerMsg("test", "ceshi");
            PerMsg pt2 = new PerMsg("test", "ceshi");
            PerMsg pt3 = new PerMsg("test", "ceshi");
            MsgList mt1 = new MsgList();
            mt1.Add(pt1);
            mt1.Add(pt2);
            mt1.Add(pt3);

            model.AllChatWaitReads += 1;
            //chats.Add(new Chat { SenderId = "8888", sName = "test", ReceiverId = "1111", Content = "测试测试测试测试测试测试", Msgs = mt1 });
            chats.Add(new Chat("8888", "test", "1111", "测试测试测试测试测试测试", mt1, 0));
        }

        private void btnChatDelOne_Click(object sender, RoutedEventArgs e)
        {
            chats.Remove(chats.Where(p => p.SenderId.Equals("8888")).FirstOrDefault());
        }

        private void btnFriendAddOne_Click(object sender, RoutedEventArgs e)
        {
            //ellFriend.Visibility = (ellFriend.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Visible;
            model.AllFriendWaitReads += 1;
            friends.Add(new Friend { UserId = "8888", UserName = "测试", IP = "192.168.1.1", status = Status.Offline });
        }

        private void btnNoticeAddOne_Click(object sender, RoutedEventArgs e)
        {
            //ellNotice.Visibility = (ellNotice.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Visible;
            model.AllNoticeWaitReads += 1;
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

        private void listChat_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (listChat.SelectedIndex == -1)
            {
                return;
            }
            Chat boxItem = (Chat)listChat.SelectedItem;
            chating = boxItem.SenderId;
            MainChat.ItemsSource = boxItem.Msgs;
            int x = boxItem.WaitReads;
            model.AllChatWaitReads -= x;
            boxItem.WaitReads = 0;
            //MessageBox.Show(boxItem.SenderId.ToString() + "\n" + boxItem.Content);
        }

        //private void listChat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (listChat.SelectedIndex == -1)
        //    {
        //        return;
        //    }
        //    Chat boxItem = (Chat)listChat.SelectedItem;
        //    MainChat.ItemsSource = boxItem.Msgs;
        //    //MessageBox.Show(boxItem.SenderId.ToString() + "\n" + boxItem.Content);
        //    listChat.SelectedIndex = -1;
        //}

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtSend.Text = "";
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            PerMsg p = new PerMsg("本机名字", "ceshi");
            Chat boxItem = (Chat)listChat.SelectedItem;
            boxItem.Msgs.Add(p);
            txtSend.Text = "";
        }

        private void btnWangSendOne_Click(object sender, RoutedEventArgs e)
        {
            PerMsg mp = new PerMsg("wang", "ceshi1");
            Chat chat = chats.Where(p => p.sName.Equals("wang")).FirstOrDefault();
            chat.Msgs.Add(mp);
            chat.WaitReads += 1;
            model.AllChatWaitReads += 1;
        }

        private void btnMingSendOne_Click(object sender, RoutedEventArgs e)
        {
            PerMsg mp = new PerMsg("ming", "ceshi");
            Chat chat = chats.Where(p => p.sName.Equals("ming")).FirstOrDefault();
            chat.Msgs.Add(mp);
            chat.WaitReads += 1;
            model.AllChatWaitReads += 1;
        }
    }

}
