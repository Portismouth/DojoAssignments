from flask import Flask, render_template, request, redirect, url_for, flash, session
import datetime
app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'

def validate(date_text):
    today = datetime.datetime.today()
    try:
        datetime.datetime.strptime(date_text, '%m-%d-%Y')
        if datetime.datetime.strptime(date_text, '%m-%d-%Y') <= today:
            success = True
        else:
            success = False
            flash('Date is in the furture', 'error')
    except ValueError:
        flash("Incorrect date format, should be mm-dd-yyyy",'error')


# Our index route will handle rendering our form
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/results')
def results():
    return render_template("results.html")

@app.route('/process', methods=["POST"])
def submit():
    session['email'] = request.form['email']
    session['first_name'] = request.form["first_name"]
    session['last_name'] = request.form["last_name"]
    session['password'] = request.form["password"]
    session['confirm'] = request.form['confirm']
    session['date'] = request.form['date']
    success = True
    if len(session['email']) < 1 or len(session['first_name']) < 1 or len(session['last_name']) < 1 or len(session['password']) < 1 or len(session['confirm']) < 1 or len(session['date']) < 1:
        flash('Please fill out all fields', "error")
        success = False
    if any(char.isdigit() for char in session['first_name']) or any(char.isdigit() for char in session['last_name']):
        flash('Numbers not allowed in name fields', "error")
        success = False
    if len(session['password']) < 8 or len(session['confirm']) < 8:
        flash('Password needs to be more than 8 characters', "error")
        success = False
    if not any(char.isdigit() for char in session['password']) or not any(char.isupper() for char in session['password']):
        flash('Your password requires at least one number, and one uppercase letter', 'error')
        success = False
    if session['password'] != session['confirm']:
        flash('Passwords need to match', 'error')
        success = False
    if session['date']:
        validate(session['date'])
    if success:
        flash('User Added Successfully',"success")
        session['email'] = ""
        session['first_name'] = ""
        session['last_name'] = ""
        session['date'] = ""
        session['password'] = ""
        session['confirm'] = ""
        
    return redirect("/")

app.run(debug=True)