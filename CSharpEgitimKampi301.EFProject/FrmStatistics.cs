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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            decimal? l_avgCapacity = Convert.ToDecimal(db.Location.Average(x => x.Capacity));

            lblAvgCapacity.Text = l_avgCapacity.HasValue ? l_avgCapacity.Value.ToString("0.00") : string.Empty;   
            decimal ? l_avgLocationPrice = Convert.ToDecimal(db.Location.Average(x => x.Price));
            lblAvgLocationPrice.Text = l_avgLocationPrice.HasValue ? l_avgLocationPrice.Value.ToString("0.00") : string.Empty;
            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(x => x.Country).FirstOrDefault();
            lblCapadociaCapacity.Text = db.Location.Where(x=>x.City == "Kapadokya").Select(x=>x.Capacity).FirstOrDefault().ToString();
            lblTurkeyAvgCapacity.Text = db.Location.Where(x=>x.Country == "Türkiye").Average(x=>x.Capacity).ToString();
            var romeGuideId = db.Location.Where(x => x.City == "Romta Turistik").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(x => x.GuideName + " " + x.GuideSurname).FirstOrDefault();

            var MaxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == MaxCapacity).Select(y => y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.Country).FirstOrDefault().ToString();

            var guideId = db.Guide.Where(x => x.GuideName == "Aleyna Kaya").Select(x=>x.GuideId).FirstOrDefault();
            lblAleynaTotalTour.Text = db.Location.Where(x => x.GuideId == guideId).Count().ToString();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
