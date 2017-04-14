using NavigationMasterDetail.MenuItems;
using NavigationMasterDetail.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NavigationMasterDetail {

    public partial class MainPage
    {

        public List<MasterPageItem> menuList { get; set; }

        public List<MasterPageItem> childMenuList { get; set; }

        public MainPage() {

            InitializeComponent();

            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Item 1", Icon = "itemIcon1.png", TargetType = typeof(TestPage1),
                Children = new List<MasterPageItem>
                {
                    new MasterPageItem()
                    {
                        Title = "Item 11", Icon = "itemIcon1.png", TargetType = typeof(TestPage1)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 12", Icon = "itemIcon2.png", TargetType = typeof(TestPage2)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 13", Icon = "itemIcon3.png", TargetType = typeof(TestPage3)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 14", Icon = "itemIcon4.png", TargetType = typeof(TestPage1)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 15", Icon = "itemIcon5.png", TargetType = typeof(TestPage2)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 16", Icon = "itemIcon6.png", TargetType = typeof(TestPage3)
                    }
                }
            };
            var page2 = new MasterPageItem() { Title = "Item 2", Icon = "itemIcon2.png", TargetType = typeof(TestPage2),
                Children = new List<MasterPageItem>
                {
                    new MasterPageItem()
                    {
                        Title = "Item 21", Icon = "itemIcon1.png", TargetType = typeof(TestPage1)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 22", Icon = "itemIcon2.png", TargetType = typeof(TestPage2)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 23", Icon = "itemIcon3.png", TargetType = typeof(TestPage3)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 24", Icon = "itemIcon4.png", TargetType = typeof(TestPage1)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 25", Icon = "itemIcon5.png", TargetType = typeof(TestPage2)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 26", Icon = "itemIcon6.png", TargetType = typeof(TestPage3)
                    }
                }
            };
            var page3 = new MasterPageItem() { Title = "Item 3", Icon = "itemIcon3.png", TargetType = typeof(TestPage3),
                Children = new List<MasterPageItem>
                {
                    new MasterPageItem()
                    {
                        Title = "Item 31", Icon = "itemIcon1.png", TargetType = typeof(TestPage1)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 32", Icon = "itemIcon2.png", TargetType = typeof(TestPage2)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 33", Icon = "itemIcon3.png", TargetType = typeof(TestPage3)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 34", Icon = "itemIcon4.png", TargetType = typeof(TestPage1)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 35", Icon = "itemIcon5.png", TargetType = typeof(TestPage2)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 36", Icon = "itemIcon6.png", TargetType = typeof(TestPage3)
                    }
                }
            };
            var page4 = new MasterPageItem() { Title = "Item 4", Icon = "itemIcon4.png", TargetType = typeof(TestPage1),
                Children = new List<MasterPageItem>
                {
                    new MasterPageItem()
                    {
                        Title = "Item 41", Icon = "itemIcon1.png", TargetType = typeof(TestPage1)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 42", Icon = "itemIcon2.png", TargetType = typeof(TestPage2)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 43", Icon = "itemIcon3.png", TargetType = typeof(TestPage3)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 44", Icon = "itemIcon4.png", TargetType = typeof(TestPage1)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 45", Icon = "itemIcon5.png", TargetType = typeof(TestPage2)
                    },
                    new MasterPageItem()
                    {
                        Title = "Item 46", Icon = "itemIcon6.png", TargetType = typeof(TestPage3)
                    }
                }
            };


            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TestPage1)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e) {

            var item = (MasterPageItem)e.SelectedItem;
           
            ChildNavigationDrawerList.ItemsSource = item.Children;
            IsPresented = true;
        }

        private void OnChildMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            var thePage = (Page) Activator.CreateInstance(page);
            Detail = new NavigationPage(thePage) {Title = item.Title};


            if (thePage is TestPage1)
            {
                var testPage1 = thePage as TestPage1;
                string myText = string.Empty;
                for (int i = 0; i < 200; i++)
                {
                    myText = myText + item.Title + "; ";
                }

               
                testPage1.LabelTitle = myText;
            }

            if (thePage is TestPage2)
            {
                var testPage2 = thePage as TestPage2;
                testPage2.LabelTitle = item.Title;
            }

            if (thePage is TestPage3)
            {
                var testPage3 = thePage as TestPage3;
                testPage3.LabelTitle = item.Title;
            }
            IsPresented = false;
        }
    }
}
