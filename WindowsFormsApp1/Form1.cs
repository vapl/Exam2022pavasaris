using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IWebDriver driver;
        private string searchResultUrl;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Norādiet ceļu uz ChromeDriver
            var chromeDriverService = ChromeDriverService.CreateDefaultService(@"C:\Users\valdi\Desktop\Eksāmens_Pavasaris_2024\Exam2022pavasaris");
            driver = new ChromeDriver(chromeDriverService);
            driver.Navigate().GoToUrl("https://www.ebay.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text; // Lietotāja ievadītais meklēšanas vaicājums
            var searchBox = driver.FindElement(By.Id("gh-ac"));
            var searchButton = driver.FindElement(By.Id("gh-btn"));

            searchBox.SendKeys(searchQuery);
            searchButton.Click();

            searchResultUrl = driver.Url;
            AddToSearchHistory(searchResultUrl);
            textBox2.Text = searchResultUrl; // Ieliekam saiti uz rezultātu teksta laukā
        }

        private void button3_Click(object sender, EventArgs e)
        {
            driver.Navigate().Back();

            // Atkal meklējam elementus pēc atgriešanās
            var searchBox = driver.FindElement(By.Id("gh-ac"));
            searchBox.Clear();
            ClearSearchResultLink();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }

        private void AddToSearchHistory(string url)
        {
            searchHistoryListBox.Items.Add(url);
        }

        private void ClearSearchResultLink()
        {
            textBox2.Text = ""; // Izdzēšam saiti uz rezultātu teksta laukā
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
