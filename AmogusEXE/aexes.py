import base64 as b64
import json
import smtplib
import ssl
import sys
smtp_server = "smtp.gmail.com"
port = 587
context = ssl.create_default_context()


class Mailer:

    @staticmethod
    def get_data():
        with open("./data.enc") as f:
            o = f.read()
        decoded_bytes = b64.b64decode(o).decode("utf-8")
        print(str(decoded_bytes))
        return str(decoded_bytes)

    @staticmethod
    def parse_json(j: str):
        data = json.loads(j)["mail"]
        username = data["login"]
        password = data["password"]
        return {"name": username, "pass": password}

    @staticmethod
    def send(data, receiver, message):
        global server
        try:
            server = smtplib.SMTP(smtp_server, port)
            server.starttls(context=context)
            server.login(data["name"], data["pass"])
            server.sendmail(data["pass"], receiver, message)
        except Exception as e:
            print(e)
        finally:
            server.quit()

x = str(sys.argv[1])
y = str(sys.argv[2])
Mailer.send(Mailer.parse_json(Mailer.get_data()), x, y)