using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classe_Articoli
{
    public partial class Form1 : Form
    {
        private int codice = 0;

        // Liste per memorizzare gli articoli
        private List<Alimentari> alimentari = new List<Alimentari>();
        private List<AlimentariFreschi> alimentariFreschi = new List<AlimentariFreschi>();
        private List<ArticoloNonAlimentare> nonAlimentari = new List<ArticoloNonAlimentare>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Classe base per gli articoli venduti
        class Articolo
        {
            public string Codice { get; set; }
            public string Nome { get; set; }
            public float Prezzo { get; set; }
            public bool Carta { get; set; }

            // Metodo per calcolare lo sconto sul prezzo dell'articolo
            public virtual float Sconta()
            {
                float sconto = Carta ? Prezzo * 0.05f : 0; // Sconto del 5% se si ha la carta fedeltà
                return Prezzo - sconto;
            }
        }

        // Classe derivata per gli articoli alimentari
        class Alimentari : Articolo
        {
            public string DataScadenza { get; set; }

            // Metodo per calcolare lo sconto sugli alimentari
            public override float Sconta()
            {
                float sconto = base.Sconta(); // Applica lo sconto base
                if (DateTime.TryParse(DataScadenza, out DateTime scadenza) && scadenza.Year == DateTime.Today.Year)
                {
                    sconto -= Prezzo * 0.2f; // Sconto aggiuntivo del 20% se l'anno di scadenza coincide con quello attuale
                }
                return sconto;
            }
        }

        // Classe derivata per gli articoli non alimentari
        class ArticoloNonAlimentare : Articolo
        {
            public string Materiale { get; set; }
            public bool Riciclabile { get; set; }

            // Metodo per calcolare lo sconto sugli articoli non alimentari
            public override float Sconta()
            {
                float sconto = base.Sconta(); // Applica lo sconto base
                if (Riciclabile)
                {
                    sconto -= Prezzo * 0.1f; // Sconto aggiuntivo del 10% se l'articolo è riciclabile
                }
                return sconto;
            }
        }

        // Classe derivata per gli articoli alimentari freschi
        class AlimentariFreschi : Alimentari
        {
            public int Scadenza { get; set; }

            // Metodo per calcolare lo sconto sugli alimentari freschi
            public override float Sconta()
            {
                float sconto = base.Sconta(); // Applica lo sconto base
                sconto -= Prezzo * (Scadenza * 0.02f); // Sconto aggiuntivo in base alla scadenza
                return sconto;
            }
        }

        // Metodo per aggiungere un articolo alimentare
        private void AggiungiAlimentare()
        {
            string nome = Interaction.InputBox("Nome prodotto", "Input prodotto", "");
            string prezzo = Interaction.InputBox("Prezzo prodotto", "Input prodotto", "");
            string dataScadenza = Interaction.InputBox("Data di scadenza prodotto", "Input prodotto", "");

            var alimentare = new Alimentari
            {
                Codice = codice.ToString(),
                Nome = nome,
                Prezzo = float.Parse(prezzo),
                DataScadenza = dataScadenza
            };
            alimentari.Add(alimentare);
            codice++;
        }

        // Metodo per aggiungere un articolo non alimentare
        private void AggiungiNonAlimentare()
        {
            string nome = Interaction.InputBox("Nome prodotto", "Input prodotto", "");
            string prezzo = Interaction.InputBox("Prezzo prodotto", "Input prodotto", "");
            string materiale = Interaction.InputBox("Materiale del prodotto", "Input prodotto", "");
            bool riciclabile = MessageBox.Show("È riciclabile?", "Riciclabile", MessageBoxButtons.YesNo) == DialogResult.Yes;

            var nonAlimentare = new ArticoloNonAlimentare
            {
                Codice = codice.ToString(),
                Nome = nome,
                Prezzo = float.Parse(prezzo),
                Materiale = materiale,
                Riciclabile = riciclabile
            };
            nonAlimentari.Add(nonAlimentare);
            codice++;
        }

        // Metodo per aggiungere un articolo alimentare fresco
        private void AggiungiAlimentareFresco()
        {
            string nome = Interaction.InputBox("Nome prodotto", "Input prodotto", "");
            string prezzo = Interaction.InputBox("Prezzo prodotto", "Input prodotto", "");
            string dataScadenza = Interaction.InputBox("Data di scadenza prodotto", "Input prodotto", "");
            string scadenza = Interaction.InputBox("Scadenza massima prodotto", "Input prodotto", "");

            var alimentareFresco = new AlimentariFreschi
            {
                Codice = codice.ToString(),
                Nome = nome,
                Prezzo = float.Parse(prezzo),
                DataScadenza = dataScadenza,
                Scadenza = int.Parse(scadenza)
            };
            alimentariFreschi.Add(alimentareFresco);
            codice++;
        }

        // Metodo per generare lo scontrino
        private void GeneraScontrino()
        {
            float totale = 0;
            float totaleScontato = 0;

            DialogResult result = MessageBox.Show("Possiedi la carta fedeltà?", "Carta fedeltà", MessageBoxButtons.YesNo);
            bool cartaFedelta = result == DialogResult.Yes;

            // Calcola il totale e il totale scontato per gli alimentari
            foreach (var alimentare in alimentari)
            {
                alimentare.Carta = cartaFedelta;
                totale += alimentare.Prezzo;
                totaleScontato += alimentare.Sconta();
            }

            // Calcola il totale e il totale scontato per gli alimentari freschi
            foreach (var alimentareFresco in alimentariFreschi)
            {
                alimentareFresco.Carta = cartaFedelta;
                totale += alimentareFresco.Prezzo;
                totaleScontato += alimentareFresco.Sconta();
            }

            // Calcola il totale e il totale scontato per gli articoli non alimentari
            foreach (var nonAlimentare in nonAlimentari)
            {
                nonAlimentare.Carta = cartaFedelta;
                totale += nonAlimentare.Prezzo;
                totaleScontato += nonAlimentare.Sconta();
            }

            // Visualizza lo scontrino
            string scontrino = "Scontrino:\n";
            scontrino += "ARTICOLI ALIMENTARI:\n";
            foreach (var alimentare in alimentari)
            {
                scontrino += $"{alimentare.Nome} - Prezzo: {alimentare.Prezzo:C} - Prezzo scontato: {alimentare.Sconta():C} - Data di scadenza: {alimentare.DataScadenza}\n";
            }

            scontrino += "\nARTICOLI ALIMENTARI FRESCHI:\n";
            foreach (var alimentareFresco in alimentariFreschi)
            {
                scontrino += $"{alimentareFresco.Nome} - Prezzo: {alimentareFresco.Prezzo} - Prezzo scontato: {alimentareFresco.Sconta()} - Data di scadenza: {alimentareFresco.DataScadenza}\n";
            }

            scontrino += "\nARTICOLI NON ALIMENTARI:\n";
            foreach (var nonAlimentare in nonAlimentari)
            {
                scontrino += $"{nonAlimentare.Nome} - Prezzo: {nonAlimentare.Prezzo} - Prezzo scontato: {nonAlimentare.Sconta()} - Materiale: {nonAlimentare.Materiale} - Riciclabile: {(nonAlimentare.Riciclabile ? "Si" : "No")}\n";
            }

            scontrino += $"\nTOTALE: {totale}\nTOTALE SCONTATO: {totaleScontato}";

            MessageBox.Show(scontrino, "Scontrino");
        }



        // Gestione del click sul pulsante per aggiungere articoli alimentari
        private void ALIMENTARI_Click_1(object sender, EventArgs e)
        {
            AggiungiAlimentare();
        }

        // Gestione del click sul pulsante per aggiungere articoli non alimentari
        private void NON_ALIMENTARI_Click_1(object sender, EventArgs e)
        {
            AggiungiNonAlimentare();
        }

        // Gestione del click sul pulsante per aggiungere articoli alimentari freschi
        private void ALIMENTARI_FRESCHI_Click_1(object sender, EventArgs e)
        {
            AggiungiAlimentareFresco();
        }

        // Gestione del click sul pulsante per generare lo scontrino
        private void SCONTRINO_Click_1(object sender, EventArgs e)
        {
            GeneraScontrino();
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            // Chiusura della applicazione con conferma
            DialogResult conferma = MessageBox.Show("Sei sicuro di voler uscire dal programma?", "Esci", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conferma == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
