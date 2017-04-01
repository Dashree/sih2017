del db.sqlite3
del 000*.py /s
py manage.py makemigrations
py manage.py migrate
py manage.py loaddata users.json
