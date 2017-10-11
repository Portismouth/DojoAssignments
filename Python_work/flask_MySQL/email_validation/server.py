from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re

app = Flask(__name__)
mysql = MySQLConnector(app,'emails')
app.secret_key = 'KeepItSecretKeepItSafe'

email_lst = []

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/success')
def success():
    query = "SELECT email_list.id AS id, email_list.email AS email, email_list.created_at AS times FROM email_list ORDER BY times DESC"
    queries = mysql.query_db(query)
    return render_template('success.html', queries=queries)


@app.route('/delete/<id>', methods=['POST'])
def delete(id):
    query = "DELETE FROM email_list WHERE id = {}".format(id)
    mysql.query_db(query)
    session['message'] = "email deleted from list"
    return redirect('/success')


@app.route('/verification', methods=['POST'])
def verify():
    email = request.form['email'].lower()
    match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', email)
    if match == None:
        print "fail"
        flash('Email is not valid!')
        return redirect('/')
    else:
        print "success"
        query = "INSERT INTO email_list (email, created_at) VALUES ('{}', NOW())".format(email)
        mysql.query_db(query)
        session['message'] = str(email)+" on list!"
        return redirect('/success')  


app.run(debug=True)