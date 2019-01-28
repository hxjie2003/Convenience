using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.Util;
using NPOI.XWPF.UserModel;

namespace ETong.ApiDocExport
{
    /// <summary>
    /// NPOI工具封装类
    /// </summary>
    public static class DocumentHelper
    {


        /// <summary>
        /// 创建一个word文档
        /// </summary>
        /// <returns></returns>
        public static XWPFDocument CreateNew()
        {
            var document = new XWPFDocument();
            document.AddDefaultHeadingStyle();
            return document;
        }

        /// <summary>
        /// 加入缺省的标题风格
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static XWPFDocument AddDefaultHeadingStyle(this XWPFDocument doc)
        {
            if (doc != null)
            {
                addCustomHeadingStyle(doc, GetHeadingId(1), 1);
                addCustomHeadingStyle(doc, GetHeadingId(2), 2);
                addCustomHeadingStyle(doc, GetHeadingId(3), 3);
                addCustomHeadingStyle(doc, GetHeadingId(4), 4);
                addCustomHeadingStyle(doc, GetHeadingId(5), 5);
                addCustomHeadingStyle(doc, GetHeadingId(6), 6);
            }
            return doc;
        }
        private static string GetHeadingId(int level)
        {
            return "标题 " + level;
        }

        /// <summary>
        /// 创建标题段
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="text">标题文字</param>
        /// <param name="level">标题级别</param>
        /// <returns></returns>
        public static XWPFRun CreateHeading(this XWPFDocument doc, string text, int level)
        { 
            XWPFRun run = doc.CreateParagraph(text);
            run.Paragraph.Style = GetHeadingId(level);
            return run;
        }

        /// <summary>
        /// 创建普通文本段
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static XWPFRun CreateParagraph(this XWPFDocument doc, string text)
        {
            XWPFParagraph paragraph = doc.CreateParagraph();
            XWPFRun run = paragraph.CreateRun();
            run.SetText(text);
            return run;
        }

        /// <summary>
        /// 加粗
        /// </summary>
        /// <param name="run"></param>
        /// <param name="isBold"></param>
        /// <returns></returns>
        public static XWPFRun SetBold(this XWPFRun run, bool isBold)
        {
            run.SetBold(isBold);
            return run;
        }

        /// <summary>
        /// 设字号
        /// </summary>
        /// <param name="run"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        public static XWPFRun SetFontSize(this XWPFRun run, int fontSize)
        {
            if (run == null)
            {
                return null;
            }
            run.FontSize = fontSize;
            return run;
        }

        /// <summary>
        /// 设置表格行背景
        /// </summary>
        /// <param name="row"></param>
        /// <param name="strRGB"></param>
        /// <returns></returns>
        public static XWPFTableRow SetRowBackgroundColor(this XWPFTableRow row, string strRGB)
        {
            var cells = row.GetTableCells();
            foreach (var c in cells)
            {
                c.SetColor(strRGB);
            }
            return row;
        }

        /// <summary>
        /// 设置行文本
        /// </summary>
        /// <param name="row"></param>
        /// <param name="textArray"></param>
        /// <returns></returns>
        public static XWPFTableRow SetRowText(this XWPFTableRow row, params string[] textArray)
        {
            var cells = row.GetTableCells();
            int index = 0;
            foreach (var c in cells)
            {
                if (index < textArray.Length && textArray[index]!=null)
                {
                    c.SetText(textArray[index]);
                    index++;
                }
            }
            return row;
        }

        /// <summary>
        /// 设置表格中字体颜色
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="strRRGGBB"></param>
        /// <returns></returns>
        public static XWPFTableCell SetCellFontColor(this XWPFTableCell cell, string strRRGGBB)
        {
            if (cell != null && cell.Paragraphs.Any() && cell.Paragraphs[0].Runs.Any())
            {
                cell.Paragraphs[0].Runs[0].SetColor(strRRGGBB);
            }
            return cell;
        }

        public static XWPFTable SetColumnWidth(this XWPFTable tbl, params ulong[] widthArray)
        {
            var cells = tbl.Rows[0].GetTableCells();
            int index = 0;
            foreach (var c in cells)
            {
                if (index < widthArray.Length && widthArray[index]!=null)
                {
                    tbl.SetColumnWidth(index, widthArray[index]);
                    index++;
                }
            }
            return tbl;
        }

        /// <summary>
        /// 加入标题定义
        /// </summary>
        /// <param name="docxDocument"></param>
        /// <param name="strStyleId"></param>
        /// <param name="headingLevel"></param>
        private static void addCustomHeadingStyle(XWPFDocument docxDocument, String strStyleId, int headingLevel)
        {
            CT_Style ctStyle = new CT_Style();
            ctStyle.styleId = strStyleId;

            CT_String styleName = new CT_String();
            styleName.val = strStyleId;
            ctStyle.name = styleName;

            CT_DecimalNumber indentNumber = new CT_DecimalNumber();
            indentNumber.val = BigInteger.ValueOf(headingLevel).ToString();

            // lower number > style is more prominent in the formats bar  
            ctStyle.uiPriority = indentNumber;

            CT_OnOff onoffnull = new CT_OnOff();
            ctStyle.unhideWhenUsed = onoffnull;

            // style shows up in the formats bar  
            ctStyle.qFormat = onoffnull;

            // style defines a heading of the given level  
            CT_PPr ppr = new CT_PPr();
            ppr.outlineLvl = indentNumber;
            ctStyle.pPr = ppr;

            XWPFStyle style = new XWPFStyle(ctStyle);

            // is a null op if already defined  
            XWPFStyles styles = docxDocument.CreateStyles();

            style.StyleType = ST_StyleType.paragraph;

            if (styles.GetStyle(strStyleId) == null)
            {
                styles.AddStyle(style);
            }

        }

        public enum HeadingLevel
        {
            h1 = 1,
            h2 = 2,
            h3 = 3,
            h4 = 4,
            h5 = 5,
            h6 = 6,
        }

    }
}
