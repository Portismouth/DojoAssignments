from flask import Flask, render_template, request, redirect, session, url_for
import random
app = Flask(__name__)
app.secret_key = 'ThisIsSecret' # you need to set a secret key for security purposes


@app.route('/')
def index():
    if not 'gold' in session:
        session['gold'] = 0
    if not 'log' in session:
        session['log'] = []
    return render_template("index.html")

@app.route('/process_money', methods=["POST"])
def money():
    if request.form['building'] == 'farm':
        found = random.randrange(10,21)
        session['gold'] += found
        session['log'].append("The ninja gained "+str(found)+" gold")
    elif request.form['building'] == 'cave':
        found = random.randrange(5,11)
        session['gold'] += found
        session['log'].append("The ninja gained "+str(found)+" gold")
    elif request.form['building'] == 'house':
        found = random.randrange(2,6)
        session['gold'] += found
        session['log'].append("The ninja gained "+str(found)+" gold")
    else:
        check_win = random.randint(0, 1)
        if check_win == 1:
            found = random.randrange(1,51)
            session['gold'] += found
            session['log'].append("The ninja gained "+str(found)+" gold")
        else:
            found = random.randrange(1,51)
            session['gold'] -= found
            session['log'].append("The ninja lost "+str(found)+" gold")
    return redirect('/')

@app.route('/clear', methods=['POST'])
def clear():
    session.clear()
    return redirect("/")

app.run(debug=True)


