using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace Exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString("http://hp-api.herokuapp.com/api/characters");
                List<Root> characters = JsonConvert.DeserializeObject<List<Root>>(json);

                for (int i = 1; i < characters.Count; i++)
                {
                    MessageBox.Show($"{characters[i].name}, {characters[i].species}, {characters[i].gender}, {characters[i].house}. " +
                        $"Date of birth: {characters[i].dateOfBirth}, year of birth-{characters[i].yearOfBirth}.{characters[i].ancestry}. eye colour-{characters[i].eyeColour}, hair colour-{characters[i].hairColour}, wand-{characters[i].wand}, patronus-{characters[i].patronus}. {characters[i].hogwartsStudent} {characters[i].hogwartsStaff}. Actor-{characters[i].actor}, {characters[i].alive}, {characters[i].image}");
                }
            }
            
        }
    }
}
