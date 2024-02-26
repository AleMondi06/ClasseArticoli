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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Dichiarazione delle liste e variabili globali
        List<Alimentari> alimentari = new List<Alimentari>();
        List<AlimentariFreschi> alimentariFreschi = new List<AlimentariFreschi>();
        List<ArticoloNonAlimentare> nonAlimentari = new List<ArticoloNonAlimentare>();
        int codice = 0;

        // Classe base per gli articoli venduti
        class Articolo
        {            
            // Costruttori con parametri per inizializzare gli oggetti Articolo
            public Articolo(string a, string b, int c)
            {
                codice = a;
                nome = b;
                prezzo = c;
            }

            protected string codice, nome;
            protected float prezzo;
            protected bool carta = false;

            // Proprietà per il codice, il nome, il prezzo e la presenza della carta fedeltà
            public string Codice
            {
                get { return codice; }
                set { codice = value; }
            }
            public string Nome
            {
                get { return nome; }
                set { nome = value; }
            }
            public float Prezzo
            {
                get { return prezzo; }
                set { prezzo = value; }
            }
            public bool Carta
            {
                get { return carta; }
                set { carta = value; }
            }

            // Metodo virtuale per calcolare lo sconto sul prezzo dell'articolo
            public virtual float Sconta()
            {
                return prezzo - ((prezzo / 100) * 5);
            }
        }

        // Classe derivata per gli articoli alimentari
        class Alimentari : Articolo
        {            
            // Costruttore per gli articoli alimentari
            public Alimentari(string a, string b, int c, string d) : base(a, b, c)
            {
                data_scadenza = d;
            }
            protected string data_scadenza; // Data di scadenza dell'articolo alimentare

            // Proprietà per la data di scadenza
            public string Data_Scadenza
            {
                get { return data_scadenza; }
                set { data_scadenza = value; }
            }
            // Metodo per calcolare lo sconto sul prezzo dell'articolo alimentare
            public override float Sconta()
            {
                float Prezzo = prezzo;
                if (int.Parse(data_scadenza) == DateTime.Today.Year)
                {
                    Prezzo = prezzo - ((prezzo / 100) * 20);
                }
                if (carta == true)
                {
                    Prezzo = Prezzo - ((Prezzo / 100) * 5);
                }
                return Prezzo;
            }

            // Metodo per stampare le informazioni sull'articolo alimentare
            public string Stampa()
            {
                return $"Scontrino:\nCodice: {codice}\nNome: {nome}\nPrezzo: {prezzo:C}\nPrezzo scontato: {Sconta():C}\nData di scadenza: {data_scadenza}";
            }

        }

        // Classe derivata per gli articoli non alimentari
        class ArticoloNonAlimentare : Articolo
        {
            private string materiale; // Materiale di cui è composto l'articolo non alimentare
            private bool riciclabile; // Indica se l'articolo è riciclabile o meno

            // Proprietà per il materiale e la riciclabilità dell'articolo non alimentare
            public string Materiale
            {
                get { return materiale; }
                set { materiale = value; }
            }
            public bool Riciclabile
            {
                get { return riciclabile; }
                set { riciclabile = value; }
            }

            // Costruttore per gli articoli non alimentari
            public ArticoloNonAlimentare(string a, string b, int c, bool d, string e) : base(a, b, c)
            {
                materiale = e;
                riciclabile = d;
            }

            // Metodo per calcolare lo sconto sul prezzo dell'articolo non alimentare
            public override float Sconta()
            {
                // 20% di sconto se l'articolo è riciclabile
                int riciclab = 1;
                if (riciclabile == true)
                {
                    riciclab = 10;
                }
                float Prezzo = prezzo - ((prezzo / 100) * riciclab);
                if (carta == true)
                {
                    Prezzo = Prezzo - ((Prezzo / 100) * 5);
                }
                return Prezzo;
            }

            // Metodo per stampare le informazioni sull'articolo non alimentare
            public string Stampa()
            {
                string ricic = (riciclabile) ? "SI" : "NO";
                return $"Scontrino:\nCodice: {codice}\nNome: {nome}\nPrezzo: {prezzo:C}\nPrezzo scontato: {Sconta():C}\nMateriale: {materiale}\nRiciclabile: {ricic}";
            }

        }

        // Classe derivata per gli articoli alimentari freschi
        class AlimentariFreschi : Alimentari
        {
            private int scadenza; // Scadenza massima dell'articolo alimentare fresco

            // Proprietà per la scadenza massima dell'articolo alimentare fresco
            public int Scadenza
            {
                get { return scadenza; }
                set { scadenza = value; }
            }

            // Costruttore per gli articoli alimentari freschi
            public AlimentariFreschi(string a, string b, int c, string d, int e) : base(a, b, c, d)
            {
                scadenza = e;
            }

            // Metodo per calcolare lo sconto sul prezzo dell'articolo alimentare fresco
            public override float Sconta()
            {
                int Fresco = 0;
                for (int i = 0; i < scadenza; i++)
                {
                    Fresco += 2;
                }
                float Prezzo = prezzo - ((prezzo / 100) * Fresco);
                if (int.Parse(data_scadenza) == DateTime.Today.Year)
                {
                    Prezzo = prezzo - ((prezzo / 100) * 20);
                }
                if (carta == true)
                {
                    Prezzo = Prezzo - ((Prezzo / 100) * 5);
                }
                return Prezzo;
            }
        }

        // Gestione del click sul pulsante per aggiungere articoli alimentari
        private void ALIMENTARI_Click_1(object sender, EventArgs e)
        {
            // Visualizzazione di messaggi per l'inserimento dei dati dell'articolo
            string message, title, defaultValue;
            message = "nome prodotto";
            title = "Input prodotto";
            defaultValue = "";
            string nome = Interaction.InputBox(message, title, defaultValue);
            message = "prezzo prodotto";
            string prezzo = Interaction.InputBox(message, title, defaultValue);
            message = "data di scadenza prodotto";
            string data = Interaction.InputBox(message, title, defaultValue);

            // Creazione di un nuovo oggetto Alimentari e aggiunta alla lista degli alimentari
            Alimentari alimentare = new Alimentari(codice.ToString(), nome, int.Parse(prezzo), data);
            alimentari.Add(alimentare);
            codice++;
        }

        // Gestione del click sul pulsante per aggiungere articoli non alimentari
        private void NON_ALIMENTARI_Click_1(object sender, EventArgs e)
        {
            // Visualizzazione di messaggi per l'inserimento dei dati dell'articolo
            string message, title, defaultValue;
            message = "nome prodotto";
            title = "Input prodotto";
            defaultValue = "";
            string nome = Interaction.InputBox(message, title, defaultValue);
            message = "prezzo prodotto";
            string prezzo = Interaction.InputBox(message, title, defaultValue);
            message = "materiale del prodotto";
            string materiale = Interaction.InputBox(message, title, defaultValue);

            // Messaggio di conferma per la riciclabilità dell'articolo
            DialogResult dialogResult = MessageBox.Show("è riciclabile?", "Riciclabile", MessageBoxButtons.YesNo);
            bool a = false;
            if (dialogResult == DialogResult.Yes)
            {
                a = true;
            }

            // Creazione di un nuovo oggetto ArticoloNonAlimentare e aggiunta alla lista degli articoli non alimentari
            ArticoloNonAlimentare alimentare = new ArticoloNonAlimentare(codice.ToString(), nome, int.Parse(prezzo), a, materiale);
            nonAlimentari.Add(alimentare);
            codice++;
        }

        // Gestione del click sul pulsante per aggiungere articoli alimentari freschi
        private void ALIMENTARI_FRESCHI_Click_1(object sender, EventArgs e)
        {
            // Visualizzazione di messaggi per l'inserimento dei dati dell'articolo
            string message, title, defaultValue;
            message = "nome prodotto";
            title = "Input prodotto";
            defaultValue = "";
            string nome = Interaction.InputBox(message, title, defaultValue);
            message = "prezzo prodotto";
            string prezzo = Interaction.InputBox(message, title, defaultValue);
            message = "data di scadenza prodotto";
            string data = Interaction.InputBox(message, title, defaultValue);
            message = "scadenza massima prodotto";
            string scad = Interaction.InputBox(message, title, defaultValue);

            // Creazione di un nuovo oggetto AlimentariFreschi e aggiunta alla lista degli alimentari freschi
            AlimentariFreschi alimentare = new AlimentariFreschi(codice.ToString(), nome, int.Parse(prezzo), data, int.Parse(scad));
            alimentariFreschi.Add(alimentare);
            codice++;
        }

        // Gestione del click sul pulsante per generare lo scontrino
        private void SCONTRINO_Click_1(object sender, EventArgs e)
        {
            float totale = 0; // Variabile per calcolare il totale degli articoli
            float totaleScontato = 0; // Variabile per calcolare il totale scontato degli articoli

            DialogResult dialogResult = MessageBox.Show("possiedi la carta fedeltá?", "carta fedeltá", MessageBoxButtons.YesNo);

            // Se l'utente possiede la carta fedeltà, applica lo sconto a tutti gli articoli
            if (dialogResult == DialogResult.Yes)
            {
                foreach (Alimentari alimentari in alimentari)
                {
                    alimentari.Carta = true;
                }
                foreach (ArticoloNonAlimentare alimentari in nonAlimentari)
                {
                    alimentari.Carta = true;
                }
                foreach (AlimentariFreschi alimentari in alimentariFreschi)
                {
                    alimentari.Carta = true;
                }
            }

            // Aggiunta degli articoli alimentari allo scontrino
            Scontrinο.Items.Add("ARTICOLI ALIMENTARI:");
            foreach (Alimentari alimentari in alimentari)
            {
                Scontrinο.Items.Add(alimentari.Stampa());
                totale += alimentari.Prezzo;
                totaleScontato += alimentari.Sconta();
            }

            // Aggiunta degli articoli non alimentari allo scontrino
            Scontrinο.Items.Add("ARTICOLI NON ALIMENTARI:");
            foreach (ArticoloNonAlimentare alimentari in nonAlimentari)
            {
                Scontrinο.Items.Add(alimentari.Stampa());
                totale += alimentari.Prezzo;
                totaleScontato += alimentari.Sconta();
            }

            // Aggiunta degli articoli alimentari freschi allo scontrino
            Scontrinο.Items.Add("ARTICOLI ALIMENTARI FRESCHI:");
            foreach (AlimentariFreschi alimentari in alimentariFreschi)
            {
                Scontrinο.Items.Add(alimentari.Stampa());
                totale += alimentari.Prezzo;
                totaleScontato += alimentari.Sconta();
            }

            // Aggiunta del totale e del totale scontato allo scontrino
            Scontrinο.Items.Add(" ");
            Scontrinο.Items.Add("tot: " + totale);
            Scontrinο.Items.Add("tot scontato: " + totaleScontato);
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
