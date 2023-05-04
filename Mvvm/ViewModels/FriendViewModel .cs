using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Mvvm.Models;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;

namespace Mvvm.ViewModels
{
    public class FriendViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FriendsListViewModel lvm;
        public Friend Friend { get; private set; }
        public FriendViewModel()
        {
            Friend = new Friend();
        }
        public FriendsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChaged("ListViewModel");
                }
            }
        }
        public string Name
        {
            get { return Friend.Name; }
            set
            {
                if (Friend.Name != value)
                {
                    Friend.Name = value;
                    OnPropertyChaged("Name");
                }
            }
        }
        public string Email
        {
            get { return Friend.Email; }
            set
            {
                if (Friend.Email != value)
                {
                    Friend.Email = value;
                    OnPropertyChaged("Email");
                }
            }
        }
        public string Phone
        {
            get { return Friend.Phone; }
            set
            {
                if (Friend.Phone != value)
                {
                    Friend.Phone = value;
                    OnPropertyChaged("Phone");
                }
            }
        }
        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                (!string.IsNullOrEmpty(Phone.Trim())) ||
                (!string.IsNullOrEmpty(Email.Trim())));
            }
        }

        protected void OnPropertyChaged(string propName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
            
        }
    }
}
