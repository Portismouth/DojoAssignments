from flask import Flask, render_template, request, redirect, session, url_for
import random
app = Flask(__name__)
app.secret_key = 'ThisIsSecret' # you need to set a secret key for security purposes


@app.route('/')
def index():
    if not 'random' in session:
        session['random'] = random.randrange(0,101)
    if not 'counter' in session:
        session['counter'] = 0
    session['counter'] += 1
    return render_template("index.html")

@app.route('/submit', methods=['POST'])
def guess():
    guess = int(request.form['guess'])
    if session['random'] > guess:
        session['content'] = "Guess is too low You have guessed "+str(session['counter'])+" times"
    elif session['random'] < guess:
        session['content'] = "Guess is too high You have guessed "+str(session['counter'])+" times"
    else:
        session['content'] = "YOU ARE A WINNER IN "+str(session['counter'])+" GUESSES"
    return redirect("/")

@app.route('/clear', methods=['POST'])
def clear():
    session.clear()
    return redirect("/")

app.run(debug=True)