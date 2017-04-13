using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NavigationMasterDetail.Views {
    public partial class TestPage1 : ContentPage {
        public TestPage1() {
            InitializeComponent();


            string myText = string.Empty;
            for (int i = 0; i < 200; i++)
            {
               myText = myText + "Button " + i + "; ";
            }
            MyLabel.Text = myText;

        }
    }
}
