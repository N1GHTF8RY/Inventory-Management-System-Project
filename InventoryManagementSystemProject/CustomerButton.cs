using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystemProject
{
    public partial class CustomerButton : PictureBox
    {
        public CustomerButton()
        {
            InitializeComponent();
        }

        public Image ImageNormal { get; set; }
        public Image ImageHover { get; set; }

        private void CustomerButton_MouseHover(object sender, System.EventArgs e)
        {
            this.Image = ImageHover;
        }

        private void CustomerButton_MouseLeave(object sender, System.EventArgs e)
        {
            this.Image = ImageNormal;
        }
    }
}
