using Microsoft.Win32;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.IO.Packaging;
using System.Windows.Xps;

namespace ShoppingCart
{

    public partial class MainWindow : Window
    {
        private static int code;
        
        public MainWindow()
        {            
            InitializeComponent();
            AddItemsToDatabase();
            
            using (ShopContext ShopContext = new ShopContext())
            {               

                foreach (var i in ShopContext.Items)
                {
                    var gridN = new Grid();

                    gridN.VerticalAlignment = VerticalAlignment.Top;
                    gridN.Background = Brushes.White;
                    gridN.Height = 420;
                    gridN.Width = 823;

                    gridN.Effect = new DropShadowEffect
                    {
                        BlurRadius = 20,
                        ShadowDepth = 1
                    };

                    var img = new System.Windows.Controls.Image();
                    img.Source = new BitmapImage(new Uri(i.UrlImg));


                    Thickness marginImg = img.Margin;
                    marginImg.Left = 21;
                    img.Margin = marginImg;
                    img.HorizontalAlignment = HorizontalAlignment.Left; 

                    gridN.Children.Add(img);

                    var stackPanel = new StackPanel();
                    Thickness marginStackPanel = stackPanel.Margin;
                    marginStackPanel.Left = 542;
                    marginStackPanel.Top = 70;
                    marginStackPanel.Right = 0;
                    marginStackPanel.Bottom = 70;
                    stackPanel.Margin = marginStackPanel;
                    stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    stackPanel.Width = 263;

                    var textBlockName = new TextBlock();
                    textBlockName.Text = i.Name;
                    textBlockName.FontSize = 18;
                    Thickness marginTextBlockName = textBlockName.Margin;
                    marginTextBlockName.Left = 0;
                    marginTextBlockName.Right = 0;
                    marginTextBlockName.Bottom = 5;
                    marginTextBlockName.Top = 5;
                    textBlockName.Margin = marginTextBlockName;
                    textBlockName.Foreground = Brushes.Black;

                    stackPanel.Children.Add(textBlockName);

                    var textBlockDiscription = new TextBlock();
                    textBlockDiscription.Text = i.Description;
                    textBlockDiscription.FontSize = 14;
                    textBlockDiscription.TextWrapping = TextWrapping.Wrap;
                    textBlockDiscription.Foreground = Brushes.Black;

                    stackPanel.Children.Add(textBlockDiscription);

                    var textBlockPrice = new TextBlock();
                    textBlockPrice.Text = i.Price.ToString();
                    textBlockPrice.FontSize = 20;
                    Thickness marginTextBlockPrice = textBlockPrice.Margin;
                    marginTextBlockPrice.Left = 0;
                    marginTextBlockPrice.Right = 0;
                    marginTextBlockPrice.Top = 15;
                    marginTextBlockPrice.Bottom = 15;
                    textBlockPrice.Margin = marginTextBlockPrice;
                    textBlockPrice.Foreground = Brushes.Silver;

                    stackPanel.Children.Add(textBlockPrice);

                    var buttonForCart = new Button();
                    buttonForCart.Background = Brushes.Blue;
                    buttonForCart.BorderBrush = Brushes.Blue;
                    buttonForCart.Content = "In Cart";
                    buttonForCart.Name = "n" + i.ItemId.ToString();
                    buttonForCart.Click += ButtonClickForAddInCart;

                    stackPanel.Children.Add(buttonForCart);

                    gridN.Children.Add(stackPanel);

                    gridAdd.Items.Add(gridN);
                }

                ShopContext.SaveChanges();
            }

            List<string> KakYgodno = new List<string>();

            for (int i = 0; i < 10; i++) 
            {
                KakYgodno.Add("SLs");
            }

            var grid = new Grid
            {
                Width = 250,
                Height = 100
            };

            
        }

		private void WindowMove(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void ExitButtonClick(object sender, RoutedEventArgs e)
		{
            Environment.Exit(0);
		}

		private void MaximazeClick(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;
			}

			else if (WindowState == WindowState.Normal)
			{
				WindowState = WindowState.Maximized;
			}
		}

		private void MinimazeClick(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}            

