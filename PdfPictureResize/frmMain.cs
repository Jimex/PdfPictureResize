using iTextSharp.text.pdf;
using iTextSharp.text;
using PdfPictureResize.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf.parser;
using iTextSharp.xmp.impl.xpath;
using System.Drawing.Imaging;
using static System.Windows.Forms.AxHost;
using static System.Net.WebRequestMethods;
using Path = System.IO.Path;
using File = System.IO.File;

namespace PdfPictureResize
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

       

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void LoadSettings()
        {
            txtSourceFolder.Text = Properties.Settings.Default.PDFInputFolder.IfNullTrim();
            txtOutputFolder.Text = Properties.Settings.Default.PDFOutputFolder.IfNullTrim();
            cmbPageSize.SelectedItem = Properties.Settings.Default.OutputPageSize.IfNullOrEmpty("A4");
            nudLeft.Value = Properties.Settings.Default.OutputPageLeftMargin;
            nudRight.Value = Properties.Settings.Default.OutputPageRightMargin;
            nudTop.Value = Properties.Settings.Default.OutputPageTopMargin;
            nudBottom.Value = Properties.Settings.Default.OutputPageBottomMargin;
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.PDFInputFolder = txtSourceFolder.Text;
            Properties.Settings.Default.PDFOutputFolder = txtOutputFolder.Text;
            Properties.Settings.Default.OutputPageSize = cmbPageSize.SelectedItem.ToString();
            Properties.Settings.Default.OutputPageLeftMargin= Convert.ToInt16(nudLeft.Value);
            Properties.Settings.Default.OutputPageRightMargin = Convert.ToInt16(nudRight.Value);
            Properties.Settings.Default.OutputPageTopMargin = Convert.ToInt16(nudTop.Value);
            Properties.Settings.Default.OutputPageBottomMargin = Convert.ToInt16(nudBottom.Value);
            Properties.Settings.Default.Save();
        }

        private void btnSelectInputFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtSourceFolder.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSourceFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSelectOutputFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtOutputFolder.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnStartConvertPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                var files = Directory.GetFiles(txtSourceFolder.Text, "*.pdf");
                foreach (var pdfFile in files)
                {
                    ExtractImage(pdfFile);
                }
            }
            catch (Exception ex)
            {
                txtLog.Text = ex.Message;
            }
        }
        private void ExtractImage(string pdfFile)
        {

            var outputDir = txtOutputFolder.Text;
            if (outputDir.IsNullOrBlank())
            {
                outputDir = Path.Combine(Path.GetDirectoryName(pdfFile), "Output");
            }
            //outputDir = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(pdfFile));
            var outputImageDir = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(pdfFile), "Images");
            if (!Directory.Exists(outputImageDir))
            {
                Directory.CreateDirectory(outputImageDir);
            }
            var pageSize = PageSize.A4;
            switch (Properties.Settings.Default.OutputPageSize.ToUpper())
            {
                case "A5":
                    pageSize = PageSize.A5;
                    break;
                case "B4":
                    pageSize = PageSize.B4;
                    break;
                case "B5":
                    pageSize = PageSize.B5;
                    break;
                case "KINDLE":
                    pageSize = new RectangleReadOnly(431f, 648f); ;
                    break;
            }
            var pdfDocument = new Document(
                pageSize,
                (float)Properties.Settings.Default.OutputPageLeftMargin,
                (float)Properties.Settings.Default.OutputPageRightMargin,
                (float)Properties.Settings.Default.OutputPageTopMargin,
                (float)Properties.Settings.Default.OutputPageBottomMargin);
            var exportFile = Path.Combine(outputDir, Path.GetFileName(pdfFile));
            using (var pdfReader = new PdfReader(pdfFile))
            {
                using (var fileStream = new FileStream(exportFile, FileMode.OpenOrCreate))
                {
                    var writer = PdfWriter.GetInstance(pdfDocument, fileStream);
                    pdfDocument.Open();
                    byte[] prevImageData = null;
                    for (int pageNumber = 1; pageNumber <= pdfReader.NumberOfPages; pageNumber++)
                    {
                        PdfReader pdf = new PdfReader(pdfFile);
                        PdfDictionary pg = pdf.GetPageN(pageNumber);
                        PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
                        PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                        if (xobj == null) continue;
                        var imageImdexByPage = 1;
                        foreach (PdfName name in xobj.Keys)
                        {
                            PdfObject obj = xobj.Get(name);
                            if (obj.IsIndirect())
                            {
                                PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                                var type = PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE)) as PdfName;
                                if (!PdfName.IMAGE.Equals(type)) continue;

                                int XrefIndex = (obj as PRIndirectReference).Number;
                                var pdfStream = pdf.GetPdfObject(XrefIndex) as PRStream;
                                var data = PdfReader.GetStreamBytesRaw(pdfStream);
                                if (prevImageData == null || !prevImageData.SequenceEqual(data))
                                {
                                    var imgPath = System.IO.Path.Combine(outputImageDir, $"{pageNumber}_{imageImdexByPage}.jpg");
                                    File.WriteAllBytes(imgPath, data);
                                   
                                    try
                                    {
                                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imgPath);
                                        float percentage = 1;
                                        //这里都是图片最原始的宽度与高度  
                                        float resizedWidht = img.Width;
                                        float resizedHeight = img.Height;

                                        //这时判断图片宽度是否大于页面宽度减去也边距，如果是，那么缩小，如果还大，继续缩小，  
                                        //这样这个缩小的百分比percentage会越来越小  
                                        while (resizedWidht > (pdfDocument.PageSize.Width - pdfDocument.LeftMargin - pdfDocument.RightMargin))
                                        {
                                            percentage = percentage * 0.99f;
                                            resizedHeight = img.Height * percentage;
                                            resizedWidht = img.Width * percentage;
                                        }

                                        while (resizedHeight > (pdfDocument.PageSize.Height - pdfDocument.TopMargin - pdfDocument.BottomMargin))
                                        {
                                            percentage = percentage * 0.99f;
                                            resizedHeight = img.Height * percentage;
                                            resizedWidht = img.Width * percentage;
                                        }

                                        //这里用计算出来的百分比来缩小图片  
                                        img.ScalePercent(percentage * 100);
                                        //图片定位，页面总宽283，高416；这里设置0,0的话就是页面的左下角 让图片的中心点与页面的中心店进行重合  
                                        img.SetAbsolutePosition(pdfDocument.PageSize.Width / 2 - resizedWidht / 2, pdfDocument.PageSize.Height / 2 - resizedHeight / 2);
                                        pdfDocument.NewPage();
                                        pdfDocument.Add(img);
                                        imageImdexByPage++;
                                        prevImageData = data;
                                    }
                                    catch (Exception ex)
                                    {
                                        AppLogger.LogError($"ConvertImage-{imgPath}", ex);
                                    }
                                }
                            }
                        }
                    }
                    writer.Flush();
                    writer.CloseStream = true;
                    pdfDocument.Close();
                }
                pdfReader.Close();
            }
        }
    }
}
