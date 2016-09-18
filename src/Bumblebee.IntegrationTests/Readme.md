This project requires the ChromeDriver to be set up locally.

1.  Install 7-zip
2.  Download proper ChromeDriver version for your machine from http://chromedriver.storage.googleapis.com/[x.xx]/chromedriver_win32.zip.
3.  Extract the file (chromedriver.exe) and place in a folder that is on your path.  (Recommend:  C:\tools\WebDriver)

## Example Powershell for Downloading

$zipPath = "$env:USERPROFILE\chromedriver_win32.zip"
(New-Object Net.WebClient).DownloadFile('http://chromedriver.storage.googleapis.com/2.24/chromedriver_win32.zip', $zipPath)
.\7z.exe x $zipPath -oC:\Tools\WebDriver -aoa