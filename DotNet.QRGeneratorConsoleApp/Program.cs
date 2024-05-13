Console.WriteLine("Enter the data to encode in the QR code:");
var data = Console.ReadLine()!;
var  qrGenerator = new QRCodeGenerator();
var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
var qrCode = new QRCode(qrCodeData);
Bitmap qrCodeImage = qrCode.GetGraphic(20);

var folderPath = @"C:\Users\hlain\Downloads";
if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}

var fileName = Path.Combine(folderPath, data + "_" + "QRCode.png");
qrCodeImage.Save(fileName, ImageFormat.Png);

DisplayQRCodeImage(fileName);

Console.ReadLine();

static void DisplayQRCodeImage(string imagePath)
{
    try
    {
        if (File.Exists(imagePath))
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = imagePath,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        else
        {
            Console.WriteLine("QR code image not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}