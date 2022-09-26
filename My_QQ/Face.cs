using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace My_QQ
{
    public partial class Face : Form
    {
        Main m = new Main();
        PictureBox p1 = new PictureBox();
        public Face(PictureBox p)
        {
            p1 = p;
            InitializeComponent();
        }
        public Face()
        {
            InitializeComponent();
        }

        private void Face_Load(object sender, EventArgs e)
        {
            listView1.LargeImageList = m.imageList1;
            for (int i = 0; i < 100; i++)
            {
                ListViewItem lv1 = new ListViewItem();
                lv1.ImageIndex = i;
                listView1.Items.Add(lv1);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            p1.Image = m.imageList1.Images[listView1.SelectedItems[0].ImageIndex];
            p1.Tag = listView1.SelectedItems[0].ImageIndex;
        }
    }
}
