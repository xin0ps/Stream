
using System.Drawing;




       
            while (true)
            {
                Console.WriteLine("Press Enter for screenshot");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Bitmap memoryImage = new Bitmap(1920, 1080);
                    Size S = new Size(memoryImage.Width, memoryImage.Height);
                    using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
                    {
                        memoryGraphics.CopyFromScreen(0, 0, 0, 0, memoryImage.Size);
                    }

                    string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Images");

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    int screenshotCount = Directory.GetFiles(folderPath, "image(*).jpg").Length;
                    string[] files = Directory.GetFiles(folderPath, "image(*).jpg");

                    for (int i = 1; i <= screenshotCount; i++)   // Ard arda olmasini tamamlamaq ucun algorithm yeni 1,2,3,6,7 idirse sekil siralamasi aradaki (4,5) doldurulur sonra davam edir.
                    {
                        string targetFileName = $"image({i}).jpg"; 

                        bool fileExists = Array.Exists(files, files => files.EndsWith(targetFileName, StringComparison.OrdinalIgnoreCase));

                        if (fileExists)
                        {
                            continue;
                        }
                        if (fileExists&&i==screenshotCount)
                        {
                            screenshotCount+=1;
                            break;
                        }

                        else {
                            screenshotCount = i;
                            break;
                        }
                    }
                    

                    string fileName = Path.Combine(folderPath, $"image({screenshotCount}).jpg");
                    memoryImage.Save(fileName);
                    Console.WriteLine("Picture has been saved to " + fileName);
                }
                else
                {
                    break; 
                }
            }
        
    

