using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DataBindingDemo
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private int allchatwaitreads { get; set; }
        public int AllChatWaitReads
        {
            get { return this.allchatwaitreads; }
            set
            {
                if(allchatwaitreads == value) { return; }
                allchatwaitreads = value;
                Notify("allchatwaitreads");
            }
        }
        private int allfriendwaitreads { get; set; }
        public int AllFriendWaitReads
        {
            get { return this.allfriendwaitreads; }
            set
            {
                if (allfriendwaitreads == value) { return; }
                allfriendwaitreads = value;
                Notify("allfriendwaitreads");
            }
        }
        private int allnoticewaitreads { get; set; }
        public int AllNoticeWaitReads
        {
            get { return this.allnoticewaitreads; }
            set
            {
                if (allnoticewaitreads == value) { return; }
                allnoticewaitreads = value;
                Notify("allnoticewaitreads");
            }
        }
    }

    //聊天列表
    public class ChatList : ObservableCollection<Chat>, INotifyPropertyChanged
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

    //聊天记录
    public class MsgList : ObservableCollection<PerMsg>
    {

    }

    public class Chat : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string SenderId { get; set; }

        public string sName { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }

        public MsgList Msgs { get; set; }

        public void AddMsg(PerMsg msg)
        {
            Msgs.Add(msg);
        }

        private int waitreads { get; set; }
        public int WaitReads
        {
            get { return waitreads; }
            set
            {
                if (this.waitreads == value) { return; }
                this.waitreads = value;
                Notify("waitreads");
            }
        }

        public Chat(string id, string name, string receId, string content, MsgList ml, int wait)
        {
            this.SenderId = id;
            this.sName = name;
            this.ReceiverId = receId;
            this.Content = content;
            this.Msgs = ml;
            this.WaitReads = wait;
        }
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

    public class PerMsg
    {
        public string SenderName { get; set; }
        public string Msg { get; set; }
        public PerMsg() { }
        public PerMsg(string SenderName, string Msg)
        {
            this.SenderName = SenderName;
            this.Msg = Msg;
        }
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
