namespace 星空计算器
{
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

        private void buttonclear1_Click(object sender, EventArgs e)
        {
            textBoxfl.Text = "";
            textBoxaper.Text = "";
            textBoxdiam1.Text = "";
            textBoxlims.Text = "";
            textBoxliml.Text = "";
            textBoxwaves.Text = "400";
            textBoxwavel.Text = "700";
            textBoxfl.Focus();
        }

        private void buttoncal1_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxfl.Text, out float fl);
            float.TryParse(textBoxaper.Text, out float aper);
            float.TryParse(textBoxdiam1.Text, out float diam1);
            float.TryParse(textBoxwaves.Text, out float waves);
            float.TryParse(textBoxwavel.Text, out float wavel);
            if (waves > 0 && wavel > 0 && wavel > waves)
            {
                if (fl > 0 && aper > 0 && diam1 == 0)
                {
                    diam1 = fl / aper;
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxdiam1.Text = diam1.ToString("F2");
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else if (fl > 0 && diam1 > 0 && aper == 0)
                {
                    aper = fl / diam1;
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxaper.Text = aper.ToString("F2");
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else if (aper > 0 && diam1 > 0 && fl == 0)
                {
                    fl = aper * diam1;
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxfl.Text = fl.ToString("F2");
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else if (aper > 0 && diam1 > 0 && fl > 0)
                {
                    MessageBox.Show("数据输入有误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (diam1 > 0)
                {
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else
                {
                    MessageBox.Show("数据输入有误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("数据输入有误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}