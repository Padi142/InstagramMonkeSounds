using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using Mono;
using System.Media;

namespace FollowerCheck
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int oldfollows = Get_Instagram_Follows();
            Console.WriteLine("Old follows loaded");
            while (true)
            {
                Console.WriteLine("Hello World!");
                int newfollows = Get_Instagram_Follows();
                Console.WriteLine(newfollows);
                if(newfollows>oldfollows)
                {
                int n = newfollows - oldfollows;
                    while(n>0)
                    {
                        Console.WriteLine("UAUAUAUAUAAU");
                        PlayMonkeSound();
                        n--;
                    }
                }
                Thread.Sleep(3000);
            }
        }

        static int Get_Instagram_Follows()
        {
            int follows = 0;
            IWebDriver driver = new FirefoxDriver();
            Thread.Sleep(600);

            driver.Navigate().GoToUrl("https://www.instagram.com/matyslav_/");
            IWebElement Cookies = driver.FindElement(By.XPath("/html/body/div[4]/div/div/button[1]"));
            Cookies.Click();
            Thread.Sleep(100);

            IWebElement followers = driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/header/section/ul/li[2]/a/span"));
            follows = int.Parse(followers.Text);

            driver.Quit();

            return (follows);
        }
        static void PlayMonkeSound()
        {
            Random rnd = new Random();
            int monkesound = rnd.Next(9);

            SoundPlayer player = new SoundPlayer();
            player.Stop();
            player.SoundLocation = @"D:\pogramovani\c#\FollowerCheck\monkey"+monkesound+".wav";
            player.Play();

        }
    }
}
