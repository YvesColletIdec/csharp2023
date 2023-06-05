using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;
using System.Drawing;

using WebApplicationDemo2023.Models;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace WebApplicationDemo2023.Helpers
{
    public class Print
    {
        public static string CreerDocumentAPartirDuTemplate(Facture f, string template)
        {
            Document document = new Document();
            document.LoadFromFile(template);
            document.Replace("client_prenom", f.Client.Prenom, true, true);
            document.Replace("client_nom", f.Client.Nom, true, true);
            document.Replace("client_adresse", f.Client.Adresse, true, true);
            document.Replace("client_npa", f.Client.Npa.ToString(), true, true);
            document.Replace("client_localite", f.Client.Localite, true, true);
            document.Replace("facture_date", f.DateFacture.ToString("dd.MM.yyyy"), true, true);
            document.Replace("facture_num", f.Id.ToString(), true, true);

            //la première section est celle ou l'on trouve un titre "Titre1"
            Spire.Doc.Section s = document.Sections[0];
            Spire.Doc.Table table = s.AddTable(true);
            String[] Header = { "N°", "Article", "Quantité", "Prix unitaire", "Total" };
            table.ResetCells(f.LigneFactures.Count + 1, Header.Length);

            //Header Row
            TableRow FRow = table.Rows[0];
            FRow.IsHeader = true;
            //Row Height
            //FRow.Height = 18;
            FRow.Cells[0].Width = 20;
            FRow.Cells[1].Width = 150;
            FRow.Cells[2].Width = 60;
            FRow.Cells[3].Width = 80;
            FRow.Cells[4].Width = 40;
            //Header Format
            FRow.RowFormat.BackColor = Color.LightBlue;
            for (int i = 0; i < Header.Length; i++)
            {
                //Cell Alignment
                Paragraph p = FRow.Cells[i].AddParagraph();
                FRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = HorizontalAlignment.Center;
                //Data Format
                TextRange TR = p.AppendText(Header[i]);
                TR.CharacterFormat.FontName = "Calibri";
                TR.CharacterFormat.FontSize = 14;
                TR.CharacterFormat.TextColor = Color.Teal;
                TR.CharacterFormat.Bold = true;
            }

            decimal grandTotal = 0;
            List<LigneFacture> listLignesFactures = new List<LigneFacture>(f.LigneFactures);
            //Data Row
            for (int r = 0; r < listLignesFactures.Count; r++)
            {
                LigneFacture lf = listLignesFactures[r];
                TableRow DataRow = table.Rows[r + 1];

                //Row Height
                DataRow.Height = 15;

                //C Represents Column. 5 -> nombre de colonnes
                for (int c = 0; c < 5; c++)
                {
                    //Cell Alignment
                    DataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    //Fill Data in Rows
                    Paragraph p2 = DataRow.Cells[c].AddParagraph();
                    TextRange TR2 = null;
                    decimal total = lf.PrixUnitaire * lf.Quantite;
                    switch (c)
                    {
                        case 0:
                            TR2 = p2.AppendText(lf.Article.Id.ToString());
                            break;
                        case 1:
                            TR2 = p2.AppendText(lf.Article.Nom);
                            break;
                        case 2:
                            TR2 = p2.AppendText(lf.Quantite.ToString());
                            break;
                        case 3:
                            TR2 = p2.AppendText(lf.PrixUnitaire.ToString());
                            break;
                        case 4:
                            TR2 = p2.AppendText(lf.MontantTotalCHF);
                            grandTotal += total;
                            break;
                        default:
                            Console.WriteLine("Erreur dans le numéro de colonne");
                            break;
                    }

                    //Format Cells
                    p2.Format.HorizontalAlignment = HorizontalAlignment.Center;
                    TR2.CharacterFormat.FontName = "Calibri";
                    TR2.CharacterFormat.FontSize = 12;
                    TR2.CharacterFormat.TextColor = Color.Brown;
                }

            }
            //TOTAL
            Paragraph pa = s.AddParagraph();
            pa.AppendText("\n");
            TextRange t = pa.AppendText($"TOTAL : {f.MontantTotalCHF}");
            pa.Format.HorizontalAlignment = HorizontalAlignment.Right;
            t.CharacterFormat.FontName = "Calibri";
            t.CharacterFormat.FontSize = 16;
            t.CharacterFormat.TextColor = Color.SteelBlue;
            string save = @"C:\Users\Yves\xxx.pdf";
            document.SaveToFile(save, FileFormat.PDF);
            return save;
        }

    }
}
