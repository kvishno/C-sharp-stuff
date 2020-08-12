import requests
import threading
from datetime import datetime
from datetime import date


def postloop():
    threading.Timer(60.0, postloop).start()

    url = 'https://example.com/login.html'
    myobj = {'LoginAction': 'login', 'Username': 'TestUsername', 'Password': 'TestPassword!'}
    x = requests.post(url, data=myobj)

    now = datetime.now()
    current_time = now.strftime("%H:%M:%S")

    today = date.today()
    d1 = today.strftime("%d/%m/%Y")

    f = open("output.txt", "a")
    print(d1, current_time, "-", x.elapsed, file=f)
    f.close()


if __name__ == '__main__':
    postloop()
