using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId

            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = Convert.ToByte(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = Convert.ToDecimal(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = Convert.ToInt32(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.Location.Find(id);
            db.Location.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var updateValue = db.Location.Find(id);
            updateValue.DayNight = txtDayNight.Text;
            updateValue.Price = Convert.ToInt32(txtPrice.Text);
            updateValue.Capacity = Convert.ToByte(nudCapacity.Value.ToString());
            updateValue.City = txtCity.Text;
            updateValue.Country = txtCountry.Text;
            updateValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());

            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
