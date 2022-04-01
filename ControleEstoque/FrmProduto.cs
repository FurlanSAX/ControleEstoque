using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControleEstoque1
{
    public partial class FrmProduto : ControleEstoque1.FrmBase
    {
        public FrmProduto()
        {
            InitializeComponent();
            BloqueiaCampos();
            CarregarGridProd();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {

        }

        private void CarregarGridProd()
        {
            Model get = new Model();
            List<DtoProduto2> lista = get.ListProdutos();
            this.dataGridView12.DataSource = lista;
            this.dataGridView12.Refresh();
        }
        private void BloqueiaCampos()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }
        private void LilberaCampos()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void bntNovo_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty; 
            LilberaCampos();
            textBox2.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model set = new Model();
                DtoProduto u = new DtoProduto();
                u.nome = textBox2.Text;
                u.peso = textBox3.Text;
                if (textBox1.Text != string.Empty)
                {
                    u.id = int.Parse(textBox1.Text);
                    set.EditProduto(u);
                }
                else
                {
                    set.SetProduto(u);
                }

                BloqueiaCampos();
                CarregarGridProd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            LilberaCampos();
            textBox2.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                Model del = new Model();
                del.DeletarProduto(int.Parse(textBox1.Text));
                BloqueiaCampos();
                CarregarGridProd();
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (Int32)dataGridView12.CurrentRow.Cells[0].Value;

            Model get = new Model();
            DtoProduto2 d = get.GetProdutoId(ID);
            textBox1.Text = d.id.ToString();
            textBox2.Text = d.nome;
            textBox3.Text = d.peso.ToString();
            LilberaCampos();
            textBox2.Focus();
        }
    }
}
