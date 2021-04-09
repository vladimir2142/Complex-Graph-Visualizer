    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Collections.Generic;

    namespace WpfApp1
    {

        class MyClass
        {
            public string First { get; set; }

            public string Second { get; set; }

            public string Third { get; set; }

        }

        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>

        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();


            }

            public List<List<double>> list = new List<List<double>>(); // Двумерный список 

            public int cont_soedin = 0;
            public bool chek = false; //переменная включен ли переключатель для добавления вершин 
            public int Count_Point = 0; // счетчик количества точек-вершин 
            public bool Select = false; // переменная которая хранит включенность кнопки выбора вершины
            private double x1 = 0;
            private double x2 = 0;
            private double y1 = 0;
            private double y2 = 0;
            private int number_first = 0;
            private bool delete = false;
            private List<List<string>> del = new List<List<string>>();
            

            private void Grid_MouseDown(object sender, MouseButtonEventArgs e) // добавление точки 
            {

                if (chek == false) // проверка переулючателя добавления точки 
                {

                }
                else
                {

                    Count_Point++; // прибавление +1 к счетчику вершин 
                    TextBox TX = new TextBox(); // создаём поле которое будет внутри нашей точки  
                    TX.Text = Count_Point.ToString(); // передаем полю значение нашего счетчика точек
                    Point p = e.GetPosition(this); //получаем позицию нашей мышки в переменную "p"
                    Ellipse point = new Ellipse(); //создаём круг 
                    TX.BorderBrush = null; // убираем цвет бортика поля с переменной 
                    TX.Background = null; // убираем цвет поля с переменной 
                    TX.IsEnabled = false; // убираем возможность изменения надписи 
                    TX.Foreground = Brushes.White; // цвет шрифта для счетчка - белый 
                    point.Fill = Brushes.MidnightBlue; //цвет самой вершины-точки 
                    point.Width = 25; //размер точки в ширину 
                    point.Height = 25; // размер точки в высоту 
                    point.Margin = new Thickness(p.X, p.Y, 0, 0); //расположение точки - вершины на нащем канвасе
                    TX.Margin = new Thickness(p.X, p.Y, 0, 0); //Распололжения счетчика на нашем канвасе 
                    Can.Children.Add(point); //добавления точки в канвас 
                    Can.Children.Add(TX); //добавление счетчика в канвас 
                    ObservableCollection<MyClass> collection = null;
                    table.Items.Add(new MyClass()
                        {First = Count_Point.ToString(), Second = p.X.ToString(), Third = p.Y.ToString()});
                    table.ScrollIntoView(true);
                    list.Add(new List<double>());
                    list[Count_Point - 1].Add(Count_Point);
                    list[Count_Point - 1].Add(p.X);
                    list[Count_Point - 1].Add(p.Y);
                    


                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////
                if (delete == false)
                {

                }
                else
                {
                    Point p = e.GetPosition(this);
                    bool ok = false;
                    foreach (var item in list)
                    {

                        if (p.X < (item[1] + 12.5) && p.X > (item[1] - 12.5) && p.Y < (item[2] + 12.5) &&
                            p.Y > (item[2] - 12.5))
                        {

                            Rectangle point = new Rectangle();
                            point.Fill = Brushes.Lavender; //цвет самой вершины-точки 
                            point.Width = 30; //размер точки в ширину 
                            point.Height = 30; // размер точки в высоту 
                            point.Margin = new Thickness(item[1], item[2], 0, 0);
                            Can.Children.Add(point);
                           

                        }
                    }
                }
            
        
    


    if (Select == false)
                {
                    
                }
                else
                {
                    Point p = e.GetPosition(this);
                    bool ok = false;
                    foreach (var item in list)
                    {
                        
                        if (p.X <(item[1]+12.5)&&p.X>(item[1]-12.5) && p.Y < (item[2]+12.5)&&p.Y>(item[2]-12.5))
                        {
                            if (cont_soedin > 0)
                            {
                                if (checkBox1.IsChecked == false)
                                {
                                    x2 = item[1];
                                    y2 = item[2];
                                    cont_soedin = 0;
                              
                                    var line = new Line
                                    {
                                        Stroke = Brushes.MidnightBlue,
                                        X1 = x1+16.6,
                                        Y1 =y1+16.7 ,
                                        X2 = x2+16.7,
                                        Y2 = (y2+16.7),

                                    };
                                    Can.Children.Add(line);
                                    Ellipse point = new Ellipse();
                                    point.Fill = Brushes.MidnightBlue;//цвет самой вершины-точки 
                                    point.Width = 25;//размер точки в ширину 
                                    point.Height = 25;// размер точки в высоту 
                                    point.Margin = new Thickness(x1,y1, 0, 0);
                                    Can.Children.Add(point);
                                    TextBox TX = new TextBox(); // создаём поле которое будет внутри нашей точки  
                                    TX.Text = number_first.ToString();// передаем полю значение нашего счетчика точек
                                    TX.BorderBrush = null; // убираем цвет бортика поля с переменной 
                                    TX.Background= null; // убираем цвет поля с переменной 
                                    TX.IsEnabled = false; // убираем возможность изменения надписи 
                                    TX.Foreground=Brushes.White; // цвет шрифта для счетчка - белый 
                                    TX.Margin=new Thickness(x1,y1, 0, 0);
                                    Can.Children.Add(TX);
                                }
                                else
                                {
                                    x2 = item[1];
                                    y2 = item[2];
                                    double d = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
 
                                    double X = x2 - x1;
                                    double Y = y2 - y1;
 
                                    double X3 = x2 - (X / d) * 25;
                                    double Y3 = y2 - (Y / d) * 25;
 
                                    double Xp = y2 - y1;
                                    double Yp = x1 - x2;
 
                                    double X4 = X3 + (Xp / d) * 5;
                                    double Y4 = Y3 + (Yp / d) * 5;
                                    double X5 = X3 - (Xp / d) * 5;
                                    double Y5 = Y3 - (Yp / d) * 5;
 
                                    Line line = new Line
                                    {
                                        Stroke = Brushes.MidnightBlue,
                                        X1 = x1+16.6,
                                        Y1 = y1+16.6,
                                        X2 = x2+16.6,
                                        Y2 = y2+16.6
                                    };
                                    Can.Children.Add(line);
 
                                    line = new Line
                                    {
                                        Stroke = Brushes.MidnightBlue,
                                        X1 = x2 - (X / d) * 10+16.6,
                                        Y1 = y2 - (Y / d) * 10+16.6,
                                        X2 = X4+16.6,
                                        Y2 = Y4+16.6
                                    };
                                    Can.Children.Add(line);
 
                                    line = new Line
                                    {
                                        Stroke = Brushes.MidnightBlue,
                                        X1 = x2 - (X / d) * 10+16.6,
                                        Y1 = y2 - (Y / d) * 10+16.6,
                                        X2 = X5+16.6,
                                        Y2 = Y5+16.6
                                    };
                                    Can.Children.Add(line);
                                    Ellipse point = new Ellipse();
                                    point.Fill = Brushes.MidnightBlue;//цвет самой вершины-точки 
                                    point.Width = 25;//размер точки в ширину 
                                    point.Height = 25;// размер точки в высоту 
                                    point.Margin = new Thickness(x1,y1, 0, 0);
                                    Can.Children.Add(point);
                                    TextBox TX = new TextBox(); // создаём поле которое будет внутри нашей точки  
                                    TX.Text = number_first.ToString();// передаем полю значение нашего счетчика точек
                                    TX.BorderBrush = null; // убираем цвет бортика поля с переменной 
                                    TX.Background= null; // убираем цвет поля с переменной 
                                    TX.IsEnabled = false; // убираем возможность изменения надписи 
                                    TX.Foreground=Brushes.White; // цвет шрифта для счетчка - белый 
                                    TX.Margin=new Thickness(x1,y1, 0, 0);
                                    Can.Children.Add(TX);
                                }
                               
                            }
                            else
                            {
                                ok = true;
                                Ellipse point = new Ellipse();
                                point.Fill = Brushes.Blue;//цвет самой вершины-точки 
                                point.Width = 25;//размер точки в ширину 
                                point.Height = 25;// размер точки в высоту 
                                point.Margin = new Thickness(item[1],item[2], 0, 0);
                                Can.Children.Add(point);
                                TextBox TX = new TextBox(); // создаём поле которое будет внутри нашей точки  
                                TX.Text = item[0].ToString();// передаем полю значение нашего счетчика точек
                                TX.BorderBrush = null; // убираем цвет бортика поля с переменной 
                                TX.Background= null; // убираем цвет поля с переменной 
                                TX.IsEnabled = false; // убираем возможность изменения надписи 
                                TX.Foreground=Brushes.White; // цвет шрифта для счетчка - белый 
                                TX.Margin=new Thickness(item[1],item[2], 0, 0);
                                Can.Children.Add(TX);
                                number_first = (int)item[0];
                                cont_soedin++;
                                x1 = item[1];
                                y1 = item[2];
                               
                            }
                        }
                    }
                }
            }

       private void Point_Conection_select(object sender,  RoutedEventArgs e)//Функция для выбора точки 
       {
           
            
                if (Select == false)
                {
                    Select = true;
                    chek = false;
                    delete = false;

                }
                else
                {
                    Select = false;
                }
           

                
            }
            
            private void Point_Conect(object sender, RoutedEventArgs e) // Функция соеденяющая две точки 
            {
                Line line = new Line();
                line.X1 = 10;
                line.X2 = 50;
                line.Y1 = 10;
                line.Y2 = 50;
                line.Fill = Brushes.Black;
                Can.Children.Add(line);
            }
            private void buttonPrintPoint_Click(object sender, RoutedEventArgs e) // изменение значения переключателя и надписи в самой кнопке 
            {

                
                if (chek == false)
                {
                    per.Content = "Добавление точек";
                    chek = true;
                    Select = false;
                    delete = false;
                }
                else
                {
                    per.Content = "Добавление точек";
                    chek = false;
                }
                
              

            }

            private void Button_Delete(object sender, RoutedEventArgs e)//функция переключения удаления вершины 
            {
                if (delete == false)
                {
                    delete = true;
                    chek = false;
                    Select = false;
                }
                else
                {
                   
                }
            }

            private void Save(object sender, RoutedEventArgs e)
            {
                
                Rect rect = new Rect(Can.RenderSize);
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,
                    (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                rtb.Render(Can);
                //endcode as PNG
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                //save to memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);
                ms.Close();
                System.IO.File.WriteAllBytes("logo.png", ms.ToArray());
                MessageBox.Show("Граф сохранен в формате .png");
               
            }
            
        }
        
    }
 