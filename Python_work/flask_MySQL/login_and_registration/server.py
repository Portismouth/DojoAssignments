from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import md5
import re
app = Flask(__name__)
mysql = MySQLConnector(app,'login')
app.secret_key = 'KeepItSecretKeepItSafe'


@app.route('/')
def index():
    return render_template('index.html')

@app.route('/success')
def success():
    return render_template('success.html')

@app.route('/register', methods=["POST"])
def register():
    first_name = request.form['first_name']
    last_name = request.form['last_name']
    email = request.form['email'].lower()
    match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', email)
    password = request.form['password']
    confirm = request.form['confirm']
    success = True
    if len(email) < 1 or len(first_name) < 1 or len(last_name) < 1 or len(password) < 1 or len(confirm) < 1:
        flash('Please fill out all fields', "register")
        success = False
    if any(char.isdigit() for char in first_name) or any(char.isdigit() for char in last_name):
        flash('Numbers not allowed in name fields', "register")
        success = False
    if len(password) < 8 or len(confirm) < 8:
        flash('Password needs to be more than 8 characters', "register")
        success = False
    if password != confirm:
        flash('Passwords need to match', 'register')
        success = False
    if match == None:
        flash('Email is not valid!', 'register')
        return redirect('/')
    if success:
        password = md5.new(password).hexdigest()
        insert_query = "INSERT INTO users (first_name, last_name, email, password) VALUES ('{}','{}','{}','{}')".format(first_name, last_name, email, password)
        mysql.query_db(insert_query)
        user_query = "SELECT * FROM users where users.email = '{}' AND users.password = '{}'".format(email,password)
        session['user'] = mysql.query_db(user_query)[0]
        return redirect('/success')
    
    return redirect('/')

@app.route('/login', methods=["POST"])
def login():
    session['user'] = ''
    password = md5.new(request.form['password']).hexdigest()
    email = request.form['email']
    user_query = "SELECT * FROM users where users.email = '{}' AND users.password = '{}'".format(email,password)
    user = mysql.query_db(user_query)[0]
    print user
    if not user:
        flash('Login not successful', 'login')
        return redirect('/')
    else:
        session['user'] = user
        return redirect('/success')

@app.route('/logout', methods=['POST'])
def logout():
    session.clear()
    return redirect('/')

app.run(debug=True)