using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DataBindingDemo
{
    public class ChatViewModel
    {
        
    }

    //聊天列表
    public class ChatList : ObservableCollection<Chat>
    {

    }

    //好友列表
    public class FriendList : ObservableCollection<Friend>
    {

    }

    //通知列表
    public class NoticeList : ObservableCollection<Notice>
    {

    }

    public class Chat
    {
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }
    }

    //每一个好友
    public class Friend
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string IP { get; set; }

        public Status status { get; set; }
    }

    //每一个通知
    public class Notice
    {
        public string UserId { get;set; }
    }

    public enum Status
    {
        No = 0,
        Yes = 1,
        Online = 2,
        Offline = 3,
        Add = 4,
        Remove = 5,
        Agree = 6,
        DisAgree = 7,
        Waiting = 8
    }

        //每一项聊天
        //public class Chat : INotifyPropertyChanged
        //{
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    protected void Notify(string propName)
        //    {
        //        if(this.PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        //        }
        //    }

        //    public string SenderId
        //    {
        //        get { return SenderId; }
        //        set
        //        {
        //            if(this.SenderId == value) { return; }
        //            this.SenderId = value;
        //            Notify("SenderId");
        //        }
        //    }

        //    public string ReceiverId
        //    {
        //        get { return ReceiverId; }
        //        set
        //        {
        //            if(this.ReceiverId == value) { return; }
        //            this.ReceiverId = value;
        //            Notify("ReceiverId");
        //        }
        //    }

        //    public string Content
        //    {
        //        get { return Content; }
        //        set
        //        {
        //            if(this.Content == value) { return; }
        //            this.Content = value;
        //            Notify("Content");
        //        }
        //    }
        //}

    }