        private void LoginEnterClick(object sender, RoutedEventArgs e)
        {
            using(ShopContext shopContext = new ShopContext())
            {
                foreach(var user in shopContext.Users)
                {
                    if(loginTextBox.Text == user.Phone && passwordLog.Password== user.Password)
                    {
                        mainPanel.Visibility = Visibility.Visible;
                        windowLogin.Visibility = Visibility.Collapsed;
                    }
                }
                loginTextBox.Text = null;
                passwordLog.Password = null;
            }
            //LOGIN
            
        }

        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            
            string resultPage = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.mobizon.kz/service/Message/SendSmsMessage?recipient=" + regTextBox.Text + "&text=" + GenerateRandomCode() + "&apiKey=kz21f62b9387cebabe7cbbafdcf32af0ad83e4d32062d299e9fe19d795fac845f78694");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }
            //REGISTRAT



            regText.Visibility = Visibility.Collapsed;
            regTextBox.Visibility = Visibility.Collapsed;
            regEnter.Visibility = Visibility.Collapsed;
            passwordReg.Visibility = Visibility.Collapsed;

            checkText.Visibility = Visibility.Visible;
            checkTextBox.Visibility = Visibility.Visible;
            checkEnter.Visibility = Visibility.Visible;
        }

        private void SwapRegButton(object sender, RoutedEventArgs e)
        {
            if (regText.Visibility == Visibility.Collapsed && regTextBox.Visibility == Visibility.Collapsed && passwordReg.Visibility == Visibility.Collapsed && regEnter.Visibility == Visibility.Collapsed)
            {
                regText.Visibility = Visibility.Visible;
                regTextBox.Visibility = Visibility.Visible;
                regEnter.Visibility = Visibility.Visible;
                passwordReg.Visibility = Visibility.Visible;

                loginText.Visibility = Visibility.Collapsed;
                loginTextBox.Visibility = Visibility.Collapsed;
                loginEnter.Visibility = Visibility.Collapsed;
                passwordLog.Visibility = Visibility.Collapsed;                
                checkText.Visibility = Visibility.Collapsed;
                checkTextBox.Visibility = Visibility.Collapsed;
                checkEnter.Visibility = Visibility.Collapsed;
            }

            else if (loginText.Visibility == Visibility.Collapsed && loginTextBox.Visibility == Visibility.Collapsed && loginEnter.Visibility == Visibility.Collapsed && passwordLog.Visibility == Visibility.Collapsed)
            {

                loginText.Visibility = Visibility.Visible;
                loginTextBox.Visibility = Visibility.Visible;
                loginEnter.Visibility = Visibility.Visible;
                passwordLog.Visibility = Visibility.Visible;


                regText.Visibility = Visibility.Collapsed;
                regTextBox.Visibility = Visibility.Collapsed;
                regEnter.Visibility = Visibility.Collapsed;
                passwordReg.Visibility = Visibility.Collapsed;
                checkText.Visibility = Visibility.Collapsed;
                checkTextBox.Visibility = Visibility.Collapsed;
                checkEnter.Visibility = Visibility.Collapsed;
            }


        }

        private void CheckButtonClick(object sender, RoutedEventArgs e)
        {
            //SMS CODE
            if (checkTextBox.Text == code.ToString())
            {
                using (ShopContext shopContext = new ShopContext())
                {
                    shopContext.Users.Add(new User
                    {
                        FullName="test testулы",
                        Phone = regTextBox.Text,                        
                        Password = passwordReg.Password
                    });
                    shopContext.SaveChanges();
                }

                loginText.Visibility = Visibility.Visible;
                loginTextBox.Visibility = Visibility.Visible;
                loginEnter.Visibility = Visibility.Visible;
                passwordLog.Visibility = Visibility.Visible;

                checkText.Visibility = Visibility.Collapsed;
                checkTextBox.Visibility = Visibility.Collapsed;
                checkEnter.Visibility = Visibility.Collapsed;
            }
            else
            {
                checkTextBox.Text = null;
                

            }
            
        }
        private void DoPayPalPayment()
        {
            double flex=0;
            using(ShopContext shopContext = new ShopContext())
            {
                foreach(var i in shopContext.ItemHolder)
                {
                    flex += i.AmountPrice;
                }
            }
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            var payout = new Payout
            {
                sender_batch_header = new PayoutSenderBatchHeader
                {
                    sender_batch_id = "batch_" + Guid.NewGuid().ToString().Substring(0, 8),
                    email_subject = "You have payment",
                    recipient_type = PayoutRecipientType.EMAIL
                },

                items = new List<PayoutItem>
            {
                new PayoutItem
                {
                    recipient_type = PayoutRecipientType.EMAIL,
                    amount = new Currency { value=flex.ToString(), currency="USD" },
                    receiver = "raywom92@gmail.com",
                    note="Thank you",
                    sender_item_id = "item_1"
                }
            }
            };

            var created = payout.Create(apiContext, false);
        }

