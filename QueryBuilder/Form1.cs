using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QueryBuilder
{
    public partial class Form1 : Form
    {
        //Inicializa mi nueva query (en blanco).
        readonly QueryHandler _query = new QueryHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_InsertLabel_Click(object sender, EventArgs e)
        {

            //Llamo a query para que agregue un valor.
            if (textBox1.Text != "")
                _query.AddIndex(textBox1.Text);
            textBox1.Clear();
            //Llamo a la funcion update label, para que actualice el resultado final.
            UpdateLabel();
        }


        private void btn_InsertLabel2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                //Llamo a query para que agregue un valor.
                _query.AddSrcIp(textBox2.Text);
            textBox2.Clear();
            //Llamo a la funcion update label, para que actualice el resultado final.
            UpdateLabel();
        }


        private void btn_InsertLabel3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")

                //Validación
                errorProvider1.Clear();
                if (Regex.IsMatch(@"/[\d\`!@#$%\^(){}:.-]*/g", textBox3.Text))
                {
                    errorProvider1.Clear();
                    //Llamo a query para que agregue un valor.
                    _query.AddDestIp(textBox3.Text);
                    textBox3.Clear();
                    //Llamo a la funcion update label, para que actualice el resultado final.
                    UpdateLabel();
                }
                else
                {
                    errorProvider1.SetError(textBox3, "Format Error");
                }

        }




        public void btn_InsertLabel4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                //Validación
                if (textBox4.Text != "")
                    errorProvider1.Clear();

                if (Regex.IsMatch(@"^/[\d\`!@#$%\^(){}:.-]*/g", textBox3.Text))
                {
                    //Llamo a query para que agregue un valor.

                    _query.AddDestPort(textBox4.Text);
                    textBox4.Clear();
                    //Llamo a la funcion update label, para que actualice el resultado final.
                    UpdateLabel();
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Format Error");
                }
            }
            else
            {

            }
        }


        //Vuelvo a imprimir todo, para que quede actualizado visualmente.
        void UpdateLabel()
        {
            if (_query.Index != "")
                textBox_Query.Text = $"{_query.Index}{_query.SrcIp}{_query.DestIp}{_query.DestPort}";
            else
                textBox_Query.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _query.ResetIndex();
            UpdateLabel();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBox_Query.Text);
            }
            catch (ArgumentNullException)
            {
            }




        }

        private void btn_delete1_Click(object sender, EventArgs e)
        {
            _query.DelIndex(textBox1.Text);
            textBox1.Clear();
            UpdateLabel();

        }

        private void btn_delete2_Click(object sender, EventArgs e)
        {
            _query.DelSrcIp(textBox2.Text);
            textBox2.Clear();
            UpdateLabel();
        }

        private void btn_delete3_Click(object sender, EventArgs e)
        {
            _query.DelDestIp(textBox3.Text);
            textBox3.Clear();
            UpdateLabel();
        }

        private void btn_delete4_Click(object sender, EventArgs e)
        {
            _query.DelDestPort(textBox4.Text);
            textBox4.Clear();
            UpdateLabel();
        }

        private void btn_Splunk_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_Query.Text);
            System.Diagnostics.Process.Start("explorer.exe", "https://splunk-es-central.pwcinternal.com/en-US/app/launcher/home");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

