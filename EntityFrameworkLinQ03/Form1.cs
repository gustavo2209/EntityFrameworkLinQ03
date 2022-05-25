using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkLinQ03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Departamentos();
            Provincias();
            Distritos();
        }

        private void Distritos()
        {
            int idprovincia = Convert.ToInt32(comboBox2.SelectedValue);

            using (var db = new ModelPeru())
            {
                var query = from dist in db.distritos
                            where dist.idprovincia == idprovincia
                            select new
                            {
                                iddistrito = dist.iddistrito,
                                distrito = dist.distrito
                            };

                comboBox3.DataSource = query.ToList();
                comboBox3.ValueMember = "iddistrito";
                comboBox3.DisplayMember = "distrito";
            }
        }

        private void Provincias()
        {
            int iddepartamento = Convert.ToInt32(comboBox1.SelectedValue);

            using (var db = new ModelPeru())
            {
                var query = from prov in db.provincias
                                where prov.iddepartamento == iddepartamento
                                select new
                                {
                                    idprovincia = prov.idprovincia,
                                    provincia = prov.provincia
                                };

                    comboBox2.DataSource = query.ToList();
                    comboBox2.ValueMember = "idprovincia";
                    comboBox2.DisplayMember = "provincia";
            }
        }

        private void Departamentos()
        {
            using(var db = new ModelPeru())
            {
                var query = from depa in db.departamentos
                            select new
                            {
                                iddepartamento = depa.iddepartamento,
                                departamento = depa.departamento
                            };

                comboBox1.DataSource = query.ToList();
                comboBox1.ValueMember = "iddepartamento";
                comboBox1.DisplayMember = "departamento";
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Provincias();
            Distritos();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Distritos();
        }
    }
}
