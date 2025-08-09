using Budget;
using Budget.Entities;

namespace MyBudgetUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmToolStreepMenu());
           // Application.Run(new FrmTaksitTakip());

            try
            {
                using (var db = new BudgetContext())
                {
                    // Ba�lant� testi: kisiler say�s�n� alal�m
                    int kisiSayisi = db.Kisiler.Count();
                    MessageBox.Show($"Ba�lant� ba�ar�l�. Veritaban�nda {kisiSayisi} ki�i var.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ba�lant� Hatas�: " + ex.Message);
            }

        }
    }
}