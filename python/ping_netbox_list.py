import requests
import subprocess


if __name__ == '__main__':
    r = requests.get('https://ipam.example.com/api/ipam/ip-addresses/?q=&status=deprecated&limit=0',
                     headers={'Authorization': 'Token ABCDEFG12345'})
    y = r.json()

    # Configure subprocess to hide the console window
    info = subprocess.STARTUPINFO()
    info.dwFlags |= subprocess.STARTF_USESHOWWINDOW
    info.wShowWindow = subprocess.SW_HIDE

    for x in y["results"]:
        z = str(x["address"]).split("/")
        output = subprocess.Popen(['ping', '-n', '1', '-w', '500', str(z[0])], stdout=subprocess.PIPE,
                                  startupinfo=info).communicate()[0]

        if "Destination host unreachable" in output.decode('utf-8'):
            print(str(z[0]), "is Offline")
        elif "Request timed out" in output.decode('utf-8'):
            print(str(z[0]), "is Offline")
        else:
            print(str(z[0]), "is Online")
