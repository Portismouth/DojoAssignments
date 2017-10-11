from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import md5
app = Flask(__name__)
mysql = MySQLConnector(app,'the_wall')
app.secret_key = 'KeepItSecretKeepItSafe'


@app.route('/')
def index():
    return render_template('index.html')

@app.route('/the_wall')
def success():
    query = "SELECT users.id AS users_id, messages.id AS message_id, users.first_name AS first_name, messages.message AS message, messages.created_at AS  created_at, comments.comment AS comments FROM users LEFT JOIN messages ON users.id = messages.users_id LEFT JOIN comments ON messages.id = comments.messages_id GROUP BY message_id"
    r_query = "SELECT messages.id AS message_id, comments.comment AS comments, comments.created_at AS created_at, users2.first_name AS user FROM users LEFT JOIN messages ON users.id = messages.users_id LEFT JOIN comments ON messages.id = comments.messages_id LEFT JOIN users AS users2 ON comments.users_id = users2.id"
    reply = mysql.query_db(r_query)
    messages = mysql.query_db(query)
    print reply
    return render_template('thewall.html', messages=messages, reply=reply)

@app.route('/register', methods=["POST"])
def register():
    first_name = request.form['first_name']
    last_name = request.form['last_name']
    email = request.form['email']
    password = md5.new(request.form['password']).hexdigest()
    confirm = md5.new(request.form['confirm']).hexdigest()
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
    if success:
        insert_query = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{}','{}','{}','{}', NOW(), NOW())".format(first_name, last_name, email, password)
        mysql.query_db(insert_query)
        user_query = "SELECT * FROM users where users.email = '{}' AND users.password = '{}'".format(email,password)
        session['user'] = mysql.query_db(user_query)[0]
        return redirect('/the_wall')
    
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
        return redirect('/the_wall')

@app.route('/message/<id>', methods=['POST'])
def message(id):
    message = request.form['message']
    id = int(id)
    if len(message) < 1:
        flash('Message has to have content')
        return redirect('/the_wall')
    else: 
        query = "INSERT INTO messages (message, created_at, updated_at, users_id) VALUES ('{}', NOW(), NOW(), {})".format(message, id)
        print query
        mysql.query_db(query)
        return redirect('/the_wall')

@app.route('/comment/<id>', methods=['POST'])
def comment(id):
    message = request.form['comment']
    message_id = request.form['hidden']
    if len(message) < 1:
        flash('reply has to have content')
        return redirect('/the_wall')
    else: 
        query = "INSERT INTO comments (comment, created_at, updated_at, users_id, messages_id) VALUES ('{}', NOW(), NOW(), {}, {})".format(message, id, message_id)
        print query
        mysql.query_db(query)
        return redirect('/the_wall')

@app.route('/logout', methods=['POST'])
def logout():
    session.clear()
    return redirect('/')

app.run(debug=True)