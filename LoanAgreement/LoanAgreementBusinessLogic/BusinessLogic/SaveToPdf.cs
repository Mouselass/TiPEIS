using System;
using System.Collections.Generic;
using System.Text;
using LoanAgreementBusinessLogic.HelperModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace LoanAgreementBusinessLogic.BusinessLogic
{
    public class SaveToPdf
    {
        public static void CreateDocCosts(PdfInfoCosts info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";
            paragraph = section.AddParagraph($"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}"); paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "Normal";
            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "3cm", "5cm", "6cm", "3cm" };
            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Клиент", "Договор", "Дата действия", "Сумма процента" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            decimal sum = 0;
            foreach (var cost in info.Costs)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { cost.Counterpartylender, cost.LoanAgreement, cost.Date.ToString(), cost.ProcentSum.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Left
                });
                sum += cost.ProcentSum;
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Итого:", "", "", sum.ToString() },
                Style = "Normal",
                ParagraphAlignment = ParagraphAlignment.Left
            });
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }

        public static void CreateDocSums(PdfInfoSums info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";
            paragraph = section.AddParagraph($"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}"); paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "Normal";
            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "4cm", "4cm", "5cm", "4cm" };
            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Клиент", "Агент", "Сумма займа", "Дата заключения договора" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            decimal sum = 0;
            foreach (var sums in info.Sums)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { sums.Agent, sums.Counterpartylender, sums.Sum.ToString(), sums.Date.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Left
                });
                sum += sums.Sum;
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Итого:", "", sum.ToString(), "" },
                Style = "Normal",
                ParagraphAlignment = ParagraphAlignment.Left
            });
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }

        public static void CreateDocPostingJournal(PdfInfoPostingJournal info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";
            paragraph = section.AddParagraph($"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}"); paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "Normal";
            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "2cm", "2.5cm", "2.5cm", "2.5cm", "2.5cm", "2.5cm", "2.5cm" };
            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Счет", "Начальное сальдо дебет", "Начальное сальдо кредит", "Оборот дебет", "Оборот кредит", "Конечное сальдо дебет", "Конечное сальдо кредит" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            decimal BalanceStartPeriodDebit = 0;
            decimal BalanceStartPeriodCredit = 0;
            decimal BalancePeriodDebit = 0;
            decimal BalancePeriodCredit = 0;
            decimal BalanceEndPeriodDebit = 0;
            decimal BalanceEndPeriodCredit = 0;
            foreach (var cost in info.PostingJournal)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { cost.ChartOfAccounts, cost.BalanceStartPeriodDebit.ToString(), cost.BalanceStartPeriodCredit.ToString(), 
                        cost.BalancePeriodDebit.ToString(), cost.BalancePeriodCredit.ToString(), cost.BalanceEndPeriodDebit.ToString(), cost.BalanceEndPeriodCredit.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Center
                });
                BalanceStartPeriodDebit += cost.BalanceStartPeriodDebit;
                BalanceStartPeriodCredit += cost.BalanceStartPeriodCredit;
                BalancePeriodDebit += cost.BalancePeriodDebit;
                BalancePeriodCredit += cost.BalancePeriodCredit;
                BalanceEndPeriodDebit += cost.BalanceEndPeriodDebit;
                BalanceEndPeriodCredit += cost.BalanceEndPeriodCredit;
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Итого:", BalanceStartPeriodDebit.ToString(), BalanceStartPeriodCredit.ToString(), BalancePeriodDebit.ToString(), 
                    BalancePeriodCredit.ToString(), BalanceEndPeriodDebit.ToString(), BalanceEndPeriodCredit.ToString()},
                Style = "Normal",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }

        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }

        private static void CreateRow(PdfRowParameters rowParameters)
        {
            Row row = rowParameters.Table.AddRow();
            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                FillCell(new PdfCellParameters
                {
                    Cell = row.Cells[i],
                    Text = rowParameters.Texts[i],
                    Style = rowParameters.Style,
                    BorderWidth = 0.5,
                    ParagraphAlignment = rowParameters.ParagraphAlignment
                });
            }
        }

        private static void FillCell(PdfCellParameters cellParameters)
        {
            cellParameters.Cell.AddParagraph(cellParameters.Text);
            if (!string.IsNullOrEmpty(cellParameters.Style))
            {
                cellParameters.Cell.Style = cellParameters.Style;
            }
            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
        }

    }
}
