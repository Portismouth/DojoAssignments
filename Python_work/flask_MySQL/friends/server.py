from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'friendsdb')

@app.route('/')
def index():
    query = "SELECT id, first_name, last_name, age, DATE(created_at) AS since FROM friends "
    friends = mysql.query_db(query) 
    return render_template('index.html', all_friends=friends)

@app.route('/friends', methods=['POST'])
def create():
    # Write query as a string. Notice how we have multiple values
    # we want to insert into our query.
    query = "INSERT INTO friends (first_name, last_name, age, created_at, updated_at) VALUES (:first_name, :last_name, :age, NOW(), NOW())"
    # We'll then create a dictionary of data from the POST data received.
    data = {
             'first_name': request.form['first_name'],
             'last_name':  request.form['last_name'],
             'age': request.form['age']
           }
    # Run query, with dictionary values injected into the query.
    mysql.query_db(query, data)
    return redirect('/')

@app.route('/update_friend/<friend_id>', methods=['GET','POST'])
def update(friend_id):
    if request.method == 'POST':
        query = "UPDATE friends SET first_name = :first_name, last_name = :last_name, age = :age WHERE id = :id"
        data = {
                'first_name': request.form['first_name'],
                'last_name':  request.form['last_name'],
                'age': request.form['age'],
                'id': friend_id
            }
        mysql.query_db(query, data)
        return redirect('/')
    else:
        return render_template('update.html', friend_id=friend_id)

@app.route('/delete_friend/<friend_id>', methods=['GET','POST'])
def delete(friend_id):
    if request.method == 'POST':
        query = "DELETE FROM friends WHERE id = :id"
        data = {
                'id': friend_id
            }
        mysql.query_db(query, data)
        return redirect('/')
    else:
        query = "SELECT * FROM friends WHERE id = :id"
        data = {
            'id': friend_id 
        }
        friend = mysql.query_db(query, data)[0]
        return render_template('delete.html', friend_id=friend_id, friend=friend)

app.run(debug=True)