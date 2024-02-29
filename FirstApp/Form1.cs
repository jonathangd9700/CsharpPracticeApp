using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstApp
{
    public partial class frmDiscos : Form
    {
        private List<Discos> discosList;

        public frmDiscos()
        {
            InitializeComponent();
        }

        private void frmDiscos_Load(object sender, EventArgs e)
        {
            DiscosData discosData = new DiscosData();
            discosList = discosData.listar();
            dgvDiscos.DataSource = discosList;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            loadImage(discosList[0].urlImagenTapa);
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Discos selectedDisk = (Discos)dgvDiscos.CurrentRow.DataBoundItem;
            loadImage(selectedDisk.urlImagenTapa);
        }

        private void loadImage(string image)
        {
            try
            {
                picBoxAlbum.Load(image);
            }

            catch (Exception ex)
            {
                picBoxAlbum.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0FRqSHPVoQs7W9wYSmHOVvvP9oJcp0io00v_W6r3RwQ&s");
            }
        }

    }
}