        private void ButtonClickForReturnToMainMenu(object sender, RoutedEventArgs e)
        {
            mainPanel.Visibility = Visibility.Visible;
            cartMenu.Visibility = Visibility.Collapsed;
        }

        public static string SignUp(string phone)
        {
            bool isVerifiedNumber = false;
            string message = "";
            int code = 0;
            int codeTwo = 0;
            Random random = new Random();
            while (!isVerifiedNumber)
            {
                code = random.Next(1000, 9999);
                Code(phone, code.ToString());

                int.TryParse(Console.ReadLine(), out codeTwo);
                
                if (code == codeTwo)
                {
                    message = "Вы зарегистрировались";
                    isVerifiedNumber = true;
                    return message;
                }
                else
                {
                    Console.WriteLine("Код не верен");
                }

                message = "Это имя занято";

                message = "Этот телефон используется";
                isVerifiedNumber = true;

            }
            return message;
        }

        private static string GenerateRandomCode()
        {
            Random random = new Random();
            code = random.Next(1000, 9999);
            return code.ToString();
        }
        private static void AddItemsToDatabase()
        {
            using (ShopContext shopContext = new ShopContext())
            {
                foreach (var f in shopContext.ItemHolder)
                {
                    shopContext.ItemHolder.Remove(f);
                }

                foreach (var f in shopContext.Items)
                {
                    shopContext.Items.Remove(f);
                }
                shopContext.Items.Add(new Item
                {
                    Description="Свежий флекс, только с завода, печется у бати дома",                    
                    Name="Медбрат с клиники",
                    Price=228,
                    UrlImg= "https://memepedia.ru/wp-content/uploads/2018/12/53de85a01daaa834ee9c2c1725e3f5dd7d8aea61-768x480.png"
                });
                shopContext.Items.Add(new Item
                {
                    Description="Админка майнкампфа с правами СОЗДАТЕЛЯ!! можете изменять чужой регион, банить, кикать, все что захотите!",                    
                    Name ="АДМИНКА НА ТОПОВОМ ПРОЕКТЕ МАЙНКАМПФ 1488",
                    Price=200,
                    UrlImg= "https://i.ytimg.com/vi/gVsak7YGwRY/maxresdefault.jpg"
                });
                shopContext.Items.Add(new Item
                {
                    Description="Лорем не ипсум долорил сита вот амет",                    
                    Name="Хирург из клиники",
                    Price=1337,
                    UrlImg= "https://cs9.pikabu.ru/post_img/2017/10/26/9/1509032298174163733.jpg"
                });
                shopContext.Items.Add(new Item
                {
                    Description="Секретные материалы из зоны 68(9) нло",                    
                    Name="Файлы из даркнета",
                    Price=2342,
                    UrlImg= "https://i.ytimg.com/vi/IRXfXFj0YPk/maxresdefault.jpg"
                });

                shopContext.SaveChanges();
            }
        }
        public static void Code(string phone, string text)
        {
            string resultPage = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.mobizon.kz/service/Message/SendSmsMessage?recipient=" + phone + "&text=" + text + "&apiKey=kz21f62b9387cebabe7cbbafdcf32af0ad83e4d32062d299e9fe19d795fac845f78694");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

        }



