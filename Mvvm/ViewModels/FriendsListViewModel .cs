﻿using Mvvm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
namespace Mvvm.ViewModels
{
    public class FriendsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FriendViewModel> Friend { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateFriendCommand { get; protected set; }
        public ICommand DeleteFriendCommand { get; protected set; }
        public ICommand SaveFriendCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }
        FriendViewModel selectedFriend;
        public INavigation Navigation { get; set; }
        public FriendsListViewModel()
        {
            Friend = new ObservableCollection<FriendViewModel>();
            CreateFriendCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);
        }
        public FriendViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != value)
                {
                    FriendViewModel tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChaged("selectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend));
                }
            }
        }
        protected void OnPropertyChaged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null && friend.IsValid && !Friend.Contains(friend))
            {
                Friend.Add(friend);
            }
            Back();
        }
        private void DeleteFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null)
            {
                Friend.Remove(friend);
            }
            Back();
        }
    }
}