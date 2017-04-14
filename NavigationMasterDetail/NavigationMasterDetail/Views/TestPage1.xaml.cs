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


           
         

        }

        public string LabelTitle
        {
            get { return MyLabel.Text; } set { MyLabel.Text = value; }
        }
    }
}