        private void UpdatPage()
        {
            cartMenu.Visibility = Visibility.Visible;
            mainPanel.Visibility = Visibility.Collapsed;

            cartListBox.Items.Clear();

            using (ShopContext shopContext = new ShopContext()) { 

                foreach (var i in shopContext.ItemHolder)
                {
                    string name = "";
                    string price = "";                    

                    foreach (var j in shopContext.Items)
                    {
                        if (i.IdItem == j.ItemId) {
                            name = j.Name;
                            price = j.Price.ToString();
                        }
                    }

                    Grid gridForItemsInListCart = new Grid
                    {
                        Background = Brushes.White,
                        Height = 70,
                        Width = 1060,
                        Effect = new DropShadowEffect
                        {
                            BlurRadius = 20,
                            ShadowDepth = 1
                        }
                    };
                    gridForItemsInListCart.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(107)
                    });
                    gridForItemsInListCart.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(302)
                    });
                    gridForItemsInListCart.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(202)
                    });
                    gridForItemsInListCart.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(177)
                    });
                    gridForItemsInListCart.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(209)
                    });

                    TextBlock textBlockToCount = new TextBlock
                    {
                        Foreground = Brushes.Black,
                        FontSize = 30,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = 40,
                        Text = i.Count.ToString()
                    };                    

                    Thickness marginTextBlockToCount = textBlockToCount.Margin;
                    marginTextBlockToCount.Bottom = 15;
                    marginTextBlockToCount.Left = 0;
                    marginTextBlockToCount.Right = 15;
                    marginTextBlockToCount.Top = 0;
                    textBlockToCount.Margin = marginTextBlockToCount;

                    gridForItemsInListCart.Children.Add(textBlockToCount);

                    Grid.SetColumn(textBlockToCount, 0);                    

                    TextBlock textBlockToName = new TextBlock
                    {
                        Text = name,
                        Foreground = Brushes.Black,
                        FontSize = 30,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = 40
                    };
                    Thickness marginTextBlockToName = textBlockToName.Margin;
                    marginTextBlockToName.Bottom = 15;
                    marginTextBlockToName.Left = 0;
                    marginTextBlockToName.Right = 15;
                    marginTextBlockToName.Top = 0;
                    textBlockToName.Margin = marginTextBlockToName;

                    gridForItemsInListCart.Children.Add(textBlockToName);

                    Grid.SetColumn(textBlockToName, 1);

                    TextBlock textBlockToPrice = new TextBlock
                    {
                        Text = price,
                        Foreground = Brushes.Black,
                        FontSize = 30,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = 40
                    };
                    Thickness marginTextBlockToPrice = textBlockToPrice.Margin;
                    marginTextBlockToPrice.Bottom = 15;
                    marginTextBlockToPrice.Left = 0;
                    marginTextBlockToPrice.Right = 15;
                    marginTextBlockToPrice.Top = 0;
                    textBlockToPrice.Margin = marginTextBlockToPrice;

                    gridForItemsInListCart.Children.Add(textBlockToPrice);

                    Grid.SetColumn(textBlockToPrice, 2);

                    TextBlock textBlockToAmount = new TextBlock
                    {
                        Text = i.AmountPrice.ToString(),
                        Foreground = Brushes.Black,
                        FontSize = 30,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = 40
                    };
                    Thickness marginTextBlockToAmount = textBlockToAmount.Margin;
                    marginTextBlockToAmount.Bottom = 15;
                    marginTextBlockToAmount.Left = 0;
                    marginTextBlockToAmount.Right = 15;
                    marginTextBlockToAmount.Top = 0;
                    textBlockToAmount.Margin = marginTextBlockToAmount;

                    gridForItemsInListCart.Children.Add(textBlockToAmount);

                    Grid.SetColumn(textBlockToAmount, 3);

                    Button buttonForDelete = new Button
                    {
                        Background = Brushes.Red,
                        Content = "Удалить",
                        Name = "n" + i.Id.ToString()
                    };
                    Thickness marginButtonForDelete = buttonForDelete.Margin;
                    marginButtonForDelete.Bottom = 20;
                    marginButtonForDelete.Left = 20;
                    marginButtonForDelete.Right = 20;
                    marginButtonForDelete.Top = 20;
                    buttonForDelete.Margin = marginButtonForDelete;
                    buttonForDelete.Click += ButtonClickForDeleteItemToCart;


                    gridForItemsInListCart.Children.Add(buttonForDelete);

                    Grid.SetColumn(buttonForDelete, 4);

                    cartListBox.Items.Add(gridForItemsInListCart);
                }
            }
        }

        private void FillingInTheHistoryDataGrid()
        {
            using (ShopContext shopContext = new ShopContext())
            {
                historyGrid.ItemsSource = shopContext.HistoryBuy.ToList();
            }
        }

        private void ButtonForOpenCartMenuClick(object sender, RoutedEventArgs e)
        {
            UpdatPage();
        }

        private void ButtonClickForAddInCart(object sender, RoutedEventArgs e)
        {
            bool Open = true;

            using (ShopContext shopContext = new ShopContext())
            {
                foreach (var i in shopContext.ItemHolder)
                {
                    if ("n" + i.IdItem.ToString() == (sender as Button).Name)
                    {
                        foreach (var j in shopContext.Items)
                        {
                            if ("n" + j.ItemId.ToString() == (sender as Button).Name)
                            {
                                i.AmountPrice += j.Price;                               
                            }
                        }
                        i.Count++;
                        Open = false;
                    }
                }
                if (Open)
                {
                    foreach (var i in shopContext.Items)
                    {
                        if ("n" + i.ItemId.ToString() == (sender as Button).Name)
                        {
                            shopContext.ItemHolder.Add(new ItemHolder
                            {
                                IdItem = i.ItemId,                               
                                AmountPrice = i.Price,
                                Count = 1,
                                Item = i
                            });
                        }
                    }
                }


                shopContext.SaveChanges();
            }

            countItemsInCart.Text = GetCountInCart().ToString();
        }

        private void ButtonClickForDeleteItemToCart(object sender, RoutedEventArgs e)
        {            
            using (ShopContext shopContext = new ShopContext())
            {
                foreach (var i in shopContext.ItemHolder)
                {
                    if ("n"+i.Id == (sender as Button).Name)
                    {
                        shopContext.ItemHolder.Remove(i);
                    }
                }
                shopContext.SaveChanges();
            }
            UpdatPage();
            countItemsInCart.Text = GetCountInCart().ToString();
        }

        private int GetCountInCart()
        {
            var count = 0;
            using(ShopContext shopContext = new ShopContext())
            {
                foreach (var i in shopContext.ItemHolder)
                {
                    count += i.Count;
                }
            }
            return count;
        }

        private void ButtonClickForPayAllItems(object sender, RoutedEventArgs e)
        {
            DoPayPalPayment();
            using (ShopContext shopContext = new ShopContext())
            {
                string name = "";
                foreach (var i in shopContext.ItemHolder)
                {
                    foreach (var j in shopContext.Items)
                    {
                        if (j.ItemId == i.IdItem)
                            name = j.Name;
                    }

                    shopContext.HistoryBuy.Add(new HistoryBuy {
                        Count = i.Count,
                        AmountPrice = i.AmountPrice,
                        NameItem = name,
                        DateTime = DateTime.Now
                    });

                    shopContext.ItemHolder.Remove(i);
                }

                shopContext.SaveChanges();
            }
            UpdatPage();
            countItemsInCart.Text = GetCountInCart().ToString();
        }

        private void TransitionToHistoryGrid(object sender, RoutedEventArgs e)
        {
            mainPanel.Visibility = Visibility.Collapsed;
            tableHistoryMenu.Visibility = Visibility.Visible;
            FillingInTheHistoryDataGrid();
        }

        private void ButtonClickToMainMenu(object sender, RoutedEventArgs e)
        {
            mainPanel.Visibility = Visibility.Visible;
            tableHistoryMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonClickToParse(object sender, RoutedEventArgs e)
        {
            documentMenu.Visibility = Visibility.Visible;
            tableHistoryMenu.Visibility = Visibility.Collapsed;

            var fixedDocument = new FixedDocument();
            var pageContent = new PageContent();
            var fixedPage = new FixedPage();

            DataGrid dataGrid = new DataGrid();
            
            using (ShopContext shopContext = new ShopContext())
            {
                dataGrid.ItemsSource = shopContext.HistoryBuy.ToList();
            }

            fixedPage.Children.Add(dataGrid);
            pageContent.Child = fixedPage;
            fixedDocument.Pages.Add(pageContent);

            var stream = new MemoryStream();
            var uri = new Uri("pack://document.xps");
            var package = Package.Open(stream, FileMode.Create, FileAccess.ReadWrite);
            PackageStore.AddPackage(uri, package);
            var xpsDoc = new XpsDocument(package, CompressionOption.NotCompressed, uri.AbsoluteUri);
           
            var docWriter = XpsDocument.CreateXpsDocumentWriter(xpsDoc);
            docWriter.Write(fixedDocument);
          
            documentViewer.Document = xpsDoc.GetFixedDocumentSequence();
        }

        private void buttonClickForBackDataGrid(object sender, RoutedEventArgs e)
        {
            documentMenu.Visibility = Visibility.Collapsed;
            tableHistoryMenu.Visibility = Visibility.Visible;
            FillingInTheHistoryDataGrid();
        }

        private void ButtonClickForSaveDocument(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XPS Files (*.xps)|*.xps";
            if (sfd.ShowDialog() == true)
            {
                XpsDocument doc = new XpsDocument(sfd.FileName, FileAccess.Write);
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                writer.Write(documentViewer.Document as FixedDocumentSequence);
                doc.Close();
            }
        }
    }
}
