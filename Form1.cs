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
            textBoxfl.Text = textBoxaper.Text = textBoxdiam1.Text = textBoxlims.Text = textBoxliml.Text = "";
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
                else if (diam1 > 0)
                {
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else
                {
                    textBoxlims.Text = textBoxliml.Text = "输入有误";
                }
            }
            else
            {
                textBoxlims.Text = textBoxliml.Text = "输入有误";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("本计算器适用于没有跟踪设备的星空摄影。\n只考虑地球自转，忽略其他因素影响。\n效率指数反映每像素的信噪比。\n具体算法参见源码。\n作者：Garth天卜", "说明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetDataObject("https://github.com/GarthTB/astrophoto-calculator");
            MessageBox.Show("源码链接已复制到剪贴板。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxmodel.SelectedItem.ToString())
            {
                case "":
                    textBoxsensorh.Text = textBoxsensorv.Text = textBoxsensorhn.Text = textBoxsensorvn.Text = textBoxpixelh.Text = textBoxpixelv.Text = "";
                    break;
                case "IMX071":
                    textBoxsensorh.Text = "23.73";
                    textBoxsensorv.Text = "15.76";
                    textBoxsensorhn.Text = "4944";
                    textBoxsensorvn.Text = "3284";
                    textBoxpixelh.Text = textBoxpixelv.Text = "4.80";
                    break;
                case "IMX410":
                    textBoxsensorh.Text = "36.07";
                    textBoxsensorv.Text = "24.01";
                    textBoxsensorhn.Text = "6072";
                    textBoxsensorvn.Text = "4042";
                    textBoxpixelh.Text = textBoxpixelv.Text = "5.94";
                    break;
                case "IMX455":
                    textBoxsensorh.Text = "36";
                    textBoxsensorv.Text = "24";
                    textBoxsensorhn.Text = "9576";
                    textBoxsensorvn.Text = "6388";
                    textBoxpixelh.Text = textBoxpixelv.Text = "3.76";
                    break;
                case "IMX461":
                    textBoxsensorh.Text = "43.8";
                    textBoxsensorv.Text = "32.87";
                    textBoxsensorhn.Text = "11664";
                    textBoxsensorvn.Text = "8750";
                    textBoxpixelh.Text = textBoxpixelv.Text = "3.76";
                    break;
                case "IMX533":
                    textBoxsensorh.Text = "11.31";
                    textBoxsensorv.Text = "11.31";
                    textBoxsensorhn.Text = "3008";
                    textBoxsensorvn.Text = "3008";
                    textBoxpixelh.Text = textBoxpixelv.Text = "3.76";
                    break;
                case "IMX571":
                    textBoxsensorh.Text = "23.61";
                    textBoxsensorv.Text = "15.83";
                    textBoxsensorhn.Text = "6280";
                    textBoxsensorvn.Text = "4210";
                    textBoxpixelh.Text = textBoxpixelv.Text = "3.76";
                    break;
            }
        }

        private void buttonclear2_Click(object sender, EventArgs e)
        {
            comboBoxmodel.SelectedItem = "";
            textBoxsensorh.Text = textBoxsensorv.Text = textBoxsensorhn.Text = textBoxsensorvn.Text = textBoxpixelh.Text = textBoxpixelv.Text = textBoxangleh1.Text = textBoxanglev1.Text = "";
            comboBoxmodel.Focus();
        }

        private void buttoncal2_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxfl.Text, out float fl);
            float.TryParse(textBoxsensorh.Text, out float sensorh);
            float.TryParse(textBoxsensorv.Text, out float sensorv);
            int.TryParse(textBoxsensorhn.Text, out int sensorhn);
            int.TryParse(textBoxsensorvn.Text, out int sensorvn);
            if (sensorh > 0 && sensorhn > 0)
            {
                float pixelh = sensorh * 1000 / sensorhn;
                textBoxpixelh.Text = pixelh.ToString("F2");
            }
            else
            {
                textBoxpixelh.Text = "输入有误";
            }
            if (sensorv > 0 && sensorvn > 0)
            {
                float pixelv = sensorv * 1000 / sensorvn;
                textBoxpixelv.Text = pixelv.ToString("F2");
            }
            else
            {
                textBoxpixelv.Text = "输入有误";
            }
            if (fl > 0 && sensorh > 0)
            {
                float arcminh;
                float angleh1 = (float)(Math.Atan(sensorh / fl) * 180 / Math.PI);
                if (angleh1 >= 1)
                {
                    arcminh = angleh1 % 1 * 60;
                    angleh1 = angleh1 - angleh1 % 1;
                    textBoxangleh1.Text = angleh1.ToString("F0") + "°" + arcminh.ToString("F2") + "′";
                }
                else
                {
                    arcminh = angleh1 % 1 * 60;
                    textBoxangleh1.Text = arcminh.ToString("F2") + "′";
                }
            }
            else
            {
                textBoxangleh1.Text = "输入有误";
            }
            if (fl > 0 && sensorv > 0)
            {
                float arcminv;
                float anglev1 = (float)(Math.Atan(sensorv / fl) * 180 / Math.PI);
                if (anglev1 >= 1)
                {
                    arcminv = anglev1 % 1 * 60;
                    anglev1 = anglev1 - anglev1 % 1;
                    textBoxanglev1.Text = anglev1.ToString("F0") + "°" + arcminv.ToString("F2") + "′";
                }
                else
                {
                    arcminv = anglev1 % 1 * 60;
                    textBoxanglev1.Text = arcminv.ToString("F2") + "′";
                }
            }
            else
            {
                textBoxanglev1.Text = "输入有误";
            }
        }

        private void buttonclear3_Click(object sender, EventArgs e)
        {
            textBoxres1.Text = textBoxdec.Text = textBoxfwhm.Text = textBoxexp1.Text = "";
            buttoncal31.Focus();
        }

        private void buttoncal31_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxfl.Text, out float fl);
            float.TryParse(textBoxpixelh.Text, out float pixelh);
            float.TryParse(textBoxpixelv.Text, out float pixelv);
            if (fl > 0)
            {
                if (pixelh > 0 && pixelv > 0)
                {
                    float res1 = (float)(Math.Atan((pixelh + pixelv) / fl / 2000) * 648000 / Math.PI);
                    textBoxres1.Text = res1.ToString("F2");
                }
                else if (pixelh > 0 || pixelv > 0)
                {
                    float res1 = (float)(Math.Atan((pixelh + pixelv) / fl / 1000) * 648000 / Math.PI);
                    textBoxres1.Text = res1.ToString("F2");
                }
                else
                {
                    textBoxres1.Text = "输入有误";
                }
            }
            else
            {
                textBoxres1.Text = "输入有误";
            }
        }

        private void buttoncal32_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxres1.Text, out float res1);
            float.TryParse(textBoxdec.Text, out float dec);
            float.TryParse(textBoxfwhm.Text, out float fwhm);
            float.TryParse(textBoxexp1.Text, out float exp1);
            if (res1 > 0 && dec >= -90 && dec <= 90)
            {
                if (fwhm > 0 && exp1 >= 0)
                {
                    exp1 = (float)(res1 * fwhm * 21541 / Math.Cos(dec * Math.PI / 180) / 324000);
                    textBoxexp1.Text = exp1.ToString("N3");
                }
                else if (exp1 > 0 && fwhm == 0)
                {
                    fwhm = (float)(Math.Cos(dec * Math.PI / 180) * 324000 * exp1 / res1 / 21541);
                    textBoxfwhm.Text = fwhm.ToString("N3");
                }
                else
                {
                    textBoxexp1.Text = "输入有误";
                }
            }
            else
            {
                textBoxexp1.Text = "输入有误";
            }
        }

        private void buttonclear4_Click(object sender, EventArgs e)
        {
            comboBoxunit.SelectedItem = "";
            textBoxres2.Text = textBoxtardiam.Text = textBoxsize.Text = "";
            buttoncal41.Focus();
        }

        private void buttoncal41_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxfl.Text, out float fl);
            float.TryParse(textBoxpixelh.Text, out float pixelh);
            float.TryParse(textBoxpixelv.Text, out float pixelv);
            if (fl > 0)
            {
                if (pixelh > 0 && pixelv > 0)
                {
                    float res1 = (float)(Math.Atan((pixelh + pixelv) / fl / 2000) * 648000 / Math.PI);
                    textBoxres2.Text = res1.ToString("F2");
                }
                else if (pixelh > 0 || pixelv > 0)
                {
                    float res1 = (float)(Math.Atan((pixelh + pixelv) / fl / 1000) * 648000 / Math.PI);
                    textBoxres2.Text = res1.ToString("F2");
                }
                else
                {
                    textBoxres2.Text = "输入有误";
                }
            }
            else
            {
                textBoxres2.Text = "输入有误";
            }
        }

        private void buttoncal42_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxres2.Text, out float res2);
            float.TryParse(textBoxtardiam.Text, out float tardiam);
            if (res2 > 0 && tardiam > 0 && comboBoxunit.SelectedItem.ToString() != "")
            {
                float size;
                switch (comboBoxunit.SelectedItem.ToString())
                {
                    case "度":
                        size = tardiam * 3600 / res2;
                        textBoxsize.Text = size.ToString("F3");
                        break;
                    case "分":
                        size = tardiam * 60 / res2;
                        textBoxsize.Text = size.ToString("F3");
                        break;
                    case "秒":
                        size = tardiam / res2;
                        textBoxsize.Text = size.ToString("F3");
                        break;
                }
            }
            else
            {
                textBoxsize.Text = "输入有误";
            }
        }

        private void buttonclear5_Click(object sender, EventArgs e)
        {
            textBoxres3.Text = textBoxdiam2.Text = textBoxexp2.Text = textBoxeff.Text = "";
            textBoxres3.Focus();
        }

        private void buttoncal5_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxres3.Text, out float res3);
            float.TryParse(textBoxdiam2.Text, out float diam2);
            float.TryParse(textBoxexp2.Text, out float exp2);
            if (res3 > 0 && diam2 > 0 && exp2 > 0)
            {
                //假设某一确定天体，单位时间内，每角秒发出的光子数量恒定。忽略量子效率和读出噪声。
                //信噪比与光子数量的算数平方根成正比。
                //一个天体每角秒的信噪比，与口径成正比，与焦比无关。（参见猫10篇的note-add1）
                //*10000是为了让数据更直观。
                //每像素信噪比 ∝ 口径 * 每像素的角大小 * √(曝光时间)
                double eff = diam2 * res3 * Math.Sqrt(exp2) * 10000;
                textBoxeff.Text = eff.ToString("F0");
            }
            else
            {
                textBoxeff.Text = "输入错误";
            }
        }

        private void textBoxdiam1_TextChanged(object sender, EventArgs e)
        {
            textBoxdiam2.Text = textBoxdiam1.Text;
        }


        private void textBoxres1_TextChanged(object sender, EventArgs e)
        {
            textBoxres3.Text = textBoxres2.Text = textBoxres1.Text;
        }

        private void textBoxexp1_TextChanged(object sender, EventArgs e)
        {
            textBoxexp2.Text = textBoxexp1.Text;
        }

        private void textBoxres2_TextChanged(object sender, EventArgs e)
        {
            textBoxres1.Text = textBoxres3.Text = textBoxres2.Text;
        }


        private void textBoxres3_TextChanged(object sender, EventArgs e)
        {
            textBoxres1.Text = textBoxres2.Text = textBoxres3.Text;
        }

        private void textBoxdiam2_TextChanged(object sender, EventArgs e)
        {
            textBoxdiam1.Text = textBoxdiam2.Text;
        }

        private void textBoxexp2_TextChanged(object sender, EventArgs e)
        {
            textBoxexp1.Text = textBoxexp2.Text;
        }

        private void textBoxfl_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxfl, "单位：毫米");
        }

        private void textBoxaper_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxaper, "望远镜的焦比或镜头的光圈f值");
        }

        private void textBoxdiam1_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxdiam1, "单位：毫米");
        }

        private void textBoxwaves_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxwaves, "单位：纳米");
        }

        private void textBoxwavel_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxwavel, "单位：纳米");
        }

        private void buttoncal1_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttoncal1, "焦距、光圈、口径知二求一\n并计算衍射极限");
        }

        private void textBoxlims_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxlims, "单位：角秒");
        }

        private void textBoxliml_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxliml, "单位：角秒");
        }

        private void comboBoxmodel_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(comboBoxmodel, "快速填入特定相机（传感器）的数据");
        }

        private void textBoxsensorh_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxsensorh, "传感器长（单位：毫米）");
        }

        private void textBoxsensorv_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxsensorv, "传感器宽（单位：毫米）");
        }

        private void textBoxsensorhn_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxsensorhn, "长边的Active pixel数");
        }

        private void textBoxsensorvn_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxsensorvn, "短边的Active pixel数");
        }

        private void buttoncal2_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttoncal2, "计算像素大小和视角（需在镜头选项卡输入焦距）");
        }

        private void textBoxpixelh_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxpixelh, "像素长（单位：微米）");
        }

        private void textBoxpixelv_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxpixelv, "像素宽（单位：微米）");
        }

        private void textBoxangleh1_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxangleh1, "长边的视角");
        }

        private void textBoxanglev1_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxanglev1, "短边的视角");
        }

        private void buttoncal31_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttoncal31, "计算总分辨率");
        }

        private void textBoxres1_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxres1, "单位：角秒/像素");
        }

        private void textBoxdec_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxdec, "单位：度");
        }

        private void textBoxfwhm_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxfwhm, "想要刚好不拖线则填入星点半宽(单位：像素)");
        }

        private void textBoxexp1_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxexp1, "单位：秒");
        }

        private void buttoncal32_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttoncal32, "计算拖线程度或曝光时间");
        }

        private void buttoncal41_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttoncal41, "计算总分辨率");
        }

        private void textBoxres2_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxres2, "单位：角秒/像素");
        }

        private void comboBoxunit_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(comboBoxunit, "目标视直径的角度单位");
        }

        private void textBoxtardiam_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxtardiam, "目标的视直径（角度）");
        }

        private void buttoncal42_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttoncal42, "计算目标所占的像素数");
        }

        private void textBoxsize_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxsize, "目标所占的像素数");
        }


        private void textBoxres3_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxres3, "单位：角秒/像素");
        }

        private void textBoxdiam2_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxdiam2, "单位：毫米");
        }

        private void textBoxexp2_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxexp2, "单位：秒");
        }

        private void buttoncal5_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttoncal5, "计算效率指数");
        }
    }
}